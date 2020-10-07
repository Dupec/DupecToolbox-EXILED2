using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DupecToolbox.Commands.uselessStuff
{
    class allcommands : ICommand
    {
        public string Command { get; } = "dupec_fakemtf";

        public string[] Aliases { get; } = { "dupec_startvote", "dupec_vote_yes", "dupec_blackout" };

        public string Description => throw new NotImplementedException();

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            throw new NotImplementedException();
        }
    }
}
