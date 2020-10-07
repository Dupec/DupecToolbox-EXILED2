using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using Exiled.Permissions.Extensions;
using MEC;
using System;
using UnityEngine;
using VotingSystem.Handlers;
using GPlayer = Exiled.Events.Handlers.Player;
using iPlayer = Exiled.API.Features.Player;

namespace DupecToolbox.Commands
{
    class commands
    {
        public static void Commands(SendingRemoteAdminCommandEventArgs ev)
        {
            #region FakeMTF
            if (ev.Name == "dupec_fakemtf")
            {
                if (ev.Arguments.Count == 0)
                {
                    ev.ReplyMessage = "Missing Argument. FakeMTF [SCP Left]";
                }
                else
                {
                    if (ev.CommandSender.CheckPermission("dupec.fakemtfspawn"))
                    {
                        if (int.TryParse(ev.Arguments[0], out int a))
                        {
                            fakeMTF(a.ToString());
                            ev.Success = true;
                            ev.ReplyMessage = "Playing Fake Mobile Task Force spawn.";
                        }
                        else
                        {
                            ev.ReplyMessage = "That is even a number?";
                        }
                    }
                    else
                    {
                        ev.ReplyMessage = "Missing Permission! [dupec.fakemtfspawn]";
                    }
                }
            }
            #endregion
            #region Blackout
            if (ev.Name == "dupec_blackout")
            {
                if (ev.Arguments.Count < 1)
                {
                    ev.ReplyMessage = "Missing Argument. dupec_blackout (seconds)";
                }
                else
                {
                    if (ev.CommandSender.CheckPermission("dupec.blackout"))
                    {
                        if (int.TryParse(ev.Arguments[0], out int seconds))
                        {
                            Cassie.Message("facility Power System Failure in 3 . 2 . 1",false,false);
                            Timing.CallDelayed(4.4f, () =>
                            {
                                Exiled.API.Features.Map.TurnOffAllLights(seconds, false);
                                ev.ReplyMessage = $"Turned off lights for {seconds} seconds";
                                ev.Success = true;
                            });
                        }
                        else
                        {
                            ev.ReplyMessage = "Don't set up a <i>String</i> dumb lol";
                        }
                    }
                    else
                    {
                        ev.ReplyMessage = "Missing Permission! [dupec.blackout]";
                    }
                }
            }
            #endregion
            #region Testing Player Demotion
            if (ev.Name == "dupec_test_playerdemote")
            {
                if (ev.CommandSender.CheckPermission("dupec.testcommands"))
                {
                    if(ev.Sender.Role == RoleType.NtfCommander)
                    {
                        string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFLieutenant;
                        ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                        ev.Sender.Broadcast(time, message);
                        float x = ev.Sender.Position.x;
                        float y = ev.Sender.Position.y;
                        float z = ev.Sender.Position.z;
                        ev.Sender.SetRole(RoleType.Spectator);
                        ev.Sender.SetRole(RoleType.NtfLieutenant);
                        Timing.CallDelayed(0.4f, () =>
                        {
                            ev.Sender.Position = new UnityEngine.Vector3(x, y, z);
                        });
                    }
                    else if (ev.Sender.Role == RoleType.NtfLieutenant)
                    {
                        string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFCadet;
                        ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                        ev.Sender.Broadcast(time, message);
                        float x = ev.Sender.Position.x;
                        float y = ev.Sender.Position.y;
                        float z = ev.Sender.Position.z;
                        ev.Sender.SetRole(RoleType.Spectator);
                        ev.Sender.SetRole(RoleType.NtfCadet);
                        Timing.CallDelayed(0.4f, () =>
                        {
                            ev.Sender.Position = new UnityEngine.Vector3(x, y, z);
                        });
                    }
                    else if (ev.Sender.Role == RoleType.NtfCadet)
                    {
                        string message = VotingSystem.DupecToolbox.Instance.Config.DemotionNTFFG;
                        ushort time = VotingSystem.DupecToolbox.Instance.Config.MessagesDuration;
                        ev.Sender.Broadcast(time, message);
                        float x = ev.Sender.Position.x;
                        float y = ev.Sender.Position.y;
                        float z = ev.Sender.Position.z;
                        ev.Sender.SetRole(RoleType.Spectator);
                        ev.Sender.SetRole(RoleType.FacilityGuard);
                        Timing.CallDelayed(0.4f, () =>
                        {
                            ev.Sender.Position = new UnityEngine.Vector3(x, y, z);
                        });
                    }
                    else
                    {
                        ev.ReplyMessage = "You are not an NTF to recieve a demotion.";
                    }
                }
                else
                {
                    ev.ReplyMessage = "Missing Permission! [dupec.testcommands]";
                }
                
            }
            #endregion
            #region Teleport
            if (ev.Name == "dupec_teleport")
            {
                if (ev.CommandSender.CheckPermission("dupec.tp"))
                {
                    if (float.TryParse(ev.Arguments[0], out float xc))
                    {
                        if (float.TryParse(ev.Arguments[1], out float yc))
                        {
                            if (float.TryParse(ev.Arguments[2], out float zc))
                            {
                                ev.Sender.Position = new UnityEngine.Vector3(xc, yc, zc);
                                ev.Success = true;
                            }
                        }
                    }
                }
                else
                {
                    ev.ReplyMessage = "Missing Permission! [dupec.tp]";
                }

            }
            #endregion
            #region maxHealth
            if (ev.Name == "dupec_maxhealth")
            {
                if (ev.CommandSender.CheckPermission("dupec.hp"))
                {
                    if(int.TryParse(ev.Arguments[0], out int health))
                    {
                        if (int.TryParse(ev.Arguments[1], out int playerid))
                        {
                            iPlayer gPlayer = iPlayer.Get(playerid);
                            gPlayer.MaxHealth = health;
                            ev.Success = true;
                            ev.ReplyMessage = $"Set player {gPlayer.Nickname} [{playerid}] Max Health to {health}";
                        }
                    }
                }
                else
                {
                    ev.ReplyMessage = "Missing Permission! [dupec.hp]";
                }

            }
            #endregion
            #region Health
            if (ev.Name == "dupec_health")
            {
                if (ev.CommandSender.CheckPermission("dupec.hp"))
                {
                    if (int.TryParse(ev.Arguments[0], out int health))
                    {
                        if (int.TryParse(ev.Arguments[1], out int playerid))
                        {
                            iPlayer gPlayer = iPlayer.Get(playerid);
                            gPlayer.Health = health;
                            ev.Success = true;
                            ev.ReplyMessage = $"Set player {gPlayer.Nickname} [{playerid}] Health to {health}";
                        }
                    }
                }
                else
                {
                    ev.ReplyMessage = "Missing Permission! [dupec.hp]";
                }

            }
            #endregion
            #region Scale
            if (ev.Name == "dupec_scale")
            {
                
                if (ev.CommandSender.CheckPermission("dupec.scale"))
                {
                    if (float.TryParse(ev.Arguments[0], out float sizex))
                    {
                        if (float.TryParse(ev.Arguments[1], out float sizey))
                        {
                            if (float.TryParse(ev.Arguments[2], out float sizez))
                            {
                                if (int.TryParse(ev.Arguments[3], out int playerid))
                                {
                                    iPlayer gPlayer = iPlayer.Get(playerid);
                                    gPlayer.Scale = new Vector3(sizex,sizey,sizez);
                                    ev.Success = true;
                                    ev.ReplyMessage = $"Set player {gPlayer.Nickname} [{playerid}] Scale to X: {sizex}, Y: {sizey}, Z: {sizez}";
                                }
                            }
                        }
                    }
                }
                else
                {
                    ev.ReplyMessage = "Missing Permission! [dupec.scale]";
                }

            }
            #endregion
        }
        public static void fakeMTF(string scps)
        {
            System.Random rnd = new System.Random();
            int natoTeam = rnd.Next(1, 25);
            string natoString = "NINETAILEDFOX";
            int natoNumber = rnd.Next(1, 15);

            switch (natoTeam)
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
            if (scps == "0")
            {
                Cassie.Message("MTFUNIT epsilon 11 designated " + natoString + " " + natoNumber + " hasentered allremaining noscpsleft");
            }
            else
            {
                Cassie.Message("MTFUNIT epsilon 11 designated " + natoString + " " + natoNumber + " hasentered allremaining awaitingrecontainment " + scps + " scpsubjects");
            }
        }
    }
}
