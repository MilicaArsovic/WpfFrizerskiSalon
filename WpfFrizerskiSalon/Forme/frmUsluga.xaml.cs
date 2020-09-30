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
using System.Windows.Shapes;

namespace WpfFrizerskiSalon.Forme
{
    /// <summary>
    /// Interaction logic for frmUsluga.xaml
    /// </summary>
    public partial class frmUsluga : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmUsluga()
        {
            InitializeComponent();
            txtNaziv.Focus();

            try
            {
                konekcija.Open();

                string vratiVrstuUsluge = @"Select IDVrstaUsluge, OpisUsluge as Usluga from [Vrsta usluge]";

                DataTable dtVrstaUsluge = new DataTable();
                SqlDataAdapter daVrstaUsluge = new SqlDataAdapter(vratiVrstuUsluge, konekcija);
                daVrstaUsluge.Fill(dtVrstaUsluge);

                cbxVrstaUsluge.ItemsSource = dtVrstaUsluge.DefaultView;

                string vratiProizvod = @"Select IDProizvoda, NazivProizvoda as Proizvod from Proizvodi";

                DataTable dtProizvod = new DataTable();
                SqlDataAdapter daProizvod = new SqlDataAdapter(vratiProizvod, konekcija);
                daProizvod.Fill(dtProizvod);

                cbxProizvod.ItemsSource = dtProizvod.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuziraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string upit = @"Update Usluga 
                                    Set NazivUsluge='" + txtNaziv.Text + "',IDProizvodi = "+cbxProizvod.SelectedValue+",Cena='"+txtCena.Text+"',IDVrstaUsluge="+cbxVrstaUsluge.SelectedValue+" Where IDUsluge=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {

                    string insert = @"insert into Usluga(NazivUsluge, IDProizvodi, Cena, IDVrstaUsluge)
                            values('" + txtNaziv.Text + "'," + cbxProizvod.SelectedValue + ",'" + txtCena.Text + "'," + cbxVrstaUsluge.SelectedValue + ");";

                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
