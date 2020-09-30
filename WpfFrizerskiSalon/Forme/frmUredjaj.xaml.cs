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
    /// Interaction logic for frmUredjaj.xaml
    /// </summary>
    public partial class frmUredjaj : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmUredjaj()
        {
            InitializeComponent();
            txtNaziv.Focus();
        }


        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuziraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string upit = @"Update Uredjaji 
                                Set NazivUredjaja='" + txtNaziv.Text + "',Kolicina='" + txtKolicina.Text + "',Ispravnost=" + Convert.ToInt32(cbIspravnost.IsChecked) + " Where IDUredjaj=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {

                    string insert = @"insert into Uredjaji(NazivUredjaja,Kolicina,Ispravnost)
                                    values('" + txtNaziv.Text + "','" + txtKolicina.Text + "'," + Convert.ToInt32(cbIspravnost.IsChecked) + ");";

                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan!", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
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