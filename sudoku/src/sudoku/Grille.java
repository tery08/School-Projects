
package sudoku;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

//classe "Grille" et ces attributs et méthodes
public class Grille {
  
  int[][] grille = new int[9][9]; 
  int k=0,l=0,i=0,t=0;
  Case cellule=new Case();
  
  //Constructeur de la classe avec un arrayList en argument, permettant d'initialiser le tableau grille à partir d'arrayList.
  //On utilise une instance de la classe "Case" et ces getters et setters.
    public Grille(ArrayList<Integer> ra){
        for(k=0;k<grille.length;k++){
            for(l=0;l<grille.length;l++){
                for(i=0;i<ra.size();i++){
                    if(ra.get(i)<100){
                    cellule.setLigne(0);
                    cellule.setColonne(ra.get(i)/10);
                    cellule.setValeur(ra.get(i)%10);
                        if(ra.get(i)!=(cellule.getLigne()+cellule.getColonne()*10+cellule.getValeur())){
                        grille[k][l]=0;
                        }else{
                        grille[cellule.getLigne()][cellule.getColonne()]=cellule.getValeur();
                        }
                    }else{ 
                    cellule.setLigne(ra.get(i)/100);
                    cellule.setColonne(ra.get(i)%100/10);
                    cellule.setValeur((ra.get(i)%100)%10);
                        if(ra.get(i)!=(cellule.getLigne()*100+cellule.getColonne()*10+cellule.getValeur())){
                        grille[k][l]=0;
                        }else{
                        grille[cellule.getLigne()][cellule.getColonne()]=cellule.getValeur();
                        }  
                    }   
                }     
            }
        }                 
    } 
  
    //méthode permettant d'obtenir un arrayList, qui sera souvgardé par la méthode SauvGrille() de la classe Test dans un fichier txt.                                   
    public ArrayList<Integer> grilleToArrayList(ArrayList<Integer> sa){
        ArrayList<Integer> am=new ArrayList<Integer>();
        Set<Integer> set = new HashSet<>(sa);
        sa.clear();
        sa.addAll(set);
        am.addAll(sa);
        Collections.sort(am);    
        return am;    
       }     
                 
             
    //méthode qui confirme que la valeur fournie est sur la ligne choisie. 
    private boolean estSurLigne(int ligne,int valeur){
        for(int i=0;i<9;i++){
            if(grille[ligne][i] == valeur)
            return true;
        }   
    return false;
    }
          
    //méthode qui confirme que la valeur fournie est sur la colonne choisie.     
    private boolean estSurColonne(int colonne,int valeur){
        for(int i=0;i<9;i++){
            if(grille[i][colonne] == valeur)
            return true;
        }
    return false;
    }
          
    //méthode qui confirme que la valeur choisie se trouve dans le bloc contenant la case définie par les valeurs de "ligne" et "colonne" fournies par le joueur.      
    private boolean estDansLeBloc(int ligne, int colonne, int valeur){
    int a=ligne-ligne%3;
    int b=colonne-colonne%3;
        for (i=a;i<a+3; i++){
            for(int j=b;j<b+3;j++){
                if(grille[i][j]==valeur)
                return true;
            }
        }
     return false;
    }    
        
    // méthode qui confirme que le chiffre("valeur" fournie) choisi peut prendre la place choisie (définie par les valeurs de "ligne" et "colonne" fournies par le joueur) 
    public boolean placeLibre(int ligne, int colonne, int valeur) {
    return !estSurLigne(ligne, valeur)  &&  !estSurColonne(colonne, valeur)  &&  !estDansLeBloc(ligne, colonne, valeur);
    
    }
          
    // méthode permettant d'afficher la grille
    public void imprimerGrille(){
        while(t<9){
            for( k=t;k<t+3;k++){
            i=0;
            System.out.print("ǀ ");
                for( int r=0;r<3;r++){
                    for(l=i;l<3+i;l++){
                     System.out.printf("%-2d",grille[k][l]);    
                    }
                System.out.print("ǀ ");
                i=i+3;
                }
            System.out.println();
            }
        t=t+3;
        System.out.println("------------------------");
        }
    }
}        


