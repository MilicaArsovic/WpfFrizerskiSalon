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
    /// Interaction logic for frmTermin.xaml
    /// </summary>
    public partial class frmTermin : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmTermin()
        {
            InitializeComponent();
            txtNaziv.Focus();

            try
            {
                konekcija.Open();

                string vratiKlijenta = @"Select IDKlijent, ImeKlijenta + ' ' + PrezimeKlijenta as Klijent
                                        From Klijent; ";

                DataTable dtKlijent = new DataTable();
                SqlDataAdapter daKlijent = new SqlDataAdapter(vratiKlijenta, konekcija);
                daKlijent.Fill(dtKlijent);

                cbKlijent.ItemsSource = dtKlijent.DefaultView;

                string vratiZaposleni = @"select IDZaposleni,ImeZap +' '+PrezimeZap  as Zaposleni
                                                from Zaposleni";

                DataTable dtZaposleni = new DataTable();
                SqlDataAdapter daZaposleni = new SqlDataAdapter(vratiZaposleni, konekcija);
                daZaposleni.Fill(dtZaposleni);

                cbZaposleni.ItemsSource = dtZaposleni.DefaultView;

                string vratiUslugu = @"select IDUsluge,NazivUsluge as Usluga
                                            from Usluga";

                DataTable dtUsluga = new DataTable();
                SqlDataAdapter daUsluga = new SqlDataAdapter(vratiUslugu, konekcija);
                daUsluga.Fill(dtUsluga);

                cbUsluga.ItemsSource = dtUsluga.DefaultView;

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

                    string upit = @"Update Termin 
                                Set Naziv='" + txtNaziv.Text + "',IDKlijent="+cbKlijent.SelectedValue+",IDZaposleni="+cbZaposleni.SelectedValue+", IDUsluge ="+cbUsluga.SelectedValue+" Where IDTermin=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {

                    string insert = @"insert into Termin(Naziv,IDKlijent,IDZaposleni,IDUsluge)
                                        values ('" + txtNaziv.Text + "'," + cbKlijent.SelectedValue + "," + cbZaposleni.SelectedValue + "," + cbUsluga.SelectedValue + ");";

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
