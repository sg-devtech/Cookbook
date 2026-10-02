using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Text.Json;

namespace Cookbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Recepts NeuesRezept = new Recepts();


        public MainWindow()
        {
            InitializeComponent();
            CreateFolder();

        }

        private void AnzahlZutaten_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (!int.TryParse(AnzahlZutaten.Text, out int anzahl))
            {
                return;

            }

            TopicLabel.Visibility = Visibility.Hidden;
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
            Zutat18.Visibility = anzahl >= 18 ? Visibility.Visible : Visibility.Hidden;
            
        }




        private void Save_Click(object sender, RoutedEventArgs e)
        {
           


            if (AnzahlZutaten == null || string.IsNullOrWhiteSpace(AnzahlZutaten.Text))
                return;
            if (!int.TryParse(AnzahlZutaten.Text, out int anzahl))
                return;




            NeuesRezept.AnzahlderZutaten = Convert.ToInt32(AnzahlZutaten.Text); //Die Anzahl der Zutaten

            Console.WriteLine(NeuesRezept.AnzahlderZutaten);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);



            for (int i = 0; i < NeuesRezept.AnzahlderZutaten + 1; i++)
            {
                if (NeuesRezept.Topic == NameOfTheRecept.Text)
                {
                    MessageBox.Show("Es existiert bereits ein Rezept mit diesem Namen. Bitte wählen Sie einen anderen Namen.");
                    return;

                }
                else { 
                var element = FindName($"Zutat{i}") as TextBox;

                if (element == null)
                {
                    continue;
                }
                string xy = element.Text.ToString();
                NeuesRezept.Materials.Add(xy);

            }
            }

            MessageBox.Show("Datei erfolgreich gespeichert");

            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                string path1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                NeuesRezept.Zubereitung = DescriptionBox.Text; //Die Beschreibung der Zutaten wird in die Textdatei geschrieben. //Hier muss mit json gearbeitet werden. Beschreibung der Zutaten..
            }
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                string path2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                NeuesRezept.Topic = NameOfTheRecept.Text; //der Name der Zutaten.
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(NeuesRezept, options);
                

                if (File.Exists(path2 + $"/Cookbook/{NeuesRezept.Topic}.json"))
                {
                    int counter = 1;
                    string newFilePath;
                    do
                    {
                        newFilePath = Path.Combine(path2 + "/Cookbook/", $"{NeuesRezept.Topic}_{counter}.json");
                        counter++;
                    } while (File.Exists(newFilePath));
                    File.WriteAllText(newFilePath, jsonString);
                }
                  else
                File.WriteAllText(path2 + $"/Cookbook/{NeuesRezept.Topic}.json", jsonString);
            }

        }
        private static void CreateFolder()
        {
            // Pfad zum Dokumenten-Ordner holen
            string dokumentePfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Ordnerpfad korrekt mit Path.Combine zusammenfügen
            string ordnerPfad = Path.Combine(dokumentePfad, "Cookbook/");

            // 1. Ordner erstellen (erstellt ihn nur, wenn er noch nicht existiert)
            Directory.CreateDirectory(ordnerPfad);

            // 2. Dateipfad für die Textdatei definieren


            Debug.WriteLine("Ordner und Datei wurden erfolgreich erstellt.");
        }




        private void Zutat1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void NewRecept_Click(object sender, RoutedEventArgs e)
        {
            Window main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void ReceptSearch_Click(object sender, RoutedEventArgs e)
        {
            string dokumentePfad = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Ordnerpfad korrekt mit Path.Combine zusammenfügen

            if(!File.Exists(Path.Combine(dokumentePfad, $"Cookbook/{NameOfTheRecept.Text}.json")))
            {
                MessageBox.Show("Es existiert kein Rezept mit diesem Namen. Bitte geben Sie einen gültigen Namen ein.");
                return;
            }
            string ordnerPfad = Path.Combine(dokumentePfad, $"Cookbook/{NameOfTheRecept.Text}.json");
            string jsonString = File.ReadAllText(ordnerPfad);
            Recepts recepts = JsonSerializer.Deserialize<Recepts>(jsonString);

            int anzahlZutaten = recepts.AnzahlderZutaten;
            string description = recepts.Zubereitung;
            string topic = recepts.Topic;

            AnzahlZutaten.Text = anzahlZutaten.ToString(); //Klappt
            Ingredients.Text = description.ToString();
            NameOfTheRecept.Text = topic.ToString();

            for(int i = 0; i < recepts.Materials.Count; i++)
            {
                var element = FindName($"Zutat{i + 1}") as TextBox;
                if (element != null)
                {
                    element.Text = recepts.Materials[i];
                }
            }
            DescriptionBox.Visibility = Visibility.Hidden;
            TopicLabel.Visibility = Visibility.Visible;

            MessageBox.Show($"Anzahl der Zutaten: {recepts.AnzahlderZutaten}\nTopic: {recepts.Topic}\nZubereitung: {recepts.Zubereitung}\nMaterials: {string.Join(", ", recepts.Materials)}");
        }
    } 
} 