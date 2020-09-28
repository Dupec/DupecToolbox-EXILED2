using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events;
using Exiled.API.Features;
using Exiled.Events.Commands;
using Exiled.Events.EventArgs;
using RemoteAdmin;
using Exiled.Events.Handlers;
using VotingSystem.Handlers;

namespace VotingSystem.Commands
{
    [CommandHandler(type: typeof(RemoteAdminCommandHandler))]
    class blackout3 : ICommand
    {
        public string Command { get; } = "BlackoutLarge";

        public string[] Aliases { get; } = { "blackoutxl" };

        public string Description { get; } = "A command that turns off the lights!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if(sender is PlayerCommandSender player)
            {
                response = "Haha lights go brrrrrrr";
                Log.Info($"Lights go brrrr, used by {player.Nickname}");
                sendCassie();
                return false;
            }
            else
            {
                response = "Haha lights go brrrrrrr";
                Log.Info("Lights go brrrr in console.");
                sendCassie();
                return true;
            }
        }
        public void sendCassie()
        {
            Exiled.API.Features.Map.TurnOffAllLights(60f, false);
        }
    }
}
