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
    /// Interaction logic for frmKlijent.xaml
    /// </summary>
    public partial class frmKlijent : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmKlijent()
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

                    string upit = @"Update Klijent
                    Set ImeKlijenta='" + txtIme.Text + "',PrezimeKlijenta='"+txtPrezime.Text+"',JMBG='"+txtJMBG.Text+"',Usluga='"+txtUsluga.Text+"',Frizer='"+txtFrizer.Text+"',BrojTelefona='"+txtBrojTelefona.Text+"' Where IDKlijent=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {

                    string insert = @"insert into Klijent(ImeKlijenta,PrezimeKlijenta,JMBG,Usluga,Frizer,BrojTelefona)
                                    values('" + txtIme.Text + "','" + txtPrezime.Text + "','" + txtJMBG.Text + "','" + txtUsluga.Text + "','" + txtFrizer.Text + "','" + txtBrojTelefona.Text + "');";

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
