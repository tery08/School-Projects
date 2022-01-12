using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tp3_ift1179
{
    [Serializable()]
    class Vol : IComparable
    {
        private string typeAvion;
        private string categorie;
        private string num;
        private string dest;
        private Date date;        
        private string nbTotalR;
        public static int nombreVols;

        public Vol(string categorie,string num, string dest, Date date, string nbTotalR, string typeAvion)  
        {
            this.typeAvion = typeAvion;
            this.categorie = categorie;
            this.num = num;
            this.dest = dest;
            this.date = date;
            this.nbTotalR = nbTotalR;
            ++nombreVols;
        }
        public string Categorie
        {
            get { return categorie; }
            set { categorie = value; }
        }
        public string Num
        {
            get { return num; }
            set { num = value; }
        }
        public string Dest
        {
            get { return dest; }
            set { dest = value; }
        }
        public Date Date
        {
            get { return date; }
            set { date = value; }
        }
        public string NbTotalR
        {
            get { return nbTotalR; }
            set { nbTotalR = value; }
        }
        public string TypeAvion
        {
            get { return typeAvion; }
            set { typeAvion = value; }
        }
        public override string ToString()
        {
            return Utilitaires.obtenirCat(this.Categorie) + "\t\t" + this.Num + "\t" + this.Dest + Utilitaires.AjouterEspacesFin(24, this.Dest) + this.Date + "\t" + this.NbTotalR + Utilitaires.AjouterEspacesFin(16, this.NbTotalR) + this.TypeAvion;
        }


         public int CompareTo(object obj)
         {
             if (obj == null) return 1;
             Vol autreVol = obj as Vol;
             if (autreVol != null)
             {               
                 return autreVol.Num.CompareTo(this.Num);
             }
             else
             {
                 throw new ArgumentException("Object n'est pas un Vol");
             }
         }
    }
}
