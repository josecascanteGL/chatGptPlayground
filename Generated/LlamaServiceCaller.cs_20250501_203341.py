class GitHubError:
    def __init__(self, message, documentation_url, status):
        self.message = message
        self.documentation_url = documentation_url
        self.status = status

error = GitHubError("Not Found", "https://docs.github.com/rest/repos/contents#get-repository-content", "404")