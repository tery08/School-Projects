using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



namespace Tp3_ift1179 {

    [Serializable()]
    class GestionVols{
        static Vol unVol;
        static char choix;
        static int nbModif = 0;
        static StreamReader ficIn;
        public const int MAX_VOLS = 100;
        static bool[] etat = new bool[3];        
        static string nomF = "../../Cie_Air_Relax.txt";
        static SortedDictionary<string, Vol> ListeDictionaryVols = new SortedDictionary<string, Vol>();
        static Dictionary<string, Avion> ListeAvions = new Dictionary<string, Avion>(){            
        {Avion.TYPE1,new Avion (Avion.TYPE1, "170", Avion.LONG, Avion.AFFAIRE, true)},  
        {Avion.TYPE2,new Avion (Avion.TYPE2, "340", Avion.COURT, Avion.LEGER, true)},   
        {Avion.TYPE3,new Avion (Avion.TYPE3, "250", Avion.LONG, Avion.AFFAIRE, true)},  
        {Avion.TYPE4,new Avion (Avion.TYPE4, "360", Avion.MOYEN, Avion.ULTRA, false)}};  

        public static void chargerVols(){
            if (File.Exists(Utilitaires.FICHIER_OBJETS_VOLS)){
                using (Stream fic = File.Open(Utilitaires.FICHIER_OBJETS_VOLS, FileMode.Open)){
                    var bformat = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    ListeDictionaryVols = (SortedDictionary<string, Vol>)bformat.Deserialize(fic);
                }
            } else {
                string[] tab;
                string categorie, num, nbR, dest, ligne, temp, jour, mois, an;
                Date date;
                ficIn = new StreamReader(nomF);
                Vol.nombreVols = 0;
                ListeDictionaryVols.Clear();
                ligne = ficIn.ReadLine();
                while (ligne != null) {
                    categorie= ligne.Substring(0, 1);
                    num = ligne.Substring(2, 5);
                    dest = ligne.Substring(8, 20);
                    temp = ligne.Substring(29);
                    tab = temp.Split(" ");
                    jour = tab[0];
                    mois = tab[1];
                    an = tab[2];
                    nbR = tab[3]; //nombre de réservations
                    date = new Date(jour, mois, an);
                    switch (int.Parse(categorie))
                    {
                        case 4:
                            ListeDictionaryVols.Add(num, new VolBasPrix(categorie, num, dest, date, nbR, ListeAvions.ElementAt(3).Key));
                            break;
                        case 3:
                            ListeDictionaryVols.Add(num, new VolCharter(categorie, num, dest, date, nbR, ListeAvions.ElementAt(2).Key));
                            break;
                        case 2:
                            ListeDictionaryVols.Add(num, new VolRegulier(categorie, num, dest, date, nbR, ListeAvions.ElementAt(1).Key));
                            break;
                        case 1:
                            ListeDictionaryVols.Add(num, new VolPrive(categorie, num, dest, date, nbR, ListeAvions.ElementAt(0).Key));
                            break;
                    }
                    ligne = ficIn.ReadLine();
                }
                ficIn.Close();               
            }
        }
        public static void listeVols() {
            if (ListeDictionaryVols.Count > 0) {
                entete();
                Console.WriteLine("{0,65}", "LISTE DES VOLS\n");
                Console.Write(" Voulez-vous voir les vols par catégorie (O/N)?");
                choix = Console.ReadLine().ToUpper()[0];
                if (choix == 'O')
                {
                    Console.Write (" Veuillez choisir la catégorie du vol entre 1 et 4 (1-vol Privé, 2-vol Régulier, 3-vol Charter, 4-vol Bas prix): ");
                    string cat = Console.ReadLine();
                    Console.WriteLine("\n"+" Catégorie" + "\t\t" + "Numéro" + "\t" + "Destination" + "\t\t" + "Date départ" + "\t" + "Réservations" + "\t" + "Type avion");
                    foreach (KeyValuePair<string, Vol> kvp in ListeDictionaryVols)
                    {
                        if (kvp.Value.Categorie.Equals(cat)) { 
                            Console.WriteLine("{0}{1} ", " ", kvp.Value);
                        }                       
                    }                                                       
                }
                else if (choix == 'N')
                {               
                    Console.WriteLine("\n" + " Catégorie" + "\t\t" + "Numéro" + "\t" + "Destination" + "\t\t" + "Date départ" + "\t" + "Réservations" + "\t" + "Type avion");
                    foreach (KeyValuePair<string, Vol> kvp in ListeDictionaryVols)
                    {
                        Console.WriteLine("{0}{1} ", " ", kvp.Value); 
                    }
                }
            }
            else {
                chargerVols();
                listeVols();
            }
            options();
        }
        public static void retirerVol(){           
            if (ListeDictionaryVols.Count>0) {
                entete();
                Console.WriteLine("{0,66}", "RETIRER UN VOL\n");
                Console.Write(" Numéro du vol: ");
                string num = Console.ReadLine();
                if (ListeDictionaryVols.ContainsKey(num)) {                                            
                     Console.Write(" Désirer-vous vraiment retirer le vol #" + num + " (O/N) ?");
                     choix = Console.ReadLine().ToUpper()[0];
                     if (choix == 'O') {
                         ListeDictionaryVols.Remove(num);
                         Console.WriteLine("\n Le vol a été retiré\n");
                         Vol.nombreVols -= 1;                        
                         nbModif+=1;
                         options();
                     } else if (choix == 'N') {
                         options();
                     }                            
                } else {
                     Console.WriteLine("\n Le vol #" + num + " n'est pas enregistré.\n");
                     options();
                }                
            } else {
                 chargerVols();
                 retirerVol();               
            }
        }
        public static void ecrireFichier()
          {
            Console.Clear();
            entete();
            if (nbModif>0)
                {
                if (ListeDictionaryVols.Count > 0) {
                        FileStream fs = new FileStream(Utilitaires.FICHIER_OBJETS_VOLS, FileMode.Create);                    
                        BinaryFormatter formatter = new BinaryFormatter();
                        try
                        {
                            formatter.Serialize(fs, ListeDictionaryVols);
                        }
                        catch (System.Runtime.Serialization.SerializationException e)
                        {
                            Console.WriteLine("Erreur de traitement. Raison:  " + e.Message);
                            throw;
                        }
                        finally
                        {
                            fs.Close();
                        }                       
                        Utilitaires.EnregistrerObjets(Utilitaires.FICHIER_OBJETS_VOLS, ListeDictionaryVols);                        
                        Console.WriteLine("\n");
                        Console.WriteLine("{0,70}", "Information enregistrée\n");
                        Console.WriteLine("\n");
                        Console.WriteLine("{0,65}", "Au revoir...\n");                        
                }
                }
                else 
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("{0,72}", "Il n'y a rien à enregistrer\n");
                    Console.WriteLine("\n");
                    Console.WriteLine("{0,65}", "Au revoir...\n");
                    Console.ReadKey();
            }
            
          }
        public static void reserverVol()
        {
            if (ListeDictionaryVols.Count > 0)
            {
                entete();
                Console.WriteLine("{0,68}", "RÉSERVATION D'UN VOL\n");
                Console.Write(" Numéro du vol: ");                
                string num = Console.ReadLine();
                while (!Utilitaires.IsNum(num))
                {
                    Console.WriteLine(" Erreur: Vous n'avez rien saisi ou le numéro doit être positif et plus petit que 100000");
                    do
                    {

                        Console.Write(" Désirer-vous continuer (O/N) ?");
                        choix = Console.ReadLine().ToUpper()[0];
                    } while (choix != 'O' && choix != 'N') ;

                    if (choix == 'O')
                    {
                        reserverVol();
                    }
                    if (choix == 'N')
                    {
                        Console.Clear();
                        entete();
                        options();
                    }
                }
                if (ListeDictionaryVols.ContainsKey(num))
                    {
                        int temp = 0;
                        string key = ListeDictionaryVols[num].TypeAvion;
                        int nbRes = int.Parse(ListeDictionaryVols[num].NbTotalR);
                        int nbPlaces =int.Parse( ListeAvions[key].NbPlaces);
                        if (nbRes < nbPlaces)
                        {
                            int dispo = nbPlaces - nbRes;
                            Console.WriteLine("\n Destination" + " \t\t" + "Date départ" + "\t" + "Plces restantes");
                            Console.WriteLine("{0,1}{1,-20}{2,3}{3,10}{4,6}{5,1}", " ", ListeDictionaryVols[num].Dest, " ", ListeDictionaryVols[num].Date, " ", dispo);
                            Console.Write("\n Rentrer le nombre de places à réserver: ");
                            temp = int.Parse(Console.ReadLine());
                            while (temp > dispo)
                            {
                                Console.WriteLine("\n Le nombre de places restantes est " + dispo);
                                Console.Write("\n Rentrer le nombre de places à réserver: ");
                                temp = int.Parse(Console.ReadLine());
                            }
                            int total = nbRes + temp;
                            ListeDictionaryVols[num].NbTotalR = total.ToString();
                            nbModif += 1;
                            Console.WriteLine("\n La réservation a été effectuée");
                            Console.WriteLine("\n Destination" + "\t\t" + "Date départ" + "\t" + "Réservations");
                            Console.WriteLine("{0,1}{1,-20}{2,3}{3,10}{4,6}{5,1}", " ", ListeDictionaryVols[num].Dest, " ", ListeDictionaryVols[num].Date, " ", ListeDictionaryVols[num].NbTotalR);
                            options();
                        }
                        else
                        {
                            Console.WriteLine("\n Le vol est plein");
                            options();
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n Le vol #" + num + " n'est pas enregistré.\n");
                        options();                        
                    }
                }
            
            else
            {
                chargerVols();
                reserverVol();
            }
        }
        public static void modifierDate()
        {
            if (ListeDictionaryVols.Count > 0)
            {
                entete();
                Console.WriteLine("{0,76}", " MODIFICATION DE LA DATE DE DÉPART\n");
                Console.Write(" Numéro du vol: ");
                string num = Console.ReadLine();
                string[] tab;
                string temp;
                
                if (Utilitaires.IsNum(num) )
                {
                    if ( ListeDictionaryVols.ContainsKey(num))
                    {                        
                        Console.WriteLine("\n Destination" + "\t\t" + "Date départ");
                        Console.WriteLine("{0,1}{1,-20}{2,3}{3,10}", " ", ListeDictionaryVols[num].Dest, " ", ListeDictionaryVols[num].Date);
                        Console.Write("\n Veuillez rentrer la nouvelle date en format JJ/MM/AAAA: ");
                        temp = Console.ReadLine();
                        while (!Utilitaires.IsDate(temp))
                        {                            
                            Console.Write("\n Veuillez rentrer la nouvelle date en format JJ/MM/AAAA: ");
                            temp = Console.ReadLine();                                                                                        
                        }                                          
                        tab = temp.Split("/");
                        string jour = tab[0].Trim();
                        string mois = tab[1].Trim();
                        string an = tab[2].Trim();
                        Date.ValiderDate(int.Parse(jour), int.Parse(mois), int.Parse(an), ListeDictionaryVols[num].Date);                            
                        Console.WriteLine("\n La date du départ a été modifiée");
                        Console.WriteLine("\n Destination" + " \t\t" + "Date départ" + "\t" + "Réservations");
                        Console.WriteLine("{0,1}{1,-20}{2,3}{3,10}{4,6}{5,1}", " ", ListeDictionaryVols[num].Dest, " ", ListeDictionaryVols[num].Date, " ", ListeDictionaryVols[num].NbTotalR);
                        nbModif += 1;
                        options();
                    }
                    else
                    {
                        Console.WriteLine(" Ce vol n'est pas enregistré.");
                        Choix(choix);
                    }
                }
                else {
                    Console.WriteLine(" Erreur: Vous n'avez rien saisi ou le numéro doit être positif et plus petit que 100000");
                    Choix(choix);
                }
            }
            else
            {
                chargerVols();
                modifierDate();                
            }
        }
        public static void insererVol()
        {
            if (ListeDictionaryVols.Count > 0)
            {
                if (ListeDictionaryVols.Count < MAX_VOLS)
                {
                    string num, dest, jour, mois, an, temp, nbR = "0";
                    string[] tab;                   
                        Console.Clear();
                        entete();
                        Console.WriteLine("{0,71}", "SAISIE D'UN NOUVEAU VOL ");
                        Console.WriteLine("\n");
                        Console.Write(" Numéro du vol: ");
                        num = Console.ReadLine();
                        while (!Utilitaires.IsNum(num))
                        {
                            Console.WriteLine(" Erreur: Vous n'avez rien saisi ou le numéro doit être positif et plus petit que 100000");
                            Console.Write(" Désirer-vous continuer (O/N) ?");
                            choix = Console.ReadLine().ToUpper()[0];
                            if (choix == 'O')
                            {
                                insererVol();
                                options();
                            }
                            if (choix == 'N')
                            {
                                options();
                            }
                        }
                        if (!ListeDictionaryVols.ContainsKey(num))
                        {
                            Console.Write(" Déstination: ");
                            dest = Console.ReadLine();
                            while (string.IsNullOrEmpty(dest))
                            {
                                Console.Write(" Déstination: ");
                                dest = Console.ReadLine();
                            }
                            Console.Write("\n Veuillez rentrer la date en format JJ/MM/AAAA: ");
                            temp = Console.ReadLine();
                            while (!Utilitaires.IsDate(temp))
                            {
                                Console.Write("\n Veuillez rentrer la nouvelle date en format JJ/MM/AAAA: ");
                                temp = Console.ReadLine();
                            }
                            tab = temp.Split("/");
                            jour = tab[0].Trim();
                            mois = tab[1].Trim();
                            an = tab[2].Trim();
                            Date date = new Date(jour, mois, an);
                            Date.ValiderDate(int.Parse(jour), int.Parse(mois), int.Parse(an), date);
                            Console.Write(" Veuillez choisir la catégorie du vol entre 1 et 4 (1-Privé, 2-Régulier, 3-Charter et 4-Bas prix): ");
                            string cat = Console.ReadLine();
                            int c = int.Parse(cat) - 1;
                            while (!Utilitaires.IsCat(cat))
                            {
                                Console.Write(" Veuillez choisir la catégorie du vol entre 1 et 4 (1-Privé, 2-Régulier, 3-Charter et 4-Bas prix): ");
                                cat = Console.ReadLine();
                            }                                                                                                                                                           
                            Console.Write("\n Désirer-vous enregistrer ce vol (O/N) ?");
                            choix = Console.ReadLine().ToUpper()[0];
                            if (choix == 'O')
                            {
                            Console.WriteLine("\n L'information suivante a été enregistrée:\n");
                            Console.WriteLine(" Catégorie" + "\t\t" + "Numéro" + "\t" + "Destination" + "\t\t" + "Date départ" + "\t" + "Réservations" + "\t" + "Type avion");
                            Console.WriteLine(" " + Utilitaires.obtenirCat(cat) + "\t\t" + num + "\t" + dest + Utilitaires.AjouterEspacesFin(24, dest) + date + "\t" + nbR + Utilitaires.AjouterEspacesFin(16, nbR) + ListeAvions.ElementAt(c).Key);

                            switch (c)
                                 {
                                     case 3:
                                         unVol = new VolBasPrix(cat, num, dest, date, nbR, ListeAvions.ElementAt(3).Key);                                     
                                         break;
                                     case 2:
                                         unVol = new VolCharter(cat, num, dest, date, nbR, ListeAvions.ElementAt(2).Key);                                    
                                     break;
                                     case 1:
                                         unVol = new VolRegulier(cat, num, dest, date, nbR, ListeAvions.ElementAt(1).Key);                                  
                                     break;
                                     case 0:
                                         unVol = new VolPrive(cat, num, dest, date, nbR, ListeAvions.ElementAt(0).Key);                                 
                                     break;

                                 }
                            Utilitaires.obtenirClasse(unVol);
                            ListeDictionaryVols.Add(num, unVol);                            
                            nbModif += 1;
                            
                        }
                            else
                            {
                            Console.WriteLine("Ce numéro existe déĵà.");
                            options();
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n Ce numéro existe déjà.\n ");
                            options();
                        }
                        do
                        {
                            Console.Write("\n Desirez-vous créer un autre vol (O/N) ?");
                            choix = Console.ReadLine().ToUpper()[0];
                        } 
                        while (choix != 'O' && choix != 'N');
                        while (choix == 'O')
                        {
                            insererVol();
                        }
                        if (choix == 'N')
                        {
                            Console.Clear();
                            entete();
                            options();
                        }
                }
                else
                {
                    Console.WriteLine("\n Vous ne pouvez plus enregistrer de vols (limite de 100 vols atteinte) ");
                    options();
                }
            }
            else
            {
                chargerVols();
                insererVol();
            }
        }
        public static void menu()
        {
            int choix;
            Console.WriteLine(" 1.Liste de vols");
            Console.WriteLine(" 2.Ajout d'un vol");
            Console.WriteLine(" 3.Retrait d'un vol");
            Console.WriteLine(" 4.Modification de la date de départ");
            Console.WriteLine(" 5.Réservation d'un vol");
            Console.WriteLine(" 0.Terminer");
            Console.Write("{0,69}", "Faites votre choix:  ");
            choix = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choix >= 0 && choix < 6)
            {
                switch (choix)
                {
                    case 1:
                        listeVols();
                        break;
                    case 2:
                        insererVol();
                        break;
                    case 3:
                        retirerVol();
                        break;
                    case 4:
                        modifierDate();
                        break;
                    case 5:
                        reserverVol();
                        break;
                    case 0:
                        ecrireFichier();
                        break;
                }
            }
            else
            {
                entete();
                Console.WriteLine("\n L'option " + choix + " n'est pas offerte.");
                options();
            }
        }
        public static void options()
        {
            Console.WriteLine("\n Choisissez une des options ci-dessous pour continuer:\n");
            menu();
            Console.ReadKey();
        }
        public static void entete()
        {
            Console.WriteLine("\n");
            Console.WriteLine("{0,75}", "CIE AIR RELAX - GESTION DES VOLS\n");
        }

        public static void Choix(char choix)
        {
            Console.Write(" Désirer-vous modifier la date de départ d'un autre vol (O/N) ?");
            choix = Console.ReadLine().ToUpper()[0];
            while (choix == 'O')
            {
                Console.Clear();
               modifierDate();               
            }
            if (choix == 'N')
            {
                options();
            }
        }
        static void Main(string[] args)
        {
            entete();
            menu();
        }
    }
}