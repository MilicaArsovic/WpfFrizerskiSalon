using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfFrizerskiSalon.Forme;

namespace WpfFrizerskiSalon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool azuziraj;
        public static object pomocni;
        public static SqlConnection konekcija = Konekcija.KreirajKonekciju();

        private static void PocetniDataGrid(DataGrid grid)
        {
            try
            {
                konekcija.Open();

                string upit = @"select IDTermin as ID, Naziv as Termin,ImeKlijenta as 'Ime klijenta', ImeZap as Frizer,NazivUsluge as Usluga
                                from Termin inner join Klijent on Termin.IDKlijent = Klijent.IDKlijent
			                    inner join Zaposleni on Termin.IDZaposleni = Zaposleni.IDZaposleni
			                    inner join Usluga on Termin.IDUsluga = Usluga.IDUsluge;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                grid.ItemsSource = dt.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }

        }


        public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(dataGridCentralni);
        }

        private void btnZaposleni_Click(object sender, RoutedEventArgs e)
        {
            btnDodajZaposlenog.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniZaposlenog.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiZaposlenog.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select IDZaposleni as ID, ImeZap+ ' '+ PrezimeZap as 'Ime i prezime zaposlenog', BrojTelefona, JMBG, StalnoZaposlen as 'Stalno zaposlen'
                        from Zaposleni";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }

        }

        private void btnKlijent_Click(object sender, RoutedEventArgs e)
        {
            btnDodajKlijenta.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniKlijenta.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiKlijenta.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"Select IDKlijent as ID, ImeKlijenta +' '+ PrezimeKlijenta as 'Ime i prezime klijenta', Usluga, BrojTelefona as 'Broj telefona', JMBG, Frizer
                                from Klijent;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }


        }

        private void btnDobavljac_Click(object sender, RoutedEventArgs e)
        {
            btnDodajDobavljaca.Visibility = Visibility.Visible;

            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniDobavljaca.Visibility = Visibility.Visible;

            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiDobavljaca.Visibility = Visibility.Visible;

            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"Select IDDobavljac as ID, Naziv as 'Naziv dobavljača', Adresa, Pib
                                from Dobavljac;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }

        }

        private void btnUredjaj_Click(object sender, RoutedEventArgs e)
        {
            btnDodajUredjaj.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniUredjaj.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiUredjaj.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"Select IDUredjaj as ID, NazivUredjaja as 'Naziv uredjaja', Kolicina, Ispravnost 
                                from Uredjaji;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }

        }

        private void btnProizvod_Click(object sender, RoutedEventArgs e)
        {
            btnDodajProizvod.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniProizvod.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiProizvod.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"Select IDProizvoda as ID, NazivProizvoda as 'Naziv proizvoda', Kolicina
                                from Proizvodi;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }


        }

        private void btnNabavka_Click(object sender, RoutedEventArgs e)
        {
            btnDodajNabavku.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniNabavku.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiNabavku.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select IDNabavka as ID, Cena, Naziv as 'Naziv dobavljaca', NazivProizvoda as 'Naziv proizvoda'
	            from Nabavka inner join Dobavljac on Nabavka.IDDobavljac = Dobavljac.IDDobavljac
				inner join Proizvodi on Nabavka.IDProizvod = Proizvodi.IDProizvoda;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnUsluga_Click(object sender, RoutedEventArgs e)
        {
            btnDodajUslugu.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniUslugu.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiUslugu.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select IDUsluge as ID,NazivUsluge as 'Naziv usluge',NazivProizvoda as 'Naziv proizvoda',Cena,OpisUsluge as 'Opis usluge'
                from Usluga inner join Proizvodi on Usluga.IDProizvodi = Proizvodi.IDProizvoda
			    inner join [Vrsta usluge] on Usluga.IDVrstaUsluge = [Vrsta usluge].IDVrstaUsluge;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void btnVrstaUsluge_Click(object sender, RoutedEventArgs e)
        {
            btnDodajVrstuUsluge.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajTermin.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;

            btnIzmeniVrstuUSluge.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniTermin.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;

            btnObrisiVrstuUsluge.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiTermin.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select IDVrstaUsluge as ID,OpisUsluge as 'Opis usluge',NazivUredjaja as 'Naziv uredjaja'
                                from [Vrsta usluge] inner join Uredjaji on [Vrsta usluge].IDUredjaji = Uredjaji.IDUredjaj;";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }


        }

        private void btnTermin_Click(object sender, RoutedEventArgs e)
        {
            btnDodajTermin.Visibility = Visibility.Visible;

            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajKlijenta.Visibility = Visibility.Collapsed;
            btnDodajZaposlenog.Visibility = Visibility.Collapsed;
            btnDodajUredjaj.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajNabavku.Visibility = Visibility.Collapsed;
            btnDodajUslugu.Visibility = Visibility.Collapsed;
            btnDodajVrstuUsluge.Visibility = Visibility.Collapsed;

            btnIzmeniTermin.Visibility = Visibility.Visible;

            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniKlijenta.Visibility = Visibility.Collapsed;
            btnIzmeniZaposlenog.Visibility = Visibility.Collapsed;
            btnIzmeniUredjaj.Visibility = Visibility.Collapsed;
            btnIzmeniUslugu.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniNabavku.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuUSluge.Visibility = Visibility.Collapsed;

            btnObrisiTermin.Visibility = Visibility.Visible;

            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiKlijenta.Visibility = Visibility.Collapsed;
            btnObrisiZaposlenog.Visibility = Visibility.Collapsed;
            btnObrisiUredjaj.Visibility = Visibility.Collapsed;
            btnObrisiUslugu.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiNabavku.Visibility = Visibility.Collapsed;
            btnObrisiVrstuUsluge.Visibility = Visibility.Collapsed;

            PocetniDataGrid(dataGridCentralni);

        }

        //Dodaj

        private void btnDodajTermin_Click(object sender, RoutedEventArgs e)
        {
            frmTermin prozor = new frmTermin();
            prozor.ShowDialog();
            btnTermin_Click(sender, e);

        }

        private void btnDodajZaposlenog_Click(object sender, RoutedEventArgs e)
        {
            frmZaposleni prozor = new frmZaposleni();
            prozor.ShowDialog();
            btnZaposleni_Click(sender, e);
        }

        private void btnDodajKlijenta_Click(object sender, RoutedEventArgs e)
        {
            frmKlijent prozor = new frmKlijent();
            prozor.ShowDialog();
            btnKlijent_Click(sender, e);

        }

        private void btnDodajDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            frmDobavljaci prozor = new frmDobavljaci();
            prozor.ShowDialog();
            btnDobavljac_Click(sender, e);
        }

        private void btnDodajUredjaj_Click(object sender, RoutedEventArgs e)
        {
            frmUredjaj prozor = new frmUredjaj();
            prozor.ShowDialog();
            btnUredjaj_Click(sender, e);
        }

        private void btnDodajProizvod_Click(object sender, RoutedEventArgs e)
        {
            frmProizvod prozor = new frmProizvod();
            prozor.ShowDialog();
            btnProizvod_Click(sender, e);
        }

        private void btnDodajNabavku_Click(object sender, RoutedEventArgs e)
        {
            frmNabavka prozor = new frmNabavka();
            prozor.ShowDialog();
            btnNabavka_Click(sender, e);
        }

        private void btnDodajUslugu_Click(object sender, RoutedEventArgs e)
        {
            frmUsluga prozor = new frmUsluga();
            prozor.ShowDialog();
            btnUsluga_Click(sender, e);
        }

        private void btnDodajVrstuUsluge_Click(object sender, RoutedEventArgs e)
        {
            frmVrstaUsluge prozor = new frmVrstaUsluge();
            prozor.ShowDialog();
            btnVrstaUsluge_Click(sender, e);
        }

        //Izmeni

        private void btnIzmeniTermin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmTermin prozor = new frmTermin();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Termin Where IDTermin = " + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtNaziv.Text = citac["Naziv"].ToString();
                    prozor.cbKlijent.SelectedValue = citac["IDKlijent"].ToString();
                    prozor.cbZaposleni.SelectedValue = citac["IDZaposleni"].ToString();
                    prozor.cbUsluga.SelectedValue = citac["IDUsluga"].ToString();
                    
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnTermin_Click(sender, e);
                azuziraj = false;
            }
        }

        private void btnIzmeniZaposlenog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmZaposleni prozor = new frmZaposleni();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Zaposleni Where IDZaposleni = " + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtIme.Text = citac["ImeZap"].ToString();
                    prozor.txtPrezime.Text = citac["PrezimeZap"].ToString();
                    prozor.txtJMBG.Text = citac["JMBG"].ToString();
                    prozor.txtBrojTelefona.Text = citac["BrojTelefona"].ToString();
                    prozor.cbStalnoZaposlen.IsChecked = (bool)citac["StalnoZaposlen"];
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnZaposleni_Click(sender, e);
                azuziraj = false;
            }
        }

        private void btnIzmeniKlijenta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmKlijent prozor = new frmKlijent();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Klijent Where IDKlijent =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtIme.Text = citac["ImeKlijenta"].ToString();
                    prozor.txtPrezime.Text = citac["PrezimeKlijenta"].ToString();
                    prozor.txtJMBG.Text = citac["JMBG"].ToString();
                    prozor.txtBrojTelefona.Text = citac["BrojTelefona"].ToString();
                    prozor.txtFrizer.Text = citac["Frizer"].ToString();
                    prozor.txtUsluga.Text = citac["Usluga"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnKlijent_Click(sender, e);
                azuziraj = false;
            }
        }

        private void btnIzmeniDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmDobavljaci prozor = new frmDobavljaci();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Dobavljac Where IDDobavljac =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtNaziv.Text = citac["Naziv"].ToString();
                    prozor.txtAdresa.Text = citac["Adresa"].ToString();
                    prozor.txtPIB.Text = citac["PIB"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnDobavljac_Click(sender, e);
                azuziraj = false;
            }
        }

        private void btnIzmeniUredjaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmUredjaj prozor = new frmUredjaj();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Uredjaji Where IDUredjaj =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtNaziv.Text = citac["NazivUredjaja"].ToString();
                    prozor.txtKolicina.Text = citac["Kolicina"].ToString();
                    prozor.cbIspravnost.IsChecked = (bool)citac["Ispravnost"];
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnUredjaj_Click(sender, e);
                azuziraj = false;
            }

        }

        private void btnIzmeniProizvod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmProizvod prozor = new frmProizvod();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Proizvodi Where IDProizvoda =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtNaziv.Text = citac["NazivProizvoda"].ToString();
                    prozor.txtKolicina.Text = citac["Kolicina"].ToString();

                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnProizvod_Click(sender, e);
                azuziraj = false;
            }

        }

        private void btnIzmeniNabavku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmNabavka prozor = new frmNabavka();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Nabavka Where IDNabavka =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtCena.Text = citac["Cena"].ToString();
                    prozor.cbDobavljac.SelectedValue = citac["IDDobavljac"].ToString();
                    prozor.cbProizvod.SelectedValue = citac["IDProizvod"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnNabavka_Click(sender, e);
                azuziraj = false;
            }

        }

        private void btnIzmeniUslugu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmUsluga prozor = new frmUsluga();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From Usluga Where IDUsluge =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtNaziv.Text = citac["NazivUsluge"].ToString();
                    prozor.txtCena.Text = citac["Cena"].ToString();
                    prozor.cbxProizvod.SelectedValue = citac["IDProizvodi"].ToString();
                    prozor.cbxVrstaUsluge.SelectedValue = citac["IDVrstaUsluge"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnUsluga_Click(sender, e);
                azuziraj = false;
            }

        }

        private void btnIzmeniVrstuUSluge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                azuziraj = true;
                frmVrstaUsluge prozor = new frmVrstaUsluge();
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                pomocni = red;

                string upit = "Select * From [Vrsta usluge] Where IDVrstaUsluge =" + red["ID"];

                SqlCommand komanda = new SqlCommand(upit, konekcija);

                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    prozor.txtOpis.Text = citac["OpisUsluge"].ToString();
                    prozor.cbxUredjaj.SelectedValue = citac["IDUredjaji"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
                btnVrstaUsluge_Click(sender, e);
                azuziraj = false;
            }

        }

        //Obrisi
        private void btnObrisiTermin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Termin Where IDTermin=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnTermin_Click(sender, e);
            }
        }

        private void btnObrisiZaposlenog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Zaposleni Where IDZaposleni=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnZaposleni_Click(sender, e);
            }
        }

        private void btnObrisiKlijenta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Klijent Where IDKlijent=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnKlijent_Click(sender, e);
            }
        }

        private void btnObrisiDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Dobavljac Where IDDobavljac=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnDobavljac_Click(sender, e);
            }
        }

        private void btnObrisiUredjaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Uredjaji Where IDUredjaj=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnUredjaj_Click(sender, e);
            }
        }

        private void btnObrisiProizvod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Proizvodi Where IDProizvoda=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnProizvod_Click(sender, e);
            }
        }


        private void btnObrisiNabavku_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Nabavka Where IDNabavka=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnNabavka_Click(sender, e);
            }
        }


        private void btnObrisiUslugu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from Usluga Where IDUsluge=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnUsluga_Click(sender, e);
            }
        }

        private void btnObrisiVrstuUsluge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView red = (DataRowView)dataGridCentralni.SelectedItems[0];

                string upit = @"Delete from [Vrsta usluge] Where IDVrstaUsluge=" + red["ID"];

                MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException)
            {
                MessageBox.Show("Postoje povezani podaci u drugim tabelama", "Obavestenje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                btnVrstaUsluge_Click(sender, e);
            }
        }
        }
}


