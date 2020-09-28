using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace VotingSystem.Handlers
{
    class Player
    {
        public void OnLeft(LeftEventArgs ev)
        {
            string LeftMessage = DupecToolbox.Instance.Config.LeftBroadcastMessage.Replace("{player}",ev.Player.Nickname);
            bool enabled = DupecToolbox.Instance.Config.LeftBroadcastEnabled;
            float durationmessage = DupecToolbox.Instance.Config.LeftBroadcastDuration;
            if (enabled == true)
            {
                Map.Broadcast(duration: 6, message: $""+LeftMessage);
            }
            Log.Info(message:LeftMessage);
            
            
        }

        public void OnJoin(JoinedEventArgs ev)
        {
            string JoinMessage = DupecToolbox.Instance.Config.JoinBroadcastMessage.Replace("{player}", ev.Player.Nickname);
            bool enabled = DupecToolbox.Instance.Config.JoinBroadcastEnabled;
            ushort durationmessage = DupecToolbox.Instance.Config.JoinBroadcastDuration;
            if (enabled == true)
            {
                ev.Player.Broadcast(durationmessage,JoinMessage);
            }
            Log.Info("Player: "+$"{ev.Player.Nickname} Joined the server.");
        }
    }
}
