using _10_WeatherApp.Core;
using _10_WeatherApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

namespace _10_WeatherApp
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

        public ConditionsResult result = null;
        public void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                result = WeatherService.GetWeatherFor(SearchCriteria.Text);
                PrintResults();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input type.");
            }
        }


        private void PrintResults()
        {
            GeoLocation.Text = (result.current_observation.display_location.city + ", " + result.current_observation.display_location.state);
            LatitudeLongitude.Text = ("Latitude/Longitude: " + result.current_observation.display_location.latitude + "/" + result.current_observation.display_location.longitude);
            CurrentWeather.Text = result.current_observation.weather;
            ElevationValue.Text = ("Elevation: " + result.current_observation.display_location.elevation);
            LastUpdateValue.Text = result.current_observation.observation_time;

            if (!File.Exists(result.current_observation.icon))
            {
                using (var webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(result.current_observation.icon_url);
                    File.WriteAllBytes(result.current_observation.icon + ".gif", bytes);
                }
            }
            IconImage.Source = new BitmapImage(new Uri(result.current_observation.icon_url));

            Temperature.Text = ("Temperature: " + result.current_observation.temperature_string);
            FeelsLike.Text = ("Feels Like: " + result.current_observation.feelslike_string);
            WindType.Text = ("Wind: " + result.current_observation.wind_string);
            WindDirection.Text = ("Wind Direction: " + result.current_observation.wind_dir);
            Humidity.Text = ("Humidity: " + result.current_observation.relative_humidity);
            Visibility.Text = ("Visibility: " + result.current_observation.visibility_mi + " miles");
            UV.Text = ("UV: " + result.current_observation.UV);
            Precipitation.Text = ("Precipitation: " + result.current_observation.precip_today_string);
        }


        // how to load images
        // create an image in XAML
        // 

        // how to separate API call code from WPF code
    }
}
