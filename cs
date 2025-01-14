using System.IO;
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

namespace Diakok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public struct Diakok
        {
            public string azonosito;
            public string osztaly;
            public string nev;
            public int pontszam;
        }
        List<Diakok> lista = new List<Diakok>();
        Diakok d= new Diakok();
        List<Diakok>aosztaly = new List<Diakok>();
        List<Diakok>bosztaly = new List<Diakok>();
        List<Diakok>cosztaly = new List<Diakok>();
        public MainWindow()
        {
            InitializeComponent();
            foreach (var i in File.ReadAllLines("diakok.txt").Skip(1))
            {
                string[] t = i.Split(';');
                d.azonosito = t[0];
                d.osztaly = t[1];
                d.nev = t[2];
                d.pontszam = Convert.ToInt32(t[3]);
                lista.Add(d);
            }
            aosztaly = lista.Where(x=>x.osztaly.Contains("a")).Select(x=>x).ToList();
            bosztaly = lista.Where(x=>x.osztaly.Contains("b")).Select(x=>x).ToList();
            cosztaly = lista.Where(x=>x.osztaly.Contains("c")).Select(x=>x).ToList();
        }

        private void beolvasas_Click(object sender, RoutedEventArgs e)
        {
            kilenc_a.Items.Clear();
            kilenc_b.Items.Clear();
            kilenc_c.Items.Clear();
            foreach (var i in aosztaly)
            {
                kilenc_a.Items.Add(i.nev);
            }
            foreach (var i in aosztaly)
            {
                kilenc_b.Items.Add(i.nev);
            }
            foreach (var i in aosztaly)
            {
                kilenc_c.Items.Add(i.nev);
            }
        }

        private void rendezes_Click(object sender, RoutedEventArgs e)
        {

            kilenc_a.Items.Clear();
            kilenc_b.Items.Clear();
            kilenc_c.Items.Clear();
            if (nevnovekvo.IsChecked == true)
            {
                var nev_a = aosztaly.OrderBy(x => x.nev).ToList();
                var nev_b = bosztaly.OrderBy(x => x.nev).ToList();
                var nev_c = cosztaly.OrderBy(x => x.nev).ToList();
                foreach (var i in nev_a)
                {
                    kilenc_a.Items.Add(i.nev);
                }
                foreach (var i in nev_b)
                {
                    kilenc_b.Items.Add(i.nev);

                }
                foreach (var i in nev_c)
                {
                    kilenc_c.Items.Add(i.nev);

                }
            }
            else
            {
                var pont_a = aosztaly.OrderBy(x => x.nev).ToList();
                var pont_b = bosztaly.OrderBy(x => x.nev).ToList();
                var pont_c = cosztaly.OrderBy(x => x.nev).ToList();
                foreach (var i in pont_a)
                {
                    kilenc_a.Items.Add(i.nev);
                }
                foreach (var i in pont_b)
                {
                    kilenc_b.Items.Add(i.nev);

                }
                foreach (var i in pont_c)
                {
                    kilenc_c.Items.Add(i.nev);

                }
            }
        }
        private void legjobbak_Click(object sender, RoutedEventArgs e)
        {

            legjobbak.Items.Clear();
            var pontnov_a = aosztaly.OrderBy(x=>x.pontszam).ToList();
            var pontnov_b = bosztaly.OrderBy(x=>x.pontszam).ToList();
            var pontnov_c = cosztaly.OrderBy(x=>x.pontszam).ToList();
            legjobb.Items.Add(pontnov_a.Last().nev+","+pontnov_a.Last().pontszam+","+pontnov_a.Last().osztaly);
            legjobb.Items.Add(pontnov_b.Last().nev+","+pontnov_b.Last().pontszam+","+pontnov_b.Last().osztaly);
            legjobb.Items.Add(pontnov_c.Last().nev+","+pontnov_c.Last().pontszam+","+pontnov_c.Last().osztaly);
        }

        private void legrosszabbak_Click(object sender, RoutedEventArgs e)
        {

        }

        private void kilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
