using LOLApi13A;
using LOLApi13A.models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LOLWpf13A
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await Program.LoadVersion();
            await LoadLanguage();
            await Program.LoadChampions();
            this.Title = $"Version: {Program.version}";
            /*lbNames.ItemsSource = Program.champions.Select(c => c.Name + " " + c.Title);*/

        }
            
        private async Task LoadLanguage()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    string url = "https://ddragon.leagueoflegends.com/cdn/languages.json";
                    var responseAPI = await client.GetStringAsync(url);
                    string[] response = JsonSerializer.Deserialize<string[]>(responseAPI);
                    cmbLanguage.ItemsSource = response;
                    cmbLanguage.SelectedIndex = 1;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine($"Kapcsolódási hiba: {httpEx.Message}");
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine($"JSON feldolgozási hiba: {jsonEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba: {ex.Message}");
            }
        }

        

        private async void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Program.LoadChampions(cmbLanguage.SelectedItem as string);
            lbNames.ItemsSource = Program.champions.Select(c => c.Name + " " + c.Title);

        }
        private async void lbNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}