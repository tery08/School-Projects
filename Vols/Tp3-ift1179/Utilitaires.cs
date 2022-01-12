//EXPRESSIONS https://waytolearnx.com/2019/09/expression-reguliere-pour-valider-un-numero-de-telephone-en-csharp.html

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;

namespace Tp3_ift1179
{
    class Utilitaires
	{
		public const string FICHIER_OBJETS_VOLS = "CieAirRelax.obj";
		public const string DATE = @"[0-9]{1,2}(/|-)[0-9]{1,2}(/|-)[0-9]{4}$";
		public const string NUMERO = @"^[0-9]{5}$";
		public static bool IsDate(string date)
		{
			if (!String.IsNullOrEmpty(date) && Regex.IsMatch(date, DATE))
			{
				return true;
			}			
			else{
				Console.WriteLine(" Erreur: Vous n'avez rien saisi ou le format n'a pas été respecté");
				return false;
			}
		}
		public static bool IsCat(string cat)
		{
			if (!String.IsNullOrEmpty(cat) && int.Parse (cat)>0 && int.Parse(cat) <5)
			{
				return true;
			}
			else
			{
				Console.WriteLine(" Erreur: Vous pouvez choisir un chiffre entre 1 et 4 ou vous n'avez rien saisi.Veuillez entrervotre choux de nouveau: ");
				return false;
			}
		}
		public static bool IsNum(string num)
		{
			if (!String.IsNullOrEmpty(num) && Regex.IsMatch(num, NUMERO) && int.Parse(num)>0)
							
				return true;
			
			else
			{				
				
				return false;
			}
		}
		public static string AjouterEspacesFin(int tailleColMax, string chaine)
		{
			int nbEspaces = tailleColMax - chaine.Length;
			string espaces = "";
			for (int i = 0; i < nbEspaces; i++)
			{
				espaces += " ";
			}
			return espaces;
		}
		public static string AjouterEspacesDebut(int tailleColMax, string chaine)
		{
			int nbEspaces = (tailleColMax - chaine.Length) / 2;
			string espaces = "";
			for (int i = 0; i < nbEspaces; i++)
			{
				espaces += " ";
			}
			return espaces;
		}
		public static string AjouterCaractereGauche(char car, int longueur, string ch)
		{
			String rep = "";
			int nbCar = longueur - ch.Length;
			for (int i = 1; i <= nbCar; i++)
			{
				rep += car;
			}
			return rep + ch;
		}
		public static string obtenirService(bool test)
		{
            if (test)
            {
				return "inclu";
            }
            else
            {
				return "Non inclu";
            }
		}
	
