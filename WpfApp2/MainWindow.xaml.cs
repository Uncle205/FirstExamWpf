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
using System.Net;
using System.Xml;
using Newtonsoft.Json;


namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Item Item { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Window();
        }
        private void Window()
        {

            string data;
            WebClient webClient = new WebClient();
            
            data=webClient.DownloadString( "https://www.nationalbank.kz/rss/rates_all.xml");

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);
            XmlNode xml = xmlDocument.DocumentElement;
            string json = JsonConvert.SerializeXmlNode(xml);
            var welcome = Welcome.FromJson(json);
            Exchange.ItemsSource = welcome.Rss.Channel.Item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
