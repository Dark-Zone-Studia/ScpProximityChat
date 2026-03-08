using Exiled.API.Extensions;
using Exiled.API.Features;
using PlayerRoles;
using ScpProximityChat.Enums;
using System;
using UserSettings.ServerSpecific;

namespace ScpProximityChat
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "ScpProximityChat";
        public override string Author { get; } = "ProstoSanya";
        public override Version Version { get; } = new Version(1, 0, 2);
        public override Version RequiredExiledVersion { get; } = new Version(9, 0, 0);

        private EventHandlers _eventHandlers;

        public override void OnEnabled()
        {
            Config.ScpRoles.RemoveWhere(role => !role.IsScp() || role == RoleTypeId.Scp079);

            _eventHandlers = new EventHandlers(Config);
            _eventHandlers.RegisterEvents();

            if (Config.ActivationType == ActivationType.ServerSpecificSettings)
            {
                SSGroupHeader header = new SSGroupHeader(Config.SettingHeaderLabel);

                SSKeybindSetting keybind = new SSKeybindSetting(Config.KeybindId, Config.KeybindLabel);

                ServerSpecificSettingsSync.DefinedSettings = new ServerSpecificSettingBase[]
                {
                    header,
                    keybind
                };
            }

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            _eventHandlers.UnregisterEvents();
            _eventHandlers = null;

            if (Config.ActivationType == ActivationType.ServerSpecificSettings)
            {
                ServerSpecificSettingsSync.DefinedSettings = null;
            }

            base.OnDisabled();
        }
    }
}