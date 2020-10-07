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

        [Description("Messages when someone escapes (ClassD/Scientists) ONLY BROADCASTS TO THE PLAYER WHO ESCAPED")]
        public bool EscapeBroadcasts { get; set; } = true;
        public ushort EscapeBroadcastsDuration { get; set; } = 7;
        public string ClassD_Broadcast_Escape_Chaos { get; set; } = "<i>You escaped as a Class-D and becomed Chaos.</i>";
        public string ClassD_Broadcast_Escape_NTF { get; set; } = "<i>You were captured by the MTF and becomed NTF Cadet.</i>";
        public string Scientist_Broadcast_Escape_NTF { get; set; } = "<i>You escaped as a Scientist and becomed NTF Scientist.</i>";
        public string Scientist_Broadcast_Escape_Chaos { get; set; } = "<i>You were captured by a Chaos Insurgent and joined the Chaos Insurgency.</i>";
        [Description("This broadcasts when someone gets demoted/promoted")]
        public bool promotion_enabled { get; set; } = true;
        public bool demotion_enabled { get; set; } = true;
        public ushort MessagesDuration { get; set; } = 7;
        public string DemotionNTFLieutenant { get; set; } = "<i>You have been Demoted to NTF-Lieutenant.</i>";
        public string PromotionNTFLieutenant { get; set; } = "<i>You have been Promoted to NTF-Lieutenant.</i>";
        public string DemotionNTFCadet { get; set; } = "<i>You have been Demoted to NTF-Cadet.</i>";
        public string PromotionNTFCadet { get; set; } = "<i>You have been Promoted to NTF-Cadet.</i>";
        public string DemotionNTFFG { get; set; } = "<i>You have been Demoted to Facility Guard.</i>";
        [Description("Max Range of the Increase/Decrease Reputation Points [Example: 1 (MinRange) => 37 (MaxRange)]")]
        public int maxRange { get; set; } = 37;
        public int minRange { get; set; } = 1;
        public int MaxReputation { get; set; } = 400;
        public int MinReputation { get; set; } = 0;

    }
}
