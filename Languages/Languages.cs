using System.Globalization;

namespace ToolScope.WPF.Languages
{
    internal static class Languages
    {
        public static void SetLanguage(string culture)
        {
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.SetCurrentThreadCulture = true;
            WPFLocalizeExtension.Engine.LocalizeDictionary.Instance.Culture = new CultureInfo(culture);
        }
    }
}
