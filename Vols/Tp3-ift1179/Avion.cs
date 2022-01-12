using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tp3_ift1179
{
    [Serializable()]
    class Avion
    {
        private string cat;
        private string type;
        private string nbPlaces;
        private string courrier;       
        public const string TYPE1 = "Boeing 747";
        public const string TYPE2 = "Boeing 700";
        public const string TYPE3 = "Airbus 320";
        public const string TYPE4 = "AirBus 300";
        public const string COURT = "Court-courrier";
        public const string MOYEN = "Moyen-courrier";
        public const string LONG = "Long-courrier";
        public const string AFFAIRE = "Affaire";
        public const string LEGER = "Léger";
        public const string ULTRA = "Ultra-léger";
        public bool choixClasse;      
        public static int nbAvions = 0;
        public Avion(string type, string nbPlaces, string courrier, string cat, bool choixClasse)
        {
            this.type = type;
            this.nbPlaces = nbPlaces;
            this.courrier = courrier;
            this.choixClasse = choixClasse;
            this.cat = cat;
            ++nbAvions;
        }
       
        public string Type
        {
            get { return type; }
            set
            {
                if (!String.IsNullOrEmpty(value) || (int.Parse(value) >= 1 && int.Parse(value) <= 4))
                {
                    type = value;
                }
                else { Console.WriteLine("ERREUR:  le type d'avion" + value + " est invalide ou la valeur n'a pas été fournie "); }
            }
        }
        public string Courrier
        {
            get { return courrier; }
            set
            {
                if (!String.IsNullOrEmpty(value) || (int.Parse(value) >= 1 && int.Parse(value) <= 3))
                {
                    courrier = value;
                }
                else { Console.WriteLine("ERREUR:  le type de courrier" + value + " est invalide ou la valeur n'a pas été fournie "); }
            }
        }
        public string Cat
        {
            get { return cat; }
            set
            {
                if (!String.IsNullOrEmpty(value) || (int.Parse(value) >= 1 && int.Parse(value) <= 3))
                {
                    cat = value;
                }
                else { Console.WriteLine("ERREUR:  la categorie " + value + " est invalide ou la valeur n'a pas été fournie "); }
            }
        }
        public bool ChoixClasse
        {
            get { return choixClasse; }
            set { choixClasse = value; }
        }
        public string NbPlaces
        {
            get { return nbPlaces; }
            set { nbPlaces = value; }
        }
        
        public override string ToString()
        {
            return this.Type + "\t" + this.nbPlaces + " \t " + this.Courrier +"\t" + this.Cat + "\t" + this.ChoixClasse;
        }
    }
}
