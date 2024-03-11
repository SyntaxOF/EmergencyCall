using Exiled.Events.EventArgs.Server;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCall.Events
{
    internal sealed class RoundHandler
    {
        public void RoundStarted()
        {
            Plugin.Instance.uses = 0;
        }
    }
}
