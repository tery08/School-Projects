using GestionLivres.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionLivres.Controllers
{
    public class MembresController : Controller
    {
        string chaineConnexion = @"Server=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\tshar\source\repos\GestionLivres\App_Data\bdgplcc.mdf;Database=bdgplcc;Trusted_Connection=Yes";
        // GET: Membres
        public ActionResult GestionMembres()
        {
            System.Data.DataTable tabMembres = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM Membres", con);
                adp.Fill(tabMembres);
            }
            return View(tabMembres);
        }
        
        public ActionResult EnregistrerMembre()
        {
            return View(new Membre());
        }

        // POST: Membres/EnregistrerMembre
        [HttpPost]
        public ActionResult EnregistrerMembre(Membre membre)
        {           
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {                   
                    con.Open();
                    string requette = "INSERT INTO Membres VALUES(@Prenom, @Nom, @Age, @Sexe, @Courriel, @Tel, @NbLivres)";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Prenom", membre.Prenom);
                    cmd.Parameters.AddWithValue("@Nom", membre.Nom);
                    cmd.Parameters.AddWithValue("@Age", membre.Age);
                    cmd.Parameters.AddWithValue("@Sexe", membre.Sexe);
                    cmd.Parameters.AddWithValue("@Courriel", membre.Courriel);
                    cmd.Parameters.AddWithValue("@Tel", membre.Tel);
                    cmd.Parameters.AddWithValue("@NbLivres", membre.NbLivres);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("GestionMembres");
            }
            catch
            {
                return View();
            }
        }

        // GET: Membres/ModifierMembre
        public ActionResult ModifierMembre(int id)
        {
            Membre membre = new Membre();
            DataTable tabMembres = new DataTable();

            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                string requette = "SELECT * FROM Membres WHERE Id = @Id";
                SqlDataAdapter sda = new SqlDataAdapter(requette, con);
                sda.SelectCommand.Parameters.AddWithValue("@Id", id);
                sda.Fill(tabMembres);
            }
            if (tabMembres.Rows.Count == 1)
            {
                membre.Id = Convert.ToInt32(tabMembres.Rows[0][0].ToString());
                membre.Prenom = tabMembres.Rows[0][1].ToString();
                membre.Nom = tabMembres.Rows[0][2].ToString();
                membre.Age= Convert.ToInt32(tabMembres.Rows[0][3].ToString());
                membre.Sexe = Convert.ToInt32(tabMembres.Rows[0][4].ToString());
                membre.Courriel =tabMembres.Rows[0][5].ToString();
                membre.Tel = tabMembres.Rows[0][6].ToString();
                return View(membre);
            }
            else
            {
                return RedirectToAction("GestionMembres");
            }
        }

        // POST: Membres/ModifierMembre
        [HttpPost]
        public ActionResult ModifierMembre(Membre membre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "UPDATE Membres SET Prenom=@Prenom, Nom=@Nom, Age=@Age, Sexe=@Sexe, Courriel =@Courriel, Tel=@Tel WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Id", membre.Id);
                    cmd.Parameters.AddWithValue("@Prenom", membre.Prenom);
                    cmd.Parameters.AddWithValue("@Nom", membre.Nom);
                    cmd.Parameters.AddWithValue("@Age", membre.Age);
                    cmd.Parameters.AddWithValue("@Sexe", membre.Sexe);
                    cmd.Parameters.AddWithValue("@Courriel", membre.Courriel);
                    cmd.Parameters.AddWithValue("@Tel", membre.Tel);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("GestionMembres");
            }
            catch
            {
                return View();
            }
        }

        // GET: Membres/EnleverMembre
        public ActionResult EnleverMembre(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "DELETE FROM Membres WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("GestionMembres");
            }
            catch
            {
                return View();
            }
        }        
    }
}
