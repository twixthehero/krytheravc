using DSharpPlus;
using DSharpPlus.CommandsNext;
using System;
using System.IO;
using System.Threading.Tasks;

namespace KrytheraVC
{
    class Program
    {
        private const string DISCORD_TOKEN_FILE = "discord-token.txt";
        private const string DEFAULT_INVALID_TOKEN = "<YOUR TOKEN HERE>";

        private static DiscordClient discord;
        private static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string token = File.ReadAllText(DISCORD_TOKEN_FILE).Trim();

            if (token == DEFAULT_INVALID_TOKEN)
            {
                Console.WriteLine("Please specify your discord app developer token in `discord-token.txt`!");
                return;
            }

            discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = token,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });

            commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefix = "~"
            });

            commands.RegisterCommands<KrytheraCommands>();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
