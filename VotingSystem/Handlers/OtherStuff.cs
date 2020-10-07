using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using Exiled.Events.Handlers;
using PlayableScps;
using System;
using MEC;
using UnityEngine;
using UnityEngine.Networking;

namespace DupecToolbox.Handlers
{
    class OtherStuff
    {
        public static void SCP096Enrage (EnragingEventArgs ev)
        {
            if(ev.Scp096.Enraged)
            {
                ev.Scp096.SetMovementSpeed(125f);
                Log.Debug("SCP-096 Is going Enrage Mode.");
            }
            ev.Player.Energy = 300f;
            ev.Player.Broadcast(6,"<b> You are a target for <color=red>SCP-096</color>! </b>");
        }
    }
}
