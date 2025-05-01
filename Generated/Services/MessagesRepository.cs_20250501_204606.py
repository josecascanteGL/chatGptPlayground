class MessagesRepository:
    def __init__(self, dbManager):
        self.dbManager = dbManager

    async def save_chat(self, messages):
        await self.dbManager.save_chat_log(messages)
        return True

    async def load_previous_conversation(self):
        chat_messages = await self.dbManager.read_chat_log()
        return chat_messages