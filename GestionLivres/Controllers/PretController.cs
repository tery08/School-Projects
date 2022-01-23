using GestionLivres.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;

namespace GestionLivres.Controllers
{
    public class PretController : Controller
    {
        string chaineConnexion = @"Server=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\tshar\source\repos\GestionLivres\App_Data\bdgplcc.mdf;Database=bdgplcc;Trusted_Connection=Yes";
        // GET: Pret
        public ActionResult ListePrets()
        {
            DataTable tabPret = new System.Data.DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM Pret", con);
                adp.Fill(tabPret);
            }
            return View(tabPret);
        }

        // GET: Pret/EnregisrerPret
        public ActionResult EnregisrerPret(int id)
        {
            Pret pret = new Pret();
            DataTable tabPret = new DataTable();
            //string nbL;
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                string requette = "SELECT * FROM Livres WHERE Id = @Id";
                SqlDataAdapter sda = new SqlDataAdapter(requette, con);
                sda.SelectCommand.Parameters.AddWithValue("@Id", id);
                sda.Fill(tabPret);
            }
            if (tabPret.Rows.Count == 1 && Convert.ToInt32(tabPret.Rows[0][5]) > 0)
            {
                pret.NbLivre = tabPret.Rows[0][0].ToString();//Convert.ToInt32(tabPret.Rows[0][0].ToString());
                return View(pret);
            }
            return Content("Il n'y pas d'exemplaires disponibles");
        }

        // POST: Pret/EnregisrerPret
        [HttpPost]
        public ActionResult EnregisrerPret(Pret pret)
        {
            string idL = pret.NbLivre.ToString();
            string idM = pret.NbMembre;
            DateTime auj = DateTime.Today;
            TimeSpan time = new TimeSpan(7, 0, 00, 00);
            DateTime datePrevu = auj + time;
            string DatePret = auj.ToString("dd/MM/yyyy");
            string DateRetour = datePrevu.ToString("dd/MM/yyyy");
            DataTable tabVal = new DataTable();
            DataTable tabVal1 = new DataTable();
            int nLivres;
            int nDispo;
            string statut = "En attente";
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "SELECT * FROM membres WHERE  Id = @Id";
                    SqlDataAdapter sda = new SqlDataAdapter(requette, con);
                    
                    sda.SelectCommand.Parameters.AddWithValue("@Id", idM);
                    sda.Fill(tabVal);
                }
                nLivres = Convert.ToInt32(tabVal.Rows[0][7].ToString());
            }
            catch
            {
                return Content("Le numéro n'existe pas dans la base de données");
            }
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "SELECT * FROM Livres WHERE  Id = @Id";
                    SqlDataAdapter sda = new SqlDataAdapter(requette, con);

                    sda.SelectCommand.Parameters.AddWithValue("@Id", idL);
                    sda.Fill(tabVal1);
                }
                nDispo = Convert.ToInt32(tabVal1.Rows[0][5].ToString());
            }
            catch
            {
                return Content("Le numéro n'existe pas dans la base de données");
            }
            if (tabVal.Rows.Count == 1 && nLivres<3)
              {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "INSERT INTO Pret VALUES(@IdL, @IdM, @DatePret, @DateRetour, @Statut)";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@IdL", pret.NbLivre);
                    cmd.Parameters.AddWithValue("@IdM", pret.NbMembre);
                    cmd.Parameters.AddWithValue("@DatePret", DatePret);
                    cmd.Parameters.AddWithValue("@DateRetour", DateRetour);
                    cmd.Parameters.AddWithValue("@Statut", statut);
                    cmd.ExecuteNonQuery();
                    }
            }
            catch
            {
                return Content("Les données ne peuvent pas être ajoutées");
            }
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {                        
                    con.Open();
                    string requette = "UPDATE Livres SET NbDispo =@NbDispo WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Id", idL);
                    cmd.Parameters.AddWithValue("@NbDispo", nDispo-1);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
             {
                return Content("probleme nb dispo");
             }
            try
             {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                        //nDispo = Convert.ToInt32(tabVal1.Rows[0][5].ToString());
                     con.Open();
                     string requette = "UPDATE membres SET NbLivres =@NbLivres WHERE Id=@Id";
                     SqlCommand cmd = new SqlCommand(requette, con);
                     cmd.Parameters.AddWithValue("@Id", idM);
                     cmd.Parameters.AddWithValue("@NbLivres", nLivres + 1);
                     cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                    return Content("probleme nb livres dans membres");
            }
            }
            else
             {
                return Content("Maximum de 3 livres");
            }
            return RedirectToAction("../Pret/ListePrets");
        }

        // GET: Retour/EnregisrerRetour
        public ActionResult EnregisrerRetour()
        {
            return View(new Pret());
        }

        // POST: Retour/EnregisrerRetour
        [HttpPost]
          public ActionResult EnregisrerRetour(Pret pret)
          {
              CultureInfo provider = CultureInfo.InvariantCulture;
              DataTable tabRetour = new DataTable();
              string idL = pret.NbLivre;
              string idM = pret.NbMembre;             
              DateTime auj = DateTime.Today;
              DateTime dt1 = new DateTime(2021, 3, 29);// cette date doit être remplacée par la date du jour, utilisée juste pour tester le code
              string dt2 =dt1.ToString("dd/MM/yyyy");
              DataTable tabVal = new DataTable();
              DataTable tabVal1 = new DataTable();
              string statut="retourné";
              int nLivres;
              int nDispo;
                try
              {
                  using (SqlConnection con = new SqlConnection(chaineConnexion))
                  {
                      con.Open();
                      string requette = "SELECT * FROM Pret WHERE idL = @IdL AND idM = @IdM";
                      SqlDataAdapter sda = new SqlDataAdapter(requette, con);
                      sda.SelectCommand.Parameters.AddWithValue("@IdL", idL);
                      sda.SelectCommand.Parameters.AddWithValue("@IdM", idM); 
                      sda.Fill(tabRetour);
                  }
                    DateTime dt3 = DateTime.ParseExact(tabRetour.Rows[0][4].ToString(), "dd-MM-yyyy", provider);
                    TimeSpan interval = dt1 - dt3;
                    string DateP = tabRetour.Rows[0][3].ToString();
                    string DateR = tabRetour.Rows[0][4].ToString();
                    if (tabRetour.Rows.Count ==1 && interval.Days> 0)
                    {
                    try
                    {
                        using (SqlConnection con = new SqlConnection(chaineConnexion))
                        {
                            con.Open();
                            string requette = "SELECT * FROM membres WHERE  Id = @Id";
                            SqlDataAdapter sda = new SqlDataAdapter(requette, con);

                            sda.SelectCommand.Parameters.AddWithValue("@Id", idM);
                            sda.Fill(tabVal);
                        }
                    }
                    catch
                    {
                        return Content("ne trouve pas idM");
                    }
                    try
                    {
                        using (SqlConnection con = new SqlConnection(chaineConnexion))
                        {
                            con.Open();
                            string requette = "SELECT * FROM Livres WHERE  Id = @Id";
                            SqlDataAdapter sda = new SqlDataAdapter(requette, con);

                            sda.SelectCommand.Parameters.AddWithValue("@Id", idL);
                            sda.Fill(tabVal1);
                        }
                    }
                    catch
                    {
                        return Content("ne trouve pas idL");
                    }

                    nLivres = Convert.ToInt32(tabVal.Rows[0][7].ToString());
                    try
                    {
                        using (SqlConnection con = new SqlConnection(chaineConnexion))
                        {
                            nDispo = Convert.ToInt32(tabVal1.Rows[0][5].ToString());
                            con.Open();
                            string requette = "UPDATE Livres SET NbDispo =@NbDispo WHERE Id=@Id";
                            SqlCommand cmd = new SqlCommand(requette, con);
                            cmd.Parameters.AddWithValue("@Id", idL);
                            cmd.Parameters.AddWithValue("@NbDispo", nDispo +1);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        return Content("probleme nb dispo");
                    }
                    try
                    {
                        using (SqlConnection con = new SqlConnection(chaineConnexion))
                        {
                            
                            con.Open();
                            string requette = "UPDATE Pret SET Statut =@Statut WHERE idL = @IdL AND idM = @IdM";
                            SqlCommand cmd = new SqlCommand(requette, con);
                            cmd.Parameters.AddWithValue("@IdL", idL);
                            cmd.Parameters.AddWithValue("@IdM", idM);
                            cmd.Parameters.AddWithValue("@Statut", statut);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        return Content("probleme nb dispo");
                    }
                    try
                    {
                        using (SqlConnection con = new SqlConnection(chaineConnexion))
                        {
                            
                            con.Open();
                            string requette = "UPDATE membres SET NbLivres =@NbLivres WHERE Id=@Id";
                            SqlCommand cmd = new SqlCommand(requette, con);
                            cmd.Parameters.AddWithValue("@Id", idM);
                            cmd.Parameters.AddWithValue("@NbLivres", nLivres -1);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        return Content("probleme nb livres dans membres");
                    }

                    using (SqlConnection con = new SqlConnection(chaineConnexion))
                    {
                     con.Open();
                     string requette = "INSERT INTO Retards VALUES(@IdL, @IdM, @DatePret, @DateRetour, @JoursRetard)";
                     SqlCommand cmd = new SqlCommand(requette, con);
                     cmd.Parameters.AddWithValue("@IdL", idL);
                     cmd.Parameters.AddWithValue("@IdM", idM);
                     cmd.Parameters.AddWithValue("@DatePret",DateP);
                     cmd.Parameters.AddWithValue("@DateRetour",dt2);
                     cmd.Parameters.AddWithValue("@JoursRetard", interval.Days);
                     cmd.ExecuteNonQuery();
                    }
                }                  
                    return RedirectToAction("../Pret/ListePrets");
               }
               catch
               {
                return RedirectToAction("../Retards/ListeRetards");
                //return View();
            }
          }
    }
}
