# CustomGpt
.NET Core sample application to chat with custom data using OpenAI APIs (Embedding and ChatCompletion)

# Database used:
- SingleStore as a vector DB to store embeddings

# Application Building Blocks
  - Store your data in a vector database (this sample application uses SingleStore)
  - Convert user query to vector embedding (using OpenAI API to generate embedding) and perform a similarity search against your pre-processed embeddings
  - Feed the search result to LLM (OpenAI in this sample)
  - Display the result

# TODO
- Adding support for Supabase vector and Postgres DB with pgVector
- Maybe use a different embedding logic than OpenAI API
- Code refactor
