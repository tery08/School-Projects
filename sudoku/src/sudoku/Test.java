
package sudoku;

// diif. packages necéssaires pour lire et écrire des fichiers, gérer les exceptions et utiliser des ArrayList
import java.io.File;           
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;
import java.util.ArrayList;

    //classe "Test" et ces atributs et méthodes.
    public class Test {
    static ArrayList<Integer> al=new ArrayList<Integer>();
    static String nomFichier;
    static FileReader file= null;     //instance de classe FileReader, nécessaire pour lire le fichier
    Grille tableau;                   //instance de classe "Grille"
     
     
     
    //méthode pour afficher le menu, qui entraîne l'utilisation de différentes méthodes selon le choix du joueur
    public void affichageMenu(){
        
        System.out.println("Veuillez choisir un des choix suivants: ");
        System.out.println("1.Charger jeu");
        System.out.println("2.Jouer Sudoku");
        System.out.println("3.Quitter");
        Scanner sc=new Scanner(System.in);
        int reponse=sc.nextInt();
        System.out.println("Votre choix: "+reponse);
        System.out.println();
        if(reponse==1){  
          chargerJeu();    
        }
        if(reponse==2){ 
          jouerSudoku(); 
          messages();
        }
        if(reponse==3){
          quitterJeu(); 
        } 
    }
    
    //Méthode permettant de fournir le nom de fichier (qui sera utilisé pour charger la grille).
    //Utilisation de la constrction "try-catch" pour detecter des erreurs.Affichage d'un message d'erreur personnalisé.
    public void chargerJeu(){
    System.out.println("Veuillez fournir le nom du fichier: ");
    Scanner ab=new Scanner(System.in);
    nomFichier=ab.nextLine();
    try{
        file=new FileReader(nomFichier);
        int i=0;
        Scanner input=new Scanner(file); 
            while(input.hasNext()){
            al.add(input.nextInt());
            i++;
            }
        input.close(); 
        System.out.println("Fichier chargé!"); 
        System.out.println();
        tableau=new Grille(al);
        tableau.imprimerGrille();
        System.out.println();
        messages();
    }catch (IOException e){
         System.out.println("Erreur, fichier inexistant!");
         chargerJeu();  
      }   
    }  
    
    //Méthode donnant au joueur la possibilité de fournir la ligne,la colonne est la valeur par le clavier.
    //On valide si cette place est disponible pour la chiffre choisie.Affichage de la grille en tenant compte des changements. 
    //Le jeu est chargé par la méthode lectureFichier() directement a partir de fichier "partie 1", enregistré dans le projet.
    public void jouerSudoku(){
    lectureFichier(); 
    tableau=new Grille(al);
    System.out.println("Veuillez choisir une ligne: ");
    Scanner ab=new Scanner(System.in);
    int lin=ab.nextInt();
    
    System.out.println("Veuillez choisir une colonne: ");
    Scanner dc=new Scanner(System.in);
    int col=dc.nextInt();
    System.out.println("Veuillez choisir une valeur: ");
    Scanner rl=new Scanner(System.in);
    int val=rl.nextInt();
        if(tableau.placeLibre(lin, col, val)){
            System.out.println("Bravo! La valeur "+val+" a été insérée dans la case ("+lin+","+col+")."); 
            System.out.println();
            tableau.grille[lin][col]=val;
            tableau.imprimerGrille();
            tableau.cellule.setLigne(lin);
            tableau.cellule.setColonne(col);
            tableau.cellule.setValeur(tableau.grille[lin][col]);
            al.add((tableau.cellule.getLigne()*100)+(tableau.cellule.getColonne()*10)+tableau.cellule.getValeur());
               
        }else{
            System.out.println("Erreur, la grille comporte déjà la valeur "+val+" dans ligne "+lin+" ou dans colonne "+col+" ou dans le bloc représentant la case ("+lin+","+col+").");
            System.out.println();   
            tableau.grille[lin][col]=val;
            tableau.imprimerGrille();
            
        }                        
    } 
    
    //Méthoge permettant de continuer selon le choix du joueur  
    public void messages(){    
    System.out.println("Veuillez choisir un des choix suivants: ");
    System.out.println("1.Sauvgarder jeu.");
    System.out.println("2.Jouer Sudoku.");
    System.out.println("3.Quitter.");
    Scanner sc=new Scanner(System.in);
    int reponse=sc.nextInt();
    System.out.println("Votre choix: "+reponse);
    System.out.println();
        if(reponse==1){
          SauvGrille();  
        }
        if(reponse==2){   
          jouerSudoku();
          
          messages();
        }  
        if(reponse==3){
          quitterJeu();  
        }
    }
    

    //méthode permettant de sauvgarder la grille (en utilisant la métohode "grilleToArrayList" de la classe "Grille") dans un fichier txt
    //Si le fichier n'existe pas, il sera créé à la racine du projet Java
    public void SauvGrille(){
    System.out.println("Veuillez fournir le nom du fichier");
    Scanner ab=new Scanner(System.in);
    String output=ab.nextLine();
    try {   
    File file=new File(output);
    FileWriter fw= new FileWriter(file);
    PrintWriter pw=new PrintWriter(fw);
    for(Integer la: tableau.grilleToArrayList(al)) {
    pw.print(la+" ");
    }
    pw.close();
    }catch (IOException e){
    e.printStackTrace();
    }System.out.println("Fichier sauvgardé!");
    messages();
    }
    
    //méthode permettant de jouer si au début le joueur chosi option 2.
    //La grille sera chargé directement du fichier "partie 1", sans demander le joueur.Le fichier existe dans le projet. 
    public void lectureFichier(){
       try{
        file=new FileReader("partie 1");
        int i=0;
        Scanner input=new Scanner(file); 
            while(input.hasNext()){
            al.add(input.nextInt());
            i++;
            }
        input.close(); 
        System.out.println();
        }catch (IOException e){
        e.printStackTrace();     
        }
      } 
        
    
    //méthode pour sortir du jeu
    public void quitterJeu(){
    System.out.println("Merci d'avoir joué au jeu sudoku");
    }
    
}
 


