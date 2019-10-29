using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace KrytheraVC
{
    public class KrytheraCommands
    {
        [Command("ss")]
        public async Task CreateVCLink(CommandContext ctx)
        {
            if (ctx.Member.VoiceState == null)
            {
                await ctx.RespondAsync("You must be in a voice channel to use this command!");
                return;
            }

            string link = $"https://discordapp.com/channels/{ctx.Guild.Id}/{ctx.Member.VoiceState.Channel.Id}";
            await ctx.RespondAsync($"Here ya go {ctx.User.Mention}! {link}");
        }
    }
}
