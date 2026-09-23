using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FolderAvailable();
            
        }

        private void AnzahlZutaten_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(AnzahlZutaten.Text, out int anzahl))
            {
                return;

            }

            Zutat1.Visibility = anzahl >= 1 ? Visibility.Visible : Visibility.Hidden;
            Zutat2.Visibility = anzahl >= 2 ? Visibility.Visible : Visibility.Hidden;
            Zutat3.Visibility = anzahl >= 3 ? Visibility.Visible : Visibility.Hidden;
            Zutat4.Visibility = anzahl >= 4 ? Visibility.Visible : Visibility.Hidden;
            Zutat5.Visibility = anzahl >= 5 ? Visibility.Visible : Visibility.Hidden;
            Zutat6.Visibility = anzahl >= 6 ? Visibility.Visible : Visibility.Hidden;
            Zutat7.Visibility = anzahl >= 7 ? Visibility.Visible : Visibility.Hidden;
            Zutat8.Visibility = anzahl >= 8 ? Visibility.Visible : Visibility.Hidden;
            Zutat9.Visibility = anzahl >= 9 ? Visibility.Visible : Visibility.Hidden;
            Zutat10.Visibility = anzahl >= 10 ? Visibility.Visible : Visibility.Hidden;


        }
        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Recepts NeuesRezept = new Recepts();
            if (AnzahlZutaten != null)
                NeuesRezept.AnzahlderZutaten = Convert.ToInt32(AnzahlZutaten.Text);

            for(int i = 0; i < NeuesRezept.AnzahlderZutaten; i++)

            {

                TextBox text = this.FindName("Zutat" + i) as TextBox;

                if(text != null)
                {
                    NeuesRezept.NamenDerZutaten[i] = text.Text;
                    Debug.WriteLine($"NeuesRezept.NamenDerZutaten: {i}");
                }
                Debug.WriteLine("GarNixGEht");
            }
 
            Console.WriteLine(NeuesRezept.AnzahlderZutaten);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); 
            StreamWriter sr = new StreamWriter(path + "/Cookbook/Rezepte");
            sr.WriteLine(NeuesRezept.AnzahlderZutaten);
            sr.Close();
        }

        private void FolderAvailable()
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                Debug.WriteLine("This is existing");
                return;
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Directory.CreateDirectory(path + "/Cookbook");
            File.Create(path + "/Cookbook/Rezepte");
        }


    }
}