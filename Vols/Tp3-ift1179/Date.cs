using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Tp3_ift1179
{
	[Serializable()]
	class Date : IComparable
	{
        private string jour;
        private string mois;
        private string an;
        static public string[] tabMois = { null, "Janvier", "Février", "Mars", "Avril", "Mai", "Juin", "Juillet", "Août", "Septembre", "Octobre", "Novembre", "Décembre" };
		public Date(string jour, string mois, string an)
        {
            this.jour = jour;
            this.mois = mois;
            this.an = an;
        }
        public string Jour
        {
            get { return jour; }
			set { jour = value; }
		}
        public string Mois
        {
            get { return mois; }
			set { mois = value; }
		}
        public string An
        {
            get { return an; }            
			set { an = value; }
		}
		//----------------------------------------------------------------------------------------------------------
		public static void ValiderDate(int jourT, int moisT, int anT, Date maDate)
		{
			
			int nbJours = 0;
			maDate.Jour = jourT.ToString();
			maDate.Mois = moisT.ToString();
			maDate.An = anT.ToString();
			while (anT < 0 || anT < DateTime.Today.Year)
			{
				Console.WriteLine(" L'année ne peut pas être inférieure de " + DateTime.Today.Year + " ou négative");

				Console.Write(" Entrer l'année de nouveau : ");
				anT = int.Parse(Console.ReadLine());
				maDate.An = anT.ToString();
			}
			//Valider le mois
			while (moisT < 1 || moisT > 12)
			{
				
				Console.WriteLine( " Mois " + moisT + " n'est pas un mois valide [1-12]" + "\n");
				Console.Write(" Entrez le mois de nouveau : ");
				moisT = int.Parse(Console.ReadLine());
				maDate.Mois = moisT.ToString();
			}			
				nbJours = DeterminerNbJoursMois(moisT, anT);
			while (jourT > nbJours || jourT <= 0)
			{
				
				Console.WriteLine(" Jour " + jourT + " n'est un jour valide pour le mois de " + tabMois[moisT] + "\n");
				Console.Write(" Entrer le jour de nouveau : ");
				jourT = int.Parse(Console.ReadLine());
				maDate.Jour = jourT.ToString();
			}			
		}
//----------------------------------------------------------------------------------------------------------
		public static bool estBissextile(int annee)
		{
			return (annee % 4 == 0 && annee % 100 != 0) || (annee % 400 == 0);
		}
//---------------------------------------------------------------------------------------
		public static int DeterminerNbJoursMois(int mois, int an)
		{
			int nbJours;
			int[] tabJrMois = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
			if (mois == 2 && estBissextile(an))
				nbJours = 29;
			else
				nbJours = tabJrMois[mois];
			return nbJours;
		}
//------------------------------------------------------------------------------------------------------
		public int CompareTo(object obj)
		{
			if (obj == null) return 1;
			Date autreDate = obj as Date;
			if (autreDate != null)
			{
				return autreDate.An.CompareTo(this.An);
			}
			else
			{
				throw new ArgumentException(" Object n'est pas une Date");
			}
		}
//----------------------------------------------------------------------------------------
		public override string ToString()
		{
			string leJour, leMois;
			leJour = Utilitaires.AjouterCaractereGauche('0', 2, Jour + "");
			leMois = Utilitaires.AjouterCaractereGauche('0', 2, Mois + "");
			return leJour + "/" + leMois + "/" + An;
		}
	}
}
