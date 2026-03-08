using System.Collections.Generic;
using Exiled.API.Features;
using VoiceChat.Codec;
using VoiceChat.Codec.Enums;

namespace ScpProximityChat
{
    public class OpusHandler
    {
        private static readonly Dictionary<Player, OpusHandler> Handlers = new Dictionary<Player, OpusHandler>();

        public OpusDecoder Decoder { get; } = new OpusDecoder();

        public OpusEncoder Encoder { get; } = new OpusEncoder(OpusApplicationType.Voip);

        public static OpusHandler Get(Player player)
        {
            if (Handlers.TryGetValue(player, out OpusHandler opusHandler))
                return opusHandler;

            opusHandler = new OpusHandler();
            Handlers.Add(player, opusHandler);
            return opusHandler;
        }

        public static void Remove(Player player)
        {
            if (Handlers.TryGetValue(player, out OpusHandler opusHandler))
            {
                opusHandler.Decoder.Dispose();
                opusHandler.Encoder.Dispose();

                Handlers.Remove(player);
            }
        }
    }
}