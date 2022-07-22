using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Figure.Helper
{
    public class LocalizationProvider
    {
        public ResourceDictionary MainWindowResources { get; set; } = new ResourceDictionary();
        public Model.Localization CurrentLocalization { get; set; }

        public void ChangeLocalization(Model.Localization localization, ResourceDictionary resources)
        {
            MainWindowResources = resources;
            CurrentLocalization = localization;
            resources.MergedDictionaries.Clear();

            if (CurrentLocalization == Model.Localization.RU)
            {
                ApplyResources("Localization/Ru.xaml");
            }
            else
            {
                if (CurrentLocalization == Model.Localization.EN)
                    ApplyResources("Localization/En.xaml");
            }
        }

        private void ApplyResources(string path)
        {
            var dict = new ResourceDictionary() { Source = new Uri(path, UriKind.Relative)};
            foreach (var mergeDict in dict.MergedDictionaries)
            {
                MainWindowResources.MergedDictionaries.Add(mergeDict);
            }

            foreach (var key in dict.Keys)
            {
                MainWindowResources[key] = dict[key];
            }
        }
    }
}
