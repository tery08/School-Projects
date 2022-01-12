//source: MaMeteoASynch de Studium
package com.exemple.devoir4_tatyanasharlandzhieva;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONException;

public class info extends AppCompatActivity {

    private int index;

    private final String debut = "https://www-labs.iro.umontreal.ca/~reid/ift1135/";
    private String milieu = "";
    private final String fin = ".json";
    private String urlApi;

    private String[] codes;
    private TextView nom, fabricant,parc, ville, longueur, hauteur;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_info2);
        Intent intent = getIntent();
        index = intent.getIntExtra("choix", 0);
        codes =  getResources().getStringArray(R.array.urls);
        nom = (TextView)findViewById(R.id.resNom);
        ville = (TextView)findViewById(R.id.resVille);
        fabricant = (TextView)findViewById(R.id.resFab);
        parc = (TextView)findViewById(R.id.resParc);
        longueur = (TextView)findViewById(R.id.resLong);
        hauteur = (TextView)findViewById(R.id.resHaut);
        urlApi =debut +codes[index] + fin ;
        new getInfo().execute(urlApi);
    }

    private class getInfo extends AsyncTask<String, String, ApiWeb> {
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            Toast.makeText(info.this,"Json Data is downloading",Toast.LENGTH_SHORT).show();
        }

        @Override
        protected ApiWeb doInBackground(String... params) {
            ApiWeb api = new ApiWeb(params[0]);
            return api;
        }

        @Override
        protected void onPostExecute(ApiWeb apiWeb) {
            super.onPostExecute(apiWeb);

            if (apiWeb == null) {
                Log.d("info","apiWeb est null");
                return;
            }
            if(apiWeb.getErreur().equals("")){

                nom.setText(" " + apiWeb.getNom());
                ville.setText(" " + apiWeb.getVille());
                fabricant.setText(" " + apiWeb.getFabricant());
                parc.setText(" " + apiWeb.getParc());
                longueur.setText(" " + apiWeb.getLongueur());
                hauteur.setText(" " + apiWeb.getHauteur());
            }
            else
                Log.d("info", apiWeb.getErreur());
        }
    }

    public void retour(View v){
        Intent i = new Intent(this, MainActivity.class);
        startActivity(i);
    }
}