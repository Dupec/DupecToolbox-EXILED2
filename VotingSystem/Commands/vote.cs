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
    class vote : ICommand
    {
        public string Command { get; } = "vote";

        public string[] Aliases { get; } = { "" };

        public string Description { get; } = "A command that throws C.A.S.S.I.E. to say a fake MTF spawn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            
            if (sender is PlayerCommandSender player)
            {
                response = "Playing Fake MTF Spawn.";
                Log.Info($"Used FakeMTF command by {player.Nickname}");
                sendCassie();
                return false;
            }
            else
            {
                response = "Playing Fake MTF Spawn.";
                Log.Info("Used FakeMTF command in console.");
                sendCassie();
                return true;
            }
        }
        public void sendCassie()
        {
            Random rnd = new Random();
            int natoTeam = rnd.Next(1, 25);
            string natoString = "NINETAILEDFOX";
            int natoNumber = rnd.Next(1, 15);
            switch(natoTeam)
            {
                case 1:
                    natoString = "NATO_Q";
                    break;
                case 2:
                    natoString = "NATO_A";
                    break;
                case 3:
                    natoString = "NATO_Z";
                    break;
                case 4:
                    natoString = "NATO_W";
                    break;
                case 5:
                    natoString = "NATO_S";
                    break;
                case 6:
                    natoString = "NATO_X";
                    break;
                case 26:
                    natoString = "NATO_E";
                    break;
                case 7:
                    natoString = "NATO_D";
                    break;
                case 8:
                    natoString = "NATO_C";
                    break;
                case 9:
                    natoString = "NATO_R";
                    break;
                case 10:
                    natoString = "NATO_F";
                    break;
                case 11:
                    natoString = "NATO_V";
                    break;
                case 12:
                    natoString = "NATO_T";
                    break;
                case 13:
                    natoString = "NATO_G";
                    break;
                case 14:
                    natoString = "NATO_B";
                    break;
                case 15:
                    natoString = "NATO_Y";
                    break;
                case 16:
                    natoString = "NATO_H";
                    break;
                case 17:
                    natoString = "NATO_N";
                    break;
                case 18:
                    natoString = "NATO_U";
                    break;
                case 19:
                    natoString = "NATO_J";
                    break;
                case 20:
                    natoString = "NATO_M";
                    break;
                case 21:
                    natoString = "NATO_I";
                    break;
                case 22:
                    natoString = "NATO_K";
                    break;
                case 23:
                    natoString = "NATO_O";
                    break;
                case 24:
                    natoString = "NATO_L";
                    break;
                case 25:
                    natoString = "NATO_P";
                    break;


            }
            
            Cassie.Message("MTFUNIT epsilon 11 designated "+natoString+" "+natoNumber +" hasentered allremaining awaitingrecontainment 9 9 9 scpsubjects");
        }
    }
}
