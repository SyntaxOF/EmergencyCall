using EmergencyCall.Events;
using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCall
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; } = null!;
        public override string Name => "EmergencyCall";
        public override string Author => "syntax_.os";
        public override Version RequiredExiledVersion => new Version(8, 8, 0);
        public override Version Version => new Version(1, 0, 0);
        public override PluginPriority Priority { get; } = PluginPriority.Low;

        public int uses;

        private RoundHandler roundHandler;
        public override void OnEnabled()
        {
            Instance = this;
            roundHandler = new RoundHandler();
            Exiled.Events.Handlers.Server.RoundStarted += roundHandler.RoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= roundHandler.RoundStarted;
            roundHandler = null;
            Instance = null!;
            base.OnDisabled();
        }
    }
}
