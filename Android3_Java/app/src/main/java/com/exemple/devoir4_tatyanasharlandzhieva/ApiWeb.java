//source: MaMeteoASynch de Studium
package com.exemple.devoir4_tatyanasharlandzhieva;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

public class ApiWeb {

    private String nom, ville, parc, fabricant, longueur, hauteur;
    private String erreur="";

    public ApiWeb(String url){
        String pageJson = "";
        HttpURLConnection con = null;
        URL donneesURL = null;

        try{
            donneesURL = new URL(url);
            con = (HttpURLConnection)donneesURL.openConnection();
            con.connect();
            if(true || con.getResponseCode() == HttpURLConnection.HTTP_OK) {
                InputStream fEntree = con.getInputStream();
                BufferedReader entree = new BufferedReader(new InputStreamReader(fEntree));
                String ligne;
                while ((ligne = entree.readLine()) != null) {
                    pageJson += ligne;
                }

                entree.close();

                JSONObject reponseJson = new JSONObject(pageJson);
                JSONObject lesInfos = reponseJson.getJSONObject("manege");
                nom = lesInfos.getString("nom");
                fabricant = lesInfos.getString("fabricant");
                JSONObject details = lesInfos.getJSONObject("emplacement");
                parc = details.getString("parc");
                ville = details.getString("ville");
                JSONObject details1 = lesInfos.getJSONObject("tracks");
                longueur = details1.getString("longueur");
                hauteur = details1.getString("hauteur");

                con.disconnect();  // fermer la connection
            }
        } catch (MalformedURLException e) {
            erreur += "URL mal formé\n";
        } catch (IOException e) {
            erreur += "Problème ouverture de connection\n";
        } catch (JSONException e) {
            erreur += "Erreur JSON\n";
        }
    }


    public String getNom(){
        return nom;
    }
    public String getFabricant(){
        return fabricant;
    }
    public String getParc() {
        return parc;
    }
    public String getVille() {
        return ville;
    }
    public String getLongueur(){
        return longueur;
    }
    public String getHauteur(){
        return hauteur;
    }
    public String getErreur(){
        return erreur;
    }

}


