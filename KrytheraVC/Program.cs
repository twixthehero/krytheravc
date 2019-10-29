using DSharpPlus;
using DSharpPlus.CommandsNext;
using System.IO;
using System.Threading.Tasks;

namespace KrytheraVC
{
    class Program
    {
        private const string DISCORD_TOKEN_FILE = "discord-token.txt";

        private static DiscordClient discord;
        private static CommandsNextModule commands;

        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = File.ReadAllText(DISCORD_TOKEN_FILE),
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
