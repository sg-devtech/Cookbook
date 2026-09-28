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
            Zutat11.Visibility = anzahl >= 11 ? Visibility.Visible : Visibility.Hidden;
            Zutat12.Visibility = anzahl >= 12 ? Visibility.Visible : Visibility.Hidden;
            Zutat13.Visibility = anzahl >= 13 ? Visibility.Visible : Visibility.Hidden;
            Zutat14.Visibility = anzahl >= 14 ? Visibility.Visible : Visibility.Hidden;
            Zutat15.Visibility = anzahl >= 15 ? Visibility.Visible : Visibility.Hidden;
            Zutat16.Visibility = anzahl >= 16 ? Visibility.Visible : Visibility.Hidden;
            Zutat17.Visibility = anzahl >= 17 ? Visibility.Visible : Visibility.Hidden;


        }
        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            AddIngredients();
            if (AnzahlZutaten == null || string.IsNullOrWhiteSpace(AnzahlZutaten.Text))
                return;
            if (!int.TryParse(AnzahlZutaten.Text, out int anzahl))
                return;

            Recepts NeuesRezept = new Recepts();
            if (AnzahlZutaten != null || Zutat1 != null || Zutat2 != null || Zutat3 != null || Zutat4 != null || Zutat5 != null || Zutat6 != null
                || Zutat7 != null || Zutat8 != null || Zutat9 != null || Zutat10 != null || Zutat11 != null || Zutat12 != null || Zutat13 != null
                || Zutat14 != null || Zutat15 != null || Zutat16 != null || Zutat17 != null)
            {

                NeuesRezept.AnzahlderZutaten = Convert.ToInt32(AnzahlZutaten.Text);

                Console.WriteLine(NeuesRezept.AnzahlderZutaten);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                StreamWriter sr = new StreamWriter(path + "/Cookbook/Rezepte");
                sr.WriteLine(NeuesRezept.AnzahlderZutaten);


                for (int i = 0; i < NeuesRezept.AnzahlderZutaten + 1; i++)
                {
                    var element = FindName($"Zutat{i}") as TextBox;

                    if (element == null)
                    {
                        continue;
                    }
                    string xy = element.Text.ToString();
                    NeuesRezept.Materials.Add(xy);
                    sr.WriteLine(xy);
                }
                sr.Close();
            }

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


    
      public void AddIngredients()
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Ingredients.Text = DescriptionBox.Text;
                File.AppendAllText(path + "/Cookbook/Description", Ingredients.Text + Environment.NewLine);
            }
        }
    }
} //Es wäre wahrscheinlich besser mit json.