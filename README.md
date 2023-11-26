# CustomGpt
AI sample application to chat with custom data

# Application Building Blocks
For data storage:
  - Store your data in a vector database (this sample application uses SingleStore, Supabase vector db coming soon)
  - Convert user query to vector embedding and perform a similarity search against your pre-processed embeddings
  - Feed the search result to LLM (OpenAI in this sample)
  - Display the result
