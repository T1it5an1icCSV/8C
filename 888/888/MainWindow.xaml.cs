using System;
using System.IO;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _888
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ser_Button_Click(object sender, RoutedEventArgs e)
        {
            string textToSerialize = inputText.Text;
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string jsonFilePath = Path.Combine(desktopPath, "SerializationText.json");

            File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(textToSerialize));

            inputText.Text = "";
        }

        private void Des_Button_Click(object sender, RoutedEventArgs e)
        {
            string jsonFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SerializationText.json");

            if (File.Exists(jsonFilePath))
            {
                string deserializedText = File.ReadAllText(jsonFilePath);
                if (!string.IsNullOrEmpty(deserializedText))
                {
                    outputText.Text = deserializedText; 
                }
            }
            else
            {
                MessageBox.Show("Файл не найден.");
            }
        }


        private void LightTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"\Themes\Light.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void DarkTheme_Button_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"\Themes\Dark.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (inputText.Text == "Введите текст...")
            {
                inputText.Text = "";
                inputText.Foreground = Brushes.Black; 
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputText.Text))
            {
                inputText.Text = "Введите текст...";
                inputText.Foreground = Brushes.Gray; 
            }
        }


    }
}

