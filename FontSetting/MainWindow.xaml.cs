using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FontSetting
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

        private void ComboBox_SelectionChangedColor(object sender, SelectionChangedEventArgs e)
        {
            if (textBlock == null) return;

            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            { 
                ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;
                if (item != null)
                {
                    switch (item.Content.ToString())
                    {
                        case "Красный": textBlock.Foreground = Brushes.Red; break;
                        case "Синий": textBlock.Foreground = Brushes.Blue; break;
                        case "Зелёный": textBlock.Foreground = Brushes.Green; break;
                        case "Коричневый": textBlock.Foreground = Brushes.Brown; break;
                        case "Чёрный": textBlock.Foreground = Brushes.Black; break;                       
                    }
                }
            }
            
        }


        private void RadioButton_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (textBlock == null) return;

            RadioButton checkBox = sender as RadioButton;
            if (checkBox != null)
            {
                if (Style.IsChecked == true)
                {
                    textBlock.FontStyle = FontStyles.Normal;
                }
                else 
                {
                    textBlock.FontStyle = FontStyles.Italic;
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null) return;

            ComboBoxItem cbi = comboBox.SelectedItem as ComboBoxItem;
            if (cbi == null) return;


            FontFamily = new FontFamily(cbi.Content as string);
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (textBlock == null) return;
            Slider slider = sender as Slider;
            if (slider != null) 
            {
                textBlock.FontSize = slider.Value;
            } 

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (textBlock == null) return;

            CheckBox checkBox = sender as CheckBox;
            if (checkBox != null)
            {
                if (checkBox.IsChecked == true)
                {
                    textBlock.FontWeight = FontWeights.Bold;
                    checkBox.Content = "Жирный";
                }
                else 
                {
                    textBlock.FontWeight = FontWeights.Normal;
                    checkBox.Content = "Обычный";
                }
            }
        }



        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton == null) return;

            int aling = 0;
            if (int.TryParse((string)radioButton.DataContext, out aling))
            {
                textBlock.TextAlignment = (TextAlignment)aling;
            }
        }
    }
}
