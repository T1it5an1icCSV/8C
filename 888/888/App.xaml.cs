using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace _888
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string theme;
        public static string Theme
        {
            get { return theme; }
            set
            {
                theme = value;
                var dict = new ResourceDictionary { Source = new Uri($"/StyleLib;component/Themes/{value}.xaml", UriKind.Relative) };

                Current.Resources.MergedDictionaries.RemoveAt(0);
                Current.Resources.MergedDictionaries.Insert(0, dict);

                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (File.Exists($"{desktop}\\theme.txt"))
                {
                    Theme = File.ReadAllText($"{desktop}\\theme.txt");
                }
            }
        }
    }
}

