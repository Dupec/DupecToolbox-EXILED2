using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using GServer = Exiled.Events.Handlers.Server;
using GPlayer = Exiled.Events.Handlers.Player;
using SCP096Playable = PlayableScps.Scp096;
using DupecToolbox.Commands;
using DupecToolbox.Handlers;
using UnityEngine;

//The plugins was going to be a Voting system but then i decided that is going to be a toolbox.
namespace VotingSystem
{
    public class DupecToolbox : Plugin<Config>
    {
        
        private Handlers.Player player;
        private Handlers.Server server;
        public static string version = "v1.0.1"; //Useless

       
        public float SCP096speed = SCP096Playable.EnrageWalkSpeed; //Useless
        public float SCP096enragecooldown = SCP096Playable._enrageCooldown; //Useless
        public float SCP096chargecooldown = SCP096Playable._defaultChargeCooldown; //Useless


        private static readonly Lazy<DupecToolbox> LazyInstance = new Lazy<DupecToolbox>(valueFactory: () => new DupecToolbox());
        public static DupecToolbox Instance => LazyInstance.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private DupecToolbox()
        {

        }

        public override void OnEnabled()
        {

            Log.Info(message: $"DupecToolbox Enabled");
            registerEvents();
            
        }
        public override void OnDisabled()
        {
            Log.Info(message: "Bye Bye!");
            UnregisterEvents();
        }
        public void registerEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();

            GServer.WaitingForPlayers += server.WaitingForPlayers;
            GServer.RoundStarted += server.RoundStarted;
            GServer.RespawningTeam += server.CassieSpawnMgr;
            GServer.EndingRound += server.OnRoundEnd;
            GServer.SendingRemoteAdminCommand += commands.Commands;

            GPlayer.Left += player.OnLeft;
            GPlayer.Joined += player.OnJoin;
            GPlayer.Escaping += player.OnEscaping;
            GPlayer.ChangingRole += player.onRoleChange;

        }

        public void UnregisterEvents()
        {
            player = new Handlers.Player();
            server = new Handlers.Server();

            GServer.WaitingForPlayers -= server.WaitingForPlayers;
            GServer.RoundStarted -= server.RoundStarted;
            GServer.RespawningTeam -= server.CassieSpawnMgr;
            GServer.EndingRound -= server.OnRoundEnd;
            GServer.SendingRemoteAdminCommand -= commands.Commands;

            GPlayer.Left -= player.OnLeft;
            GPlayer.Joined -= player.OnJoin;
            GPlayer.Escaping -= player.OnEscaping;
            GPlayer.ChangingRole -= player.onRoleChange;


            player = null;
            server = null;
        }
    }
}