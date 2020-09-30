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
    /// Interaction logic for frmVrstaUsluge.xaml
    /// </summary>
    public partial class frmVrstaUsluge : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmVrstaUsluge()
        {
            InitializeComponent();
            txtOpis.Focus();

            try
            {
                konekcija.Open();

                string vratiUredjaj = @"Select IDUredjaj, NazivUredjaja as Uredjaji from Uredjaji";

                DataTable dtUredjaj = new DataTable();
                SqlDataAdapter daUredjaj = new SqlDataAdapter(vratiUredjaj, konekcija);
                daUredjaj.Fill(dtUredjaj);

                cbxUredjaj.ItemsSource = dtUredjaj.DefaultView;
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

                    string upit = @"Update [Vrsta usluge] 
                           Set OpisUsluge='" + txtOpis.Text + "',IDUredjaji="+cbxUredjaj.SelectedValue+" Where IDVrstaUsluge=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }

                else
                {

                    string insert = @"insert into [Vrsta usluge](OpisUsluge,IDUredjaji)
                                values('" + txtOpis.Text + "'," + cbxUredjaj.SelectedValue + ");";

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
