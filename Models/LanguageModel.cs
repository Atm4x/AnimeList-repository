﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LanguageClassTest.Models
{
    public class Field<T>
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public T Value { get; set; }

        public static implicit operator Field<T>(T value)
        {
            return new Field<T> { Value = value};
        }

        public static implicit operator Field<T>((string, T) value)
        {
            return new Field<T> { Name = value.Item1, Value = value.Item2 };
        }

        public static explicit operator T(Field<T> field)
        {
            return field.Value;
        }
    }

    public class LanguageModel
    {

        [XmlElement("Language")]
        public Field<string> LanguageName { get; set; } = "Русский";

        [XmlElement("LanguageCode")]
        public Field<string> Code { get; set; } = "ru-RU";


        [XmlElement("ControlWindowName")]
        public Field<string> ControlWindowTitle { get; set; } = "AniList: Главное окно";

        [XmlElement("AddWindowName")]
        public Field<string> AddWindowTitle { get; set; } = "AniList: Добавить аниме";

        [XmlElement("AddWindowDialogTranslate")]
        public AddWindowDialogMessages AddWindowDialogTranslate { get; set; } = new AddWindowDialogMessages();


        [XmlElement("AddTabWindowName")]
        public Field<string> AddTabChooseWindowTitle { get; set; } = "AniList: Добавить список";


        [XmlElement("AddTabWindowDialogTranslate")]
        public AddTabChooseWindowDialogMessages AddTabWindowDialogTranslate { get; set; } = new AddTabChooseWindowDialogMessages();

        [XmlElement("SettingsWindowName")]
        public Field<string> SettingsWindowTitle { get; set; } = "AniList: Настройки";

        [XmlElement("SettingsWindowMessages")]
        public SettingsWindowMessages SettingsWindowMessagesTranslate { get; set; } = new SettingsWindowMessages();

        [XmlElement("HistoryWindowTitle")]
        public Field<string> HistoryWindowTitle { get; set; } = "AniList: История изменений";

        [XmlElement("HistoryWindowActions")]
        public ActionMessages HistoryWindowActionsTranslate { get; set; } = new ActionMessages();

        [XmlElement("ThemesTitles")]
        public ThemesTitles ThemesTitlesTranslate { get; set; } = new ThemesTitles();

        [XmlElement("ControlWindowMessages")]
        public ControlWindowMessages ControlWindowMessagesTranslate { get; set; } = new ControlWindowMessages();

        [XmlArray()]
        public List<Field<string>> Translate { get; set; } =
        new List<Field<string>>
        {
            ("AddModelButton", "Добавить"),
            ("RemoveModelButton", "Удалить"),
            ("EditModelButton", "Редактировать"),
            ("CopyModelsButton", "Копировать"),
            ("ExportModelsButton", "Экспорт"),
            ("ExtraControlButton", "Дополнительные"),
            ("EditingNameBlock", "Название"),
            ("EditingPlaceBlock", "Место"),
            ("EditingWatchedBlock", "Просмотрено: "),
            ("EditingSaveChangesButton", "Сохранить"),
            ("CopiedPopupMessage", "Скопировано"),
            ("SynchronizeBackButton", "Назад"),
            ("SynchronizePageTitle", "Синхронизация по Wi-Fi"),
            ("SynchronizePageHelp", "Для синхронизации по Wi-Fi требуется подключение к общей сети. Для подключения введите следующий код на втором устройстве:"),
            ("SynchronizePageOtherwise", "Или же, введите уже имеющийся код в поле ниже:"),
            ("SynchronizePageEnterButton", "Ввести"),
            ("ExtraSynchronizeContextItem", "Синхронизация"),
            ("ChangeLanguageItem", "Смена языка"),
            ("CreateNewListButton", "Создать список"),
            ("OpenListButton", "Открыть существующий"),
            ("SettingContextItem", "Настройки"),
            ("HistoryOfChanges", "История изменений"),
            ("GeneralSettingsTitle", "Общие настройки"),
            ("HistoryChangesTitle", "История изменений за сессию"),
            ("TopTitle", "Топы"),
            ("FindingByNameText", "Поиск по названию:"),
            ("FoundCountText", "Найдено соответветствий: 0"),
            ("CommentEditBlock", "Комментарий:")
        };

        public class ControlWindowMessages
        {
            public string FoundCountText { get; set; } = "Найдено соответветствий";
        }
        public class SettingsWindowMessages
        {
            public string General { get; set; } = "Общие";
        }

        public class ActionMessages
        {
            public string AddMessage { get; set; } = "Добавление аниме";
            public string RemoveMessage { get; set; } = "Удаление аниме";
            public string EditMessage { get; set; } = "Изменение аниме";
            public string WiFiMessage { get; set; } = "Синхронизация по Wi-Fi";
        }

        public class ThemesTitles
        {
            public string DarkTheme { get; set; } = "Тёмная тема";
            public string LightTheme { get; set; } = "Светлая тема";
            public string USSRTheme { get; set; } = "Тема СССР";
            public string WaterfallTheme { get; set; } = "Тема водопада";
            public string LoveTheme { get; set; } = "Любовная тема";
            public string JungleTheme { get; set; } = "Тема джунглей";
            public string DesertTheme { get; set; } = "Тема пустыни";
            public string SunsetTheme { get; set; } = "Тема восхода";
            public string OceanTheme { get; set; } = "Тема океана";
            public string AutumnTheme { get; set; } = "Тема осени";
            public string SpaceTheme { get; set; } = "Тема космоса";
            public string ForestTheme { get; set; } = "Тема леса";
            public string IceTheme { get; set; } = "Тема льда";
            public string CandyTheme { get; set; } = "Конфетная тема";
            public string RetroTheme { get; set; } = "Ретро тема";
            public string NeonTheme { get; set; } = "Неоновая тема";
            public string GalaxyTheme { get; set; } = "Галактическая тема";
            public string RainbowTheme { get; set; } = "Радужная тема";
            public string FireTheme { get; set; } = "Тема огня";
            public string NatureTheme { get; set; } = "Тема природы";
            public string NightTheme { get; set; } = "Ночная тема";
            public string SnowTheme { get; set; } = "Снежная тема";
            public string CyberpunkTheme { get; set; } = "Киберпанк тема";
            public string SteampunkTheme { get; set; } = "Стимпанк тема";
            public string MysticalForestTheme { get; set; } = "Тема таинственного леса";
            public string SamuraiTheme { get; set; } = "Самурайская тема";
        }

        public class AddWindowDialogMessages
        {
            public string ErrorMessage { get; set; } = "Ошибка";
            public string InputNameMessage { get; set; } = "Не введено название";
            public string InputPlaceMessage { get; set; } = "Не введено место";
            public string InputExistsMessage { get; set; } = "Введёное название уже присутствует в строке ";
        }
        public class AddTabChooseWindowDialogMessages
        {
            public string WarningMessage { get; set; } = "Внимание!";
            public string ExistsMessage { get; set; } = "Этот список уже находится в AniList";
        }

    }

}
