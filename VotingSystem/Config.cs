using Exiled.API.Interfaces;
using System.ComponentModel;

namespace VotingSystem
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Broadcasts a message when someone leaves. the {player} will be replaced with the player name")]
        public bool LeftBroadcastEnabled { get; set; } = true;
        public ushort LeftBroadcastDuration { get; set; } = 5;
        public string LeftBroadcastMessage { get; set; } = "{player} left the server.";

        [Description("Broadcasts a message when the round starts")]
        public bool RoundStartBroadcast { get; set; } = true;
        public ushort RoundStartBroadcastDuration { get; set; } = 7;
        public string RoundStartMessage { get; set; } = "Get ready to <b><color=red>Die!</color></b>";

        [Description("Broadcasts a message when someone joins. the {player} will be replaced with the player name")]
        public bool JoinBroadcastEnabled { get; set; } = true;
        public ushort JoinBroadcastDuration { get; set; } = 5;
        public string JoinBroadcastMessage { get; set; } = "{player} Welcome to the server!";

        [Description("Broadcasts a message when the lights are turn off forever.")]
        public bool SpookyBroadcastEnabled { get; set; } = true;
        public ushort SpookyBroadcastDuration { get; set; } = 5;
        public string SpookyBroadcastMessage { get; set; } = "The lights were turn off forever <i>SpOoOoOkY!</i>";

    }
}
