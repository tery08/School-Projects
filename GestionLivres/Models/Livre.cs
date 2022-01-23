using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionLivres.Models
{
    public class Livre
    {

        public int Id { get; set; }

        [Required(ErrorMessage =  "Le titre est obligatoire")]
        [DisplayName("Titre du livre")]
        public string Titre { get; set; }

        [Required(ErrorMessage =  "Le nom d'auteur est obligatoire")]
        [DisplayName("Auteur")]
        public string Auteur { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        [DisplayName("Categorie")]
        public string Categorie { get; set; }

        [Required(ErrorMessage = "Le nombre d'examplaires est obligatoire")]
        [DisplayName("Total d'exemplaires")]
        public int NbExem { get; set; }

       //[Required(ErrorMessage = "Le nombre d'examplaires disponibles est obligatoire")]
        //[Range(1, 20, ErrorMessage = "Le nombre d'exemplaires disponibles ne peut pas être plus grand que le nombre total des exemplaires")]
        [DisplayName("Nombre d'exemplaires disponibles")]
        public int NbDispo { get; set; }
        

        [Required(ErrorMessage = "Le nombre de pages est obligatoire")]
        [Range(1,2000, ErrorMessage = "Le nombre de pages doit être entre 1 et 2000")]
        [DisplayName("Nombre de pages")]
        public int NbPages { get; set; }

       

    }
}