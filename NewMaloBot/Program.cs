using DSharpPlus;
using DSharpPlus.Commands;
using DSharpPlus.Commands.Processors.SlashCommands;
using NewMaloBot.Commands;

namespace NewMaloBot;

internal static class Program
{
    private static async Task Main()
    {
        string? token = Environment.GetEnvironmentVariable("MALOBOT_TOKEN");

        if (token is null)
        {
            Console.WriteLine("Check your environment variables for MALOBOT_TOKEN");
            return;
        }

        var builder = DiscordClientBuilder.CreateDefault(token, DiscordIntents.All | SlashCommandProcessor.RequiredIntents | DiscordIntents.MessageContents);

        builder.UseCommands ((_, extension) =>
        {
            extension.AddCommands([
                typeof(Games)
            ]);
        });
        
        DiscordClient client = builder.Build();

        await client.ConnectAsync();
        await Task.Delay(-1);
    }
}