using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Ollamaworld;

# pragma warning disable SKEXP0070
var builder = Kernel.CreateBuilder();
builder.AddOllamaChatCompletion("llama3.2", new Uri("http://localhost:11434"));

var kernel = builder.Build();
var chatService = kernel.GetRequiredService<IChatCompletionService>();


kernel.Plugins.AddFromType<CarsPlugin>("Cars");

OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
{
    FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
};


var history = new ChatHistory();
history.AddSystemMessage("You are a helpful assistant chatbot at the parking lot [BIG].");

Console.WriteLine("Welcome to [BIG]");
Console.WriteLine("Type 'exit' to exit the chatbot\n");
Console.WriteLine("YOU: ");

while (true)
{ 
    var userMessage = Console.ReadLine();

    if (string.Equals(userMessage, "exit", StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    history.AddUserMessage(userMessage);
    Console.WriteLine("-----------------------------------\n");
    var response = await chatService.GetChatMessageContentAsync(history, openAIPromptExecutionSettings, kernel);
    Console.WriteLine($"BIG: \n{response.Content}");
    Console.WriteLine("-----------------------------------\n");
    history.AddMessage(response.Role, response.Content ?? string.Empty);

    Console.WriteLine("You: ");
}
