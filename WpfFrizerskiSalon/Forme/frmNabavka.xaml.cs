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
    /// Interaction logic for frmNabavka.xaml
    /// </summary>
    public partial class frmNabavka : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmNabavka()
        {
            InitializeComponent();
            txtCena.Focus();

            try
            {
                konekcija.Open();

                string vratiDobavljaca = @"Select IDDobavljac, Naziv as Dobavljac from Dobavljac";

                DataTable dtDobavljac = new DataTable();
                SqlDataAdapter daDobavljac = new SqlDataAdapter(vratiDobavljaca, konekcija);
                daDobavljac.Fill(dtDobavljac);

                cbDobavljac.ItemsSource = dtDobavljac.DefaultView;

                string vratiProizvodi = @"Select IDProizvoda, NazivProizvoda as Proizvod from Proizvodi";

                DataTable dtProizvodi = new DataTable();
                SqlDataAdapter daProizvodi = new SqlDataAdapter(vratiProizvodi, konekcija);
                daProizvodi.Fill(dtProizvodi);

                cbProizvod.ItemsSource = dtProizvodi.DefaultView;
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

                    string upit = @"Update Nabavka 
                                    Set Cena= '"+txtCena.Text+"', IDDobavljac= "+cbDobavljac.SelectedValue+", IDProizvod = "+cbProizvod.SelectedValue+" Where IDNabavka=" + red["ID"];

                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {
                    string insert = @"insert into Nabavka(Cena,IDDobavljac,IDProizvod)
                                    values('" + txtCena.Text + "'," + cbDobavljac.SelectedValue + "," + cbProizvod.SelectedValue + ");";
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
