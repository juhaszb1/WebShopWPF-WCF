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
using ServiceReference1;

namespace WebShopWPF_WCF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static Service1Client client = new Service1Client();
        public MainWindow()
        {
            InitializeComponent();
            List<Felhasznalo> felhasznalo = client.FelhasznaloLista_CS().ToList();
            Felhasznalo_adatok.ItemsSource = felhasznalo;
        }

        private void Felhasznalo_kivalaszt(object sender, EventArgs e)
        {
            Felhasznalo felhasznalo = (Felhasznalo)Felhasznalo_adatok.SelectedItem;
            if (felhasznalo != null)
            {
                Txb_Id.Text = felhasznalo.Id.ToString();
                Txb_LoginNev.Text = felhasznalo.LoginNev;
                Txb_HASH.Text = felhasznalo.HASH;
                Txb_SALT.Text = felhasznalo.SALT;
                Txb_Nev.Text = felhasznalo.Nev;
                Txb_Jog.Text = felhasznalo.Jog.ToString();
                Txb_Aktiv.Text = felhasznalo.Aktiv.ToString();
                Txb_Email.Text = felhasznalo.Email;
                Txb_ProfilKep.Text = felhasznalo.ProfilKep;
            }
        }

        private void Btn_Hozzaadas_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = new Felhasznalo();
            felhasznalo.Id = int.Parse(Txb_Id.Text);
            felhasznalo.LoginNev = Txb_LoginNev.Text;
            felhasznalo.HASH = Txb_HASH.Text;
            felhasznalo.SALT = Txb_SALT.Text;
            felhasznalo.Nev = Txb_Nev.Text;
            felhasznalo.Jog = byte.Parse(Txb_Jog.Text);
            felhasznalo.Aktiv = bool.Parse(Txb_Aktiv.Text);
            felhasznalo.Email = Txb_Email.Text;
            felhasznalo.ProfilKep = Txb_ProfilKep.Text;

            client.FelhasznaloHozzaAd_CS(felhasznalo);
        }

        private void Btn_Modositas_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = new Felhasznalo();
            felhasznalo.Id = int.Parse(Txb_Id.Text);
            felhasznalo.LoginNev = Txb_LoginNev.Text;
            felhasznalo.HASH = Txb_HASH.Text;
            felhasznalo.SALT = Txb_SALT.Text;
            felhasznalo.Nev = Txb_Nev.Text;
            felhasznalo.Jog = byte.Parse(Txb_Jog.Text);
            felhasznalo.Aktiv = bool.Parse(Txb_Aktiv.Text);
            felhasznalo.Email = Txb_Email.Text;
            felhasznalo.ProfilKep = Txb_ProfilKep.Text;

            client.FelhasznaloModosit_CS(felhasznalo);
        }

        private void Btn_Torles_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo felhasznalo = new Felhasznalo();
            felhasznalo.Id = int.Parse(Txb_Id.Text);

            client.FelhasznaloTorles_CS((int)felhasznalo.Id);
        }

        private void Btn_Frissites_Click(object sender, RoutedEventArgs e)
        {
            Felhasznalo_adatok.ItemsSource = client.FelhasznaloLista_CS().ToList();
        }
    }
}
