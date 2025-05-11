// Import necessary namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace UnicornShopLegacy
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the current request is a postback
            if (!IsPostBack)
            {
                // Create a new instance of the UnicornShopEntities context
                using (UnicornShopEntities context = new UnicornShopEntities())
                {
                    // Query the database to get all products
                    var products = (from p in context.Products
                                    select p).ToList();

                    // Bind the products to the GridView control
                    gvProducts.DataSource = products;
                    gvProducts.DataBind();
                }
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            // Get the product ID of the selected row in the GridView
            int productId = Convert.ToInt32(gvProducts.DataKeys[gvProducts.SelectedRow.RowIndex].Value);

            // Create or retrieve the shopping cart from the session
            ShoppingCart cart;
            if (Session["Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            else
            {
                cart = (ShoppingCart)Session["Cart"];
            }

            // Add the selected product to the shopping cart
            cart.AddItem(productId);

            // Update the cart in the session
            Session["Cart"] = cart;

            // Redirect the user to the shopping cart page
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}