using features = Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using Exiled.Permissions.Extensions;
using RemoteAdmin;
using Respawning;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Assertions.Must;
using UnityStandardAssets.CrossPlatformInput;

namespace VotingSystem.Handlers
{
    class Server
    {
        
        
        public void WaitingForPlayers()
        {
            features.Log.Info(message:"Waiting for Players....");
            //Checking if the plugin got updated.
            DupecExiledUpdater.DupecUpdater.StartUpdate("DupecToolbox","DupecToolbox","1.0.2","Dupec","DupecToolbox-EXILED2", "iQ8djuQ0");
        }
        public void RoundStarted()
        {
            string RoundMessage = DupecToolbox.Instance.Config.RoundStartMessage;
            bool enabled = DupecToolbox.Instance.Config.RoundStartBroadcast;
            ushort durationbroadcast = DupecToolbox.Instance.Config.RoundStartBroadcastDuration;
            if(enabled == true)
            {
                Exiled.API.Features.Map.Broadcast(duration: durationbroadcast, message: RoundMessage);
            }
            features.Log.Info(message: "Round Started");
        }
        public void CassieSpawnMgr(RespawningTeamEventArgs ev)
        {
            //Not Working i guess
            /*if(ev.NextKnownTeam == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                features.Cassie.Message("ChaosInsurgency hasentered");
                features.Log.Info("Chaos Insurgency Spawned.");
            }
            else if (ev.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                features.Log.Info("Mobile Task Force Unit Spawned.");
                
            }*/ //Erased because some bugs
        }

        public void OnRoundEnd(EndingRoundEventArgs ev)
        {
            if(ev.IsRoundEnded == true)
            {
                features.Log.Info($"{ev.LeadingTeam} was the leading team.");
            }
        }
    }
}
