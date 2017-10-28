using System;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace NeoSmart.Uwp
{
    class TaskBarIcon
    {
        public enum BadgeGlyph
        {
            None,
            Activity,
            Alarm,
            Alert,
            Attention,
            Available,
            Away,
            Busy,
            Error,
            NewMessage,
            Paused,
            Playing,
            Unavailable
        }

        private static void SetBadgeValue(string value)
        {
            var badgeXml = BadgeUpdateManager.GetTemplateContent(BadgeTemplateType.BadgeNumber);
            var badgeElement = (XmlElement)badgeXml.FirstChild;
            badgeElement.SetAttribute("value", value);

            var badge = new BadgeNotification(badgeXml);
            var badgeUpdater = BadgeUpdateManager.CreateBadgeUpdaterForApplication();

            badgeUpdater.Update(badge);
        }

        public static void SetBadgeGlyph(BadgeGlyph glyph)
        {
            var glyphText = glyph.ToString().ToCharArray();
            glyphText[0] = Char.ToLowerInvariant(glyphText[0]);
            SetBadgeValue(new string(glyphText));
        }

        public static void SetBadgeNumber(int number)
        {
            SetBadgeValue(number.ToString());
        }
    }
}
