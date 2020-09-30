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
    /// Interaction logic for frmZaposleni.xaml
    /// </summary>
    public partial class frmZaposleni : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmZaposleni()
        {
            InitializeComponent();
            txtIme.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuziraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string upit = @"Update Zaposleni 
                                    Set ImeZap='" + txtIme.Text + "',PrezimeZap='"+txtPrezime.Text+"',JMBG='"+txtJMBG.Text+"',StalnoZaposlen = "+Convert.ToInt32(cbStalnoZaposlen.IsChecked)+",BrojTelefona ='"+txtBrojTelefona.Text+"' Where IDZaposleni=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {

                    string insert = @"insert into Zaposleni(ImeZap,PrezimeZap,JMBG,StalnoZaposlen,BrojTelefona)
                                    values('" + txtIme.Text + "','" + txtPrezime.Text + "','" + txtJMBG.Text + "'," + Convert.ToInt32(cbStalnoZaposlen.IsChecked) + ",'" + txtBrojTelefona.Text + "');";
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
