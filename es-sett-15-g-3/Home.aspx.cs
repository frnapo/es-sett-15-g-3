using System;
using System.Configuration;
using System.Data.SqlClient;

namespace es_sett_15_g_3
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            string selectedValue = DropDownList2.SelectedValue;

            try
            {

                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "INSERT INTO Prenotazioni(Nome, Cognome, SalaNord, SalaSud, SalaEst, Ridotto) VALUES (@Nome, @Cognome, @SalaNord, @SalaSud, @SalaEst, @Ridotto)";
                command.Parameters.AddWithValue("@Nome", Nome.Text);
                command.Parameters.AddWithValue("@Cognome", Cognome.Text);
                command.Parameters.AddWithValue("@SalaNord", selectedValue == "Nord" ? true : false);
                command.Parameters.AddWithValue("@SalaSud", selectedValue == "Sud" ? true : false);
                command.Parameters.AddWithValue("@SalaEst", selectedValue == "Est" ? true : false);
                command.Parameters.AddWithValue("@Ridotto", CheckBox1.Checked);

                if (Nome.Text == "" || Cognome.Text == "")
                {
                    Response.Write("Inserire nome e cognome");
                    return;
                }


                command.ExecuteNonQuery();


                Response.Write("Inserito con successo");

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaNord) FROM Prenotazioni WHERE SalaNord = 1";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaNord = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti interi per Sala Nord: " + SalaNord;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaSud) FROM Prenotazioni WHERE SalaSud = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaSud = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti per Sala Sud: " + SalaSud;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            string Cinema = ConfigurationManager.ConnectionStrings["CinemaDB"].ConnectionString;
            SqlConnection conn = new SqlConnection(Cinema);
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT Count(SalaEst) FROM Prenotazioni WHERE SalaEst = 1";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int SalaEst = reader.GetInt32(0);
                    Dettagli.InnerHtml = "Biglietti per Sala Est: " + SalaEst;
                }

            }
            catch (Exception ex)
            {
                Response.Write("Errore");
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
}