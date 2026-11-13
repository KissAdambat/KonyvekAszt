using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KönyvekAszt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Konyv
    {
        public string Cim { get; set; }
        public string Szerzo { get; set; }
        public int Oldalszam { get; set; }
        public string Mufaj { get; set; }
        public bool Elerheto { get; set; }
    }
    public partial class MainWindow : Window
    {
        List<Konyv> lista = new List<Konyv>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBetoltes_Click(object sender, RoutedEventArgs e)
        {
            lista.Clear();
            lista.Add(new Konyv { Cim = "1984", Szerzo = "George Orwell", Oldalszam = 328, Mufaj = "Sci-fi", Elerheto = true });
            lista.Add(new Konyv { Cim = "A szolgálólány meséje", Szerzo = "Margaret Atwood", Oldalszam = 311, Mufaj = "Disztópia", Elerheto = false });
            lista.Add(new Konyv { Cim = "Az ember tragédiája", Szerzo = "Madách Imre", Oldalszam = 250, Mufaj = "Dráma", Elerheto = true });
            lista.Add(new Konyv { Cim = "Dűne", Szerzo = "Frank Herbert", Oldalszam = 604, Mufaj = "Sci-fi", Elerheto = true });
            lista.Add(new Konyv { Cim = "Egri csillagok", Szerzo = "Gárdonyi Géza", Oldalszam = 552, Mufaj = "Történelmi", Elerheto = false });

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = lista;
        }

        private void btnDarab_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Összesen " + lista.Count + " könyv van.");
        }

        private void btnLeghosszabb_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be a könyveket!");
                return;
            }

            Konyv legjobb = lista[0];
            foreach (Konyv k in lista)
            {
                if (k.Oldalszam > legjobb.Oldalszam)
                {
                    legjobb = k;
                }
            }
            MessageBox.Show("A leghosszabb könyv: " + legjobb.Cim + " (" + legjobb.Oldalszam + " oldal)");
        }

        private void btnAtlag_Click(object sender, RoutedEventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("Előbb töltsd be a könyveket!");
                return;
            }

            double osszeg = 0;
            foreach (Konyv k in lista)
            {
                osszeg += k.Oldalszam;
            }
            double atlag = osszeg / lista.Count;
            MessageBox.Show("Átlagos oldalszám: " + atlag.ToString("0.0"));
        }

        private void btnElerheto_Click(object sender, RoutedEventArgs e)
        {
            List<Konyv> elerhetok = new List<Konyv>();
            foreach (Konyv k in lista)
            {
                if (k.Elerheto)
                {
                    elerhetok.Add(k);
                }
            }

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = elerhetok;
        }

        private void btnCimek_Click(object sender, RoutedEventArgs e)
        {
            string cimek = "";
            foreach (Konyv k in lista)
            {
                cimek += k.Cim + "\n";
            }
            MessageBox.Show(cimek, "Címek");
        }

        private void btnRendezes_Click(object sender, RoutedEventArgs e)
        {
            lista.Sort((a, b) => a.Szerzo.CompareTo(b.Szerzo));

            dgKonyvek.ItemsSource = null;
            dgKonyvek.ItemsSource = lista;
        }
    }
}