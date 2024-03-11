using CommandSystem;
using Exiled.API.Features;
using Exiled.Events;
using Exiled.Permissions.Extensions;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergencyCall.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class EmergencyCommand : ICommand
    {
        public string Command { get; } = "emergency";
        public string[] Aliases { get; } = new[] { "em" };
        public string Description { get; } = "Spawns a NTF wave imediately.";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("em.use"))
            {
                response = "You don't have permission to use this command.";
                return false;
            }
            Player player = Player.Get(sender);
            if (player.Role.Type != RoleTypeId.NtfCaptain)
            {
                response = "Nur der Capatain kann nach Verstärkung rufen.";
                return false;
            }
            if (Plugin.Instance.uses >= Plugin.Instance.Config.Uses)
            {
                response = "Die maximale Anzahl an Verstärkungen wurde für diese Runde bereits erreicht.";
                return false;
            }

            Respawn.ForceWave(Respawning.SpawnableTeamType.NineTailedFox);

            Plugin.Instance.uses++;
            response = "Die Verstärkung wurde gerufen.";
            return true;
        }
    }
}
