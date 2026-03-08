using Exiled.API.Interfaces;
using PlayerRoles;
using ScpProximityChat.Enums;
using System.Collections.Generic;
using System.ComponentModel;

namespace ScpProximityChat
{
    public class Config : IConfig
    {
        [Description("Включен ли плагин.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Включен ли режим отладки (debug).")]
        public bool Debug { get; set; } = false;

        [Description("Тип активации: ServerSpecificSettings (настройки в меню игры) или NoClip (клавиша прохождения сквозь стены).")]
        public ActivationType ActivationType { get; set; } = ActivationType.ServerSpecificSettings;

        [Description("Роли SCP, которые могут использовать голосовой чат.")]
        public HashSet<RoleTypeId> ScpRoles { get; set; } = new HashSet<RoleTypeId>()
        {
             RoleTypeId.Scp049,
             RoleTypeId.Scp0492,
             RoleTypeId.Scp096,
             RoleTypeId.Scp106,
             RoleTypeId.Scp173,
             RoleTypeId.Scp939,
        };

        [Description("Если false, SCP не будут слышать игроков с включенным прокси-чатом, пока не окажутся рядом.")]
        public bool UseDefaultScpChat { get; set; } = true;

        [Description("Громкость голоса.")]
        public float Volume { get; set; } = 10f;

        [Description("Расстояние, на котором звук слышен на полной громкости.")]
        public float MinDistance { get; set; } = 2f;

        [Description("Максимальная дистанция слышимости через голосовой чат.")]
        public float MaxDistance { get; set; } = 10f;

        [Description("Подсказка, отображаемая, когда SCP включает свой голосовой чат.")]
        public Message ProximityChatEnabled { get; set; } = new Message
        {
            Type = MessageType.Hint,
            Content = "<b>Голосовой чат <color=green>включен</color>.</b>",
            Duration = 3,
            Show = true,
        };

        [Description("Подсказка, отображаемая, когда SCP выключает свой голосовой чат.")]
        public Message ProximityChatDisabled { get; set; } = new Message
        {
            Type = MessageType.Hint,
            Content = "<b>Голосовой чат <color=red>выключен</color>.</b>",
            Duration = 3,
            Show = true,
        };

        public Message ProximityChatRole { get; set; } = new Message
        {
            Type = MessageType.Broadcast,
            Content = "<b>Вы можете переключать голосовой чат клавишей, заданной в настройках.</b>",
            Duration = 10,
            Show = true,
        };

        [Description("Заголовок категории в настройках игры.")]
        public string SettingHeaderLabel { get; set; } = "Голосовой чат SCP";

        [Description("Уникальный ID настройки.")]
        public int KeybindId { get; set; } = 200;

        [Description("Название настройки клавиши (отображается в меню).")]
        public string KeybindLabel { get; set; } = "Переключить чат SCP";

        [Description("Подсказка для клавиши, дающая дополнительную информацию.")]
        public string KeybindHint { get; set; } = "Переключает бесконтактный голосовой чат SCP.";
    }

    public class Message
    {
        public MessageType Type { get; set; }
        public string Content { get; set; }
        public ushort Duration { get; set; }
        public bool Show { get; set; }
    }
}