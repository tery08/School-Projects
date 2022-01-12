
package sudoku;

import java.util.ArrayList;

//classe "Case" et ces attributs
public class Case {
    private int ligne;
    private int colonne;
    private int valeur;
   
    
    
    //méthodes donnant la  possibilité d'accéder ou changer la valeur des variables depuis l'exterieur de cette classe
    public int getLigne(){
    return ligne;
    }
    public int getColonne(){
    return colonne;
    }
    public int getValeur(){
    return valeur;
    }
    public void setLigne(int newLigne) {
    this.ligne = newLigne;
    }
    public void setColonne(int newColonne) {
    this.colonne = newColonne;
    }
    public void setValeur(int newValeur) {
    this.valeur = newValeur;
    }
}
