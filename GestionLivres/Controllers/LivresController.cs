using GestionLivres.Models;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionLivres.Controllers
{
    public class LivresController : Controller
    {
        string chaineConnexion = @"Server=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\tshar\source\repos\GestionLivres\App_Data\bdgplcc.mdf;Database=bdgplcc;Trusted_Connection=Yes";           
        // GET: Livres
        public ActionResult Index()
        {
            DataTable tabLivres = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM Livres", con);
                adp.Fill(tabLivres);
            }
            return View(tabLivres);
        }
        public ActionResult GestionLivres()
        {
            DataTable tabLivres = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT*FROM Livres", con);
                adp.Fill(tabLivres);
            }
            return View(tabLivres);
        }

        // GET: Livres/Enregistrer
        public ActionResult Enregistrer()
        {
            return View(new Livre());
        }

        // POST: Livres/Enregistrer
        [HttpPost]
        public ActionResult Enregistrer(Livre livre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    
                    con.Open();
                    string requette = "INSERT INTO Livres VALUES(@Titre, @Auteur, @Categorie, @NbExem, @NbDispo, @NbPages)";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Titre", livre.Titre);
                    cmd.Parameters.AddWithValue("@Auteur", livre.Auteur);
                    cmd.Parameters.AddWithValue("@Categorie", livre.Categorie);
                    cmd.Parameters.AddWithValue("@NbExem", livre.NbExem);
                    cmd.Parameters.AddWithValue("@NbDispo", livre.NbExem);
                    cmd.Parameters.AddWithValue("@NbPages", livre.NbPages);
                    cmd.ExecuteNonQuery();
                }
            return RedirectToAction("GestionLivres");
            }
            catch
            {
                return View();
            }
        }
      

        // GET: Livres/Modifier
        public ActionResult Modifier(int id)
        {
            Livre livre = new Livre();
            DataTable tabLivres = new DataTable();
            using (SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                string requette = "SELECT * FROM Livres WHERE Id = @Id";
                SqlDataAdapter sda = new SqlDataAdapter(requette, con);
                sda.SelectCommand.Parameters.AddWithValue("@Id", id);
                sda.Fill(tabLivres);
            }
            if (tabLivres.Rows.Count == 1)
            {
                livre.Id = Convert.ToInt32(tabLivres.Rows[0][0].ToString());
                livre.Titre = tabLivres.Rows[0][1].ToString();
                livre.Auteur = tabLivres.Rows[0][2].ToString();
                livre.Categorie = tabLivres.Rows[0][3].ToString();
                livre.NbExem = Convert.ToInt32(tabLivres.Rows[0][4].ToString());
                livre.NbDispo = Convert.ToInt32(tabLivres.Rows[0][5].ToString());
                livre.NbPages = Convert.ToInt32(tabLivres.Rows[0][6].ToString());
                return View(livre);
            }
            else
            {
                return RedirectToAction("GestionLivres");
            }
        }

        // POST: Livres/Modifier
        [HttpPost]
        public ActionResult Modifier(Livre livre)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "UPDATE Livres SET Titre=@Titre, Auteur=@Auteur, Categorie=@Categorie, NbExem=@NbExem, NbDispo =@NbDispo, NbPages=@NbPages WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Id", livre.Id);
                    cmd.Parameters.AddWithValue("@Titre", livre.Titre);
                    cmd.Parameters.AddWithValue("@Auteur", livre.Auteur);
                    cmd.Parameters.AddWithValue("@Categorie", livre.Categorie);
                    cmd.Parameters.AddWithValue("@NbExem", livre.NbExem);
                    cmd.Parameters.AddWithValue("@NbDispo", livre.NbDispo);
                    cmd.Parameters.AddWithValue("@NbPages", livre.NbPages);
                    cmd.ExecuteNonQuery();

                }
            return RedirectToAction("GestionLivres");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livres/Enlever
        public ActionResult Enlever(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(chaineConnexion))
                {
                    con.Open();
                    string requette = "DELETE FROM Livres WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(requette, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    
                    cmd.ExecuteNonQuery();

                }
            return RedirectToAction("GestionLivres");
            }
            catch
            {
                return View();
            }
        }
    }
}
