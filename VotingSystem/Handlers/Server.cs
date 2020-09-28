using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem.Handlers
{
    class Server
    {
        public void WaitingForPlayers()
        {
            Log.Info(message:"Waiting for Players....");
        }
        public void RoundStarted()
        {
            string RoundMessage = DupecToolbox.Instance.Config.RoundStartMessage;
            bool enabled = DupecToolbox.Instance.Config.RoundStartBroadcast;
            ushort durationbroadcast = DupecToolbox.Instance.Config.RoundStartBroadcastDuration;
            if(enabled == true)
            {
                Map.Broadcast(duration: durationbroadcast, message: RoundMessage);
            }
            Log.Info(message: "Round Started");
        }
    }
}
