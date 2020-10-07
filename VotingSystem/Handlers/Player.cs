using Exiled.Events.EventArgs;
using MEC;
using UnityEngine;
using Exiled.Events.Extensions;
using NorthwoodLib.Pools;
using RemoteAdmin;
using System.Collections.Generic;
using Exiled.API.Features;
using Dissonance;
using Exiled.API.Enums;

namespace VotingSystem.Handlers
{
    class Player
    {
        public static int playerExp = 100;
        public static int maxExp = DupecToolbox.Instance.Config.MaxReputation;
        public static int minExp = DupecToolbox.Instance.Config.MinReputation;
        public static int maxRange = DupecToolbox.Instance.Config.maxRange;
        public static int minRange = DupecToolbox.Instance.Config.minRange;
        public bool promotion_enabled = DupecToolbox.Instance.Config.promotion_enabled;
        public bool demotion_enabled = DupecToolbox.Instance.Config.demotion_enabled;

        public void OnLeft(LeftEventArgs ev)
        {
            string LeftMessage = DupecToolbox.Instance.Config.LeftBroadcastMessage.Replace("{player}", ev.Player.Nickname);
            bool enabled = DupecToolbox.Instance.Config.LeftBroadcastEnabled;
            float durationmessage = DupecToolbox.Instance.Config.LeftBroadcastDuration;
            if (enabled == true)
            {
                Exiled.API.Features.Map.Broadcast(duration: 6, message: $"" + LeftMessage);
            }
            Exiled.API.Features.Log.Info(message: LeftMessage);


        }

        public void OnJoin(JoinedEventArgs ev)
        {
            string JoinMessage = DupecToolbox.Instance.Config.JoinBroadcastMessage.Replace("{player}", ev.Player.Nickname);
            bool enabled = DupecToolbox.Instance.Config.JoinBroadcastEnabled;
            ushort durationmessage = DupecToolbox.Instance.Config.JoinBroadcastDuration;
            if (enabled == true)
            {
                ev.Player.Broadcast(durationmessage, JoinMessage);
            }
            Exiled.API.Features.Log.Info("Player: " + $"{ev.Player.Nickname} Joined the server.");
        }
        public void OnEscaping(EscapingEventArgs ev)
        {

        }
        public void onRoleChange(ChangingRoleEventArgs ev)
        {
            #region Escaping Broadcasts
            bool ebenabled = DupecToolbox.Instance.Config.EscapeBroadcasts;
            if (ebenabled == true)
            {
                RoleType ClassD = RoleType.ClassD;
                RoleType CHI = RoleType.ChaosInsurgency;
                RoleType SCI = RoleType.Scientist;
                RoleType NTFSCI = RoleType.NtfScientist;
                RoleType NTF = RoleType.NtfCadet;
                string SMessageChaos = DupecToolbox.Instance.Config.Scientist_Broadcast_Escape_Chaos;
                string SMessageNTF = DupecToolbox.Instance.Config.Scientist_Broadcast_Escape_NTF;
                string DMessageChaos = DupecToolbox.Instance.Config.ClassD_Broadcast_Escape_Chaos;
                string DMessageNTF = DupecToolbox.Instance.Config.ClassD_Broadcast_Escape_NTF;
                ushort duration = DupecToolbox.Instance.Config.EscapeBroadcastsDuration;
                if (ev.Player.Role == ClassD && ev.NewRole == CHI)
                {
                    ev.Player.Broadcast(duration, DMessageChaos);
                }
                if (ev.Player.Role == ClassD && ev.NewRole == NTF)
                {
                    ev.Player.Broadcast(duration, DMessageNTF);
                }
                if (ev.Player.Role == SCI && ev.NewRole == NTFSCI)
                {
                    ev.Player.Broadcast(duration, SMessageNTF);
                }
                if (ev.Player.Role == SCI && ev.NewRole == CHI)
                {
                    ev.Player.Broadcast(duration, SMessageChaos);
                }
            }
            #endregion
        }
        public void killing(DiedEventArgs ev)
        {
            DamageTypes.DamageType damage = ev.HitInformations.GetDamageType();
            if (ev.Target.IsNTF && ev.Killer.IsNTF)
            {
                System.Random rnd = new System.Random();
                int xp2add = rnd.Next(1, 37);
                playerExp -= xp2add;
                if (demotion_enabled)
                {
                    if (playerExp <= 0)
                    {
                        if (ev.Killer.Role == RoleType.NtfCommander)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFLieutenant;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfLieutenant);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfLieutenant)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFCadet;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfCadet);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfCadet)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFFG;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.FacilityGuard);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        playerExp = 100;
                    }
                }

            }
            else if (!ev.Target.IsNTF && ev.Killer.IsNTF)
            {
                System.Random rnd = new System.Random();
                int xp2add = rnd.Next(minRange, maxRange);
                playerExp += xp2add;
                if (promotion_enabled)
                {
                    if (playerExp >= maxExp)
                    {
                        if (ev.Killer.Role == RoleType.FacilityGuard)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.PromotionNTFCadet;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfCadet);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        else if (ev.Killer.Role == RoleType.NtfCadet)
                        {
                            string message = VotingSystem.DupecToolbox.Instance.Config.PromotionNTFLieutenant;
                            ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                            ev.Killer.Broadcast(time, message);
                            float x = ev.Killer.Position.x;
                            float y = ev.Killer.Position.y;
                            float z = ev.Killer.Position.z;
                            ev.Killer.SetRole(RoleType.Spectator);
                            ev.Killer.SetRole(RoleType.NtfLieutenant);
                            Timing.CallDelayed(0.4f, () =>
                            {
                                ev.Killer.Position = new UnityEngine.Vector3(x, y, z);
                            });
                        }
                        playerExp = 100;
                    }
                }
            }
        }
        public void OnSpawningRagdoll(SpawningRagdollEventArgs ev)
        {
            //This is made to help TypicalIllusion for his plugin.
            //This does not actually executes.
            RoomType[] _roomTypes = { RoomType.Hcz106, RoomType.Hcz939, RoomType.HczChkpA, RoomType.HczChkpB, RoomType.HczCrossing, RoomType.HczCurve, RoomType.HczEzCheckpoint };
            if(ev.HitInformations.GetDamageType() == DamageTypes.Pocket)
            {
                System.Random rnd = new System.Random();
                int _value = rnd.Next(0, _roomTypes.Length);
                foreach(Room room in Map.Rooms)
                {
                    if(room.Type == _roomTypes[_value])
                    {
                        float posx = room.Position.x;
                        float posy = room.Position.y + 2;
                        float posz = room.Position.z;
                        ev.Position = new Vector3(posx,posy,posz);
                        Exiled.API.Features.Log.Debug($"{ev.PlayerNickname} as {ev.Owner.Role} died by 106, Corpse teleported to: {posx}, {posy}, {posz}");
                    }
                }
            }
        }
    }
}