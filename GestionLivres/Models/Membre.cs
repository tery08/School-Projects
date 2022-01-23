using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GestionLivres.Models
{
    public class Membre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prenom est obligatoire")]
        [DisplayName("Prenom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Le nom  est obligatoire")]
        [DisplayName("Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "L'âge est obligatoire")]
        [Range(3, 120, ErrorMessage = "L'âge doit être entre 3 et 120")]
        [DisplayName("Âge")]
        public int Age { get; set; }

        [Range(1, 2, ErrorMessage = "Le sexe doit être 1 pour femme ou 2 pour homme")]
        [DisplayName("Sexe")]
        public int Sexe { get; set; }


        [Required(ErrorMessage = "Le courriel est obligatoire")]
        [DisplayName("Courriel")]
        public string Courriel { get; set; }


        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire en format xxx-xxx-xxxx")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Téléphone")]
        public string Tel { get; set; }
        public int NbLivres { get; set; }

    }
}