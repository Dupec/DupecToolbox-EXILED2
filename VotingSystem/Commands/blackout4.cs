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
    class blackout4 : ICommand
    {
        public string Command { get; } = "BlackoutInfinite";

        public string[] Aliases { get; } = { "blackoutinf" };

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
            bool enabled = DupecToolbox.Instance.Config.SpookyBroadcastEnabled;
            string message = DupecToolbox.Instance.Config.SpookyBroadcastMessage;
            ushort durationmsg = DupecToolbox.Instance.Config.SpookyBroadcastDuration;
            if(enabled == true)
            {
                Exiled.API.Features.Map.Broadcast(durationmsg, message);
            }
            Exiled.API.Features.Map.TurnOffAllLights(784892f, false);
        }
    }
}
