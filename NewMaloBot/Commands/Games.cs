using System.ComponentModel;
using DSharpPlus.Commands;
using DSharpPlus.Entities;

namespace NewMaloBot.Commands;

public class Games
{
    private static readonly string[] EightBallAnswers =
    [
        "It is certain",
        "It is decidedly so",
        "Without a doubt",
        "Yes — definitely",
        "You may rely on it",
        "As I see it, yes",
        "Most likely",
        "Outlook good",
        "Yes",
        "Signs point to yes",
        "Reply hazy, try again",
        "Ask again later",
        "Better not tell you now",
        "Cannot predict now",
        "Concentrate and ask again",
        "Don't count on it",
        "My reply is no",
        "My sources say no",
        "Outlook not so good",
        "Very doubtful"
    ];

    [Command("8ball")]
    [Description("Play 8ball")]
    public static async ValueTask EightBall(CommandContext ctx, [Description("What would you like to ask?")] string question)
    {
        int randomIndex = Random.Shared.Next(EightBallAnswers.Length);
        string answer = EightBallAnswers[randomIndex];

        var embedBuilder = new DiscordEmbedBuilder()
            .WithColor(DiscordColor.Purple)
            .WithTitle("8 Ball :8ball:")
            .WithDescription($"Your question: {question}\nAnswer: {answer}");

        await ctx.RespondAsync(embedBuilder.Build());
    }

    [Command("Coin")]
    [Description("Flip a coin")]
    public static async ValueTask CoinFlip(CommandContext ctx)
    {
        string answer = Random.Shared.Next(2) == 0
            ? "Heads" 
            : "Tails";
        
        var embedBuilder = new DiscordEmbedBuilder()
            .WithColor(DiscordColor.Gold)
            .WithTitle("Coin flip :coin:")
            .WithDescription($"It's {answer}!");

        await ctx.RespondAsync(embedBuilder.Build());
    }
}