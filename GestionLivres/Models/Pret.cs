using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionLivres.Models
{
    public class Pret
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le numéro du membre est obligatoire")]
        [DisplayName("Numéro du membre")]
        public string  NbMembre { get; set; }

        [Required(ErrorMessage = "Le numéro du livre est obligatoire")]
        [DisplayName("Numéro du livre")]
        public string NbLivre { get; set; }

        //public string DatePret { get; set; }
        //public string DateRetour { get; set; }

        //public string Diff { get; set; }


    }
}