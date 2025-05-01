class GitHubResponse:
    public string message;
    public string documentation_url;
    public string status;

    public GitHubResponse(string message, string documentation_url, string status) {
        this.message = message;
        this.documentation_url = documentation_url;
        this.status = status;
    }