		public static void obtenirClasse(Vol unVol)
        {
			if(unVol is VolPrive)
            {
			string repas = obtenirService(((VolPrive)unVol).Repas);
			string siege = obtenirService(((VolPrive)unVol).Siege);
			string bar = obtenirService(((VolPrive)unVol).Bar);
			string divert = obtenirService(((VolPrive)unVol).Divertissement);
			string serviceP = obtenirService(((VolPrive)unVol).ServicePay);
			string wifi = obtenirService(((VolPrive)unVol).Wifi);
			Console.WriteLine("\n Services offerts: ");
			Console.WriteLine("\n Repas" + "\t\t" + "Choix siège" + "\t\t" + "Bar" + "\t\t" + "Divertissements" + "\t\t" + "Services Payants" + "\t" + "Wi-fi");
			Console.WriteLine(" " + repas + AjouterEspacesDebut(25, repas) + siege + AjouterEspacesDebut(43, siege) + bar + AjouterEspacesDebut(27, bar) + divert + AjouterEspacesDebut(43, divert) + serviceP + AjouterEspacesDebut(43, serviceP) + wifi);

            }
			else if(unVol is VolCharter)
            {
				string repas = obtenirService(((VolCharter)unVol).Repas);
				string siege = obtenirService(((VolCharter)unVol).Siege);
				string bar = obtenirService(((VolCharter)unVol).Bar);
				string divert = obtenirService(((VolCharter)unVol).Divertissement);
				string serviceP = obtenirService(((VolCharter)unVol).ServicePay);
				string wifi = obtenirService(((VolCharter)unVol).Wifi);
				Console.WriteLine("\n Services offerts: ");
				Console.WriteLine("\n Repas" + "\t\t" + "Choix siège" + "\t\t" + "Bar" + "\t\t" + "Divertissements" + "\t\t" + "Services Payants" + "\t" + "Wi-fi");
				Console.WriteLine(" " + repas + AjouterEspacesDebut(22, repas) + siege + AjouterEspacesDebut(43, siege) + bar + AjouterEspacesDebut(23, bar) + divert + AjouterEspacesDebut(43, divert) + serviceP + AjouterEspacesDebut(43, serviceP) + wifi);
			}
			else if (unVol is VolRegulier)
			{
				string repas = obtenirService(((VolRegulier)unVol).Repas);
				string siege = obtenirService(((VolRegulier)unVol).Siege);
				string bar = obtenirService(((VolRegulier)unVol).Bar);
				string divert = obtenirService(((VolRegulier)unVol).Divertissement);
				string serviceP = obtenirService(((VolRegulier)unVol).ServicePay);
				string wifi = obtenirService(((VolRegulier)unVol).Wifi);
				Console.WriteLine("\n Services offerts: ");
				Console.WriteLine("\n Repas" + "\t\t" + "Choix siège" + "\t\t" + "Bar" + "\t\t" + "Divertissements" + "\t\t" + "Services Payants" + "\t" + "Wi-fi");
				Console.WriteLine(" " + repas + AjouterEspacesDebut(25, repas) + siege + AjouterEspacesDebut(43, siege) + bar + AjouterEspacesDebut(23, bar) + divert + AjouterEspacesDebut(43, divert) + serviceP + AjouterEspacesDebut(43, serviceP) + wifi);
			}
			else if (unVol is VolBasPrix)
			{
				string repas = obtenirService(((VolBasPrix)unVol).Repas);
				string siege = obtenirService(((VolBasPrix)unVol).Siege);
				string bar = obtenirService(((VolBasPrix)unVol).Bar);
				string divert = obtenirService(((VolBasPrix)unVol).Divertissement);
				string serviceP = obtenirService(((VolBasPrix)unVol).ServicePay);
				string wifi = obtenirService(((VolBasPrix)unVol).Wifi);
				Console.WriteLine("\n Services offerts: ");
				Console.WriteLine("\n Repas" + "\t\t" + "Choix siège" + "\t\t" + "Bar" + "\t\t" + "Divertissements" + "\t\t" + "Services Payants" + "\t" + "Wi-fi");
				Console.WriteLine(" " + repas + AjouterEspacesDebut(22, repas) + siege + AjouterEspacesDebut(40, siege) + bar + AjouterEspacesDebut(23, bar) + divert + AjouterEspacesDebut(40, divert) + serviceP + AjouterEspacesDebut(40, serviceP) + wifi); ;
			}

		}

		public static void EnregistrerObjets(string fichier, SortedDictionary<string, Vol> Liste)
		{
			FileStream fs = new FileStream(fichier, FileMode.Create);
			BinaryFormatter formatter = new BinaryFormatter();
			try
			{
				formatter.Serialize(fs, Liste);
			}
			catch (System.Runtime.Serialization.SerializationException e)
			{
				Console.WriteLine(" Erreur.Raison: " + e.Message);
				throw;
			}
			finally
			{
				fs.Close();
			}
		}
		public static string obtenirCat(string cat)
		{
			string t = "";
			switch (int.Parse(cat))
			{
				case 1:
					t = "Vol privé";
					break;
				case 2:
					t = "Vol régulier";
					break;
				case 3:
					t = "Vol charter";
					break;
				case 4:
					t = "Vol bas-prix";
					break;
			}
			return t;
		}
	}
}

	
