class LlamaServiceCaller:
    request = LlamaChatRequest()

    def __init__(self, client, messagesRepository):
        self.client = client
        messages = messagesRepository.LoadPreviousConversation()
        request.Messages.extend(messages.Result)

    async def ChatCall(self, message):
        request.Messages.append(Message(Role="user", Content=message))

        json = json.dumps(request)
        content = json.encode(json, "utf-8", "application/json")

        response = client.PostAsync("chat", content)
        if response.IsSuccessStatusCode:
            responseContent = response.Content.ReadAsStringAsync()
            llamaChatResponse = json.loads(responseContent)
            if llamaChatResponse.get("Message").get("Content") is not None:
                request.Messages.append(Message(Role="assistant", Content=llamaChatResponse.get("Message").get("Content"))
            return llamaChatResponse.get("Message").get("Content") or ""
        return response.StatusCode.toString()

    def GetMessages(self):
        return request.Messages