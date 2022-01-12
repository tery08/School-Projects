// Travail pratique réalisé par Tatyana Sharlandzhieva, 851622
package com.exemple.devoir3_tatyanasharlandzhieva;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import android.app.ListActivity;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;


public class fen2 extends AppCompatActivity  {
    private ListView liste;
    private String[] noms;
    private String prenom;
    private String nom;
    private String user="";
    private String choix;
    private TextView tv;
    private TextView tv1;
    private TextView nomChoix;
    private String tatyana="tatyana";
    private String bilbo="bilbo";
    private String anakin = "anakin";
    private float total=0;
    private float tnote=0;
    private float bnote=0;
    private float anote=0;
    private float t=0;
    private float b=0;
    private float a=0;
    private SharedPreferences msp;
    private Button backReg;

    @RequiresApi(api = Build.VERSION_CODES.N)
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fen2);
        nomChoix =findViewById(R.id.nomChoix);
        nomChoix.setText(getResources().getString(R.string.choose));
        backReg =findViewById(R.id.retourDebut);
        backReg.setText(getResources().getString(R.string.backReg));
        msp=getSharedPreferences("myPref",Context.MODE_PRIVATE);
         t = msp.getFloat("tnote", 0);
        b = msp.getFloat("bnote", 0);
        a = msp.getFloat("anote", 0);

        tv=findViewById(R.id.nomTextView);
        Intent i = getIntent();
        nom = i.getStringExtra("leNom");
        if(nom!=null) {
            tv.setText(getResources().getString(R.string.welcome) +" "+ nom);
        }
        Intent in = getIntent();
        user = in.getStringExtra("user1");
        if(user!=null){
        tv.setText(getResources().getString(R.string.welcome) +" "+ user);
        }

        String prenom2 = in.getStringExtra("nom");
        Double note = in.getDoubleExtra("note",0);
        Float fnote=note.floatValue();

        if(tatyana.equals(prenom2)){
            SharedPreferences.Editor edit = msp.edit();
            tnote=note.floatValue();
            edit.putFloat("tnote", tnote);
            edit.apply();
            total=fnote+b+a;
            String n=Float.toString(total);
        }

        if(anakin.equals(prenom2)){
            SharedPreferences.Editor edit = msp.edit();
            anote=note.floatValue();
            edit.putFloat("anote", anote);
            edit.apply();
            total=fnote+b+t;
            String n=Float.toString(total);
        }

        if(bilbo.equals(prenom2)){
            SharedPreferences.Editor edit = msp.edit();
            bnote=note.floatValue();
            edit.putFloat("bnote", bnote);
            edit.apply();
            total=fnote+t+a;
            String n=Float.toString(total);
        }

        noms = getResources().getStringArray(R.array.noms_array);
        liste = findViewById(R.id.list);
        Intent intent = new Intent(this, fen3.class);
        liste.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        liste.setAdapter(new ArrayAdapter<String>(this,android.R.layout.simple_list_item_single_choice,noms));
        liste.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                choix=(noms[i]);
                String arr []=choix.split(" ");
                prenom=arr [0].toLowerCase();
                intent.putExtra("choix", prenom);
                if(nom!=null) {
                    intent.putExtra("user", nom);
                }
                if(user!=null)
                {
                    intent.putExtra("user", user);
                }
                startActivity(intent);
            }
        });
    }

    public void debut(View v){
        Intent i = new Intent(this, MainActivity.class);
        String s=String.valueOf(total);
        i.putExtra("notes", s);
        startActivity(i);
    }
}
