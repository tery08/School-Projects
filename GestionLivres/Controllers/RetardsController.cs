using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionLivres.Controllers
{
    public class RetardsController : Controller
    {
        string chaineConnexion = @"Server=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\tshar\source\repos\GestionLivres\App_Data\bdgplcc.mdf;Database=bdgplcc;Trusted_Connection=Yes";
        // GET: Retards
        public ActionResult ListeRetards()
        {
            DataTable tabRetard = new System.Data.DataTable();
            using (System.Data.SqlClient.SqlConnection con = new SqlConnection(chaineConnexion))
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("SELECT * FROM Retards", con);
                adp.Fill(tabRetard);
            }
            return View(tabRetard);
        }       
    }
}
