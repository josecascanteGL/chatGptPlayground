/*
 * Add inline comments to explain the logic of the code:
 * This code defines a partial class UnishopEntities that implements the IUnishipEntities interface.
 * It provides a method SetModified that sets the state of the input entity to Modified using Entity Framework.
 */

using System.Data.Entity;
using UnicornShopLegacy.Interfaces;

namespace UnicornShopLegacy
{
    /// <summary>
    /// Partial class only to implement IUnishipEntities interface and provide mockable method instead of Entry()
    /// </summary>
    public partial class UnishopEntities : IUnishopEntities
    {
        // Method to set the state of a given entity to Modified
        public void SetModified(object entity)
        {
            // Accesses the EF Entry method for the entity and sets its state to Modified
            this.Entry(entity).State = EntityState.Modified;
        }
    }
}
*/