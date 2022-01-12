// Travail pratique réalisé par Tatyana Sharlandzhieva, 851622
package com.exemple.devoir3_tatyanasharlandzhieva;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Typeface;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;


public class MainActivity extends AppCompatActivity {
    private String ch;
    private String sNom, sPass;
    private TextView mess;
    private TextView name;
    private TextView password;
    private Typeface type;
    private EditText etNom, etPass;
    private SharedPreferences msp1;
    private Button submit;
    private Button clear;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        String ch ="12345";
        submit =findViewById(R.id.submit);
        submit.setText(getResources().getString(R.string.submit));
        clear =findViewById(R.id.clear);
        clear.setText(getResources().getString(R.string.clear));
        name =findViewById(R.id.nameTextView);
        name.setText(getResources().getString(R.string.name));
        password =findViewById(R.id.passTextView);
        password.setText(getResources().getString(R.string.password));

        etNom=findViewById(R.id.nameEditText);
        etPass=findViewById(R.id.passEditText);
        sNom=etNom.getText().toString();
        sPass=etPass.getText().toString();

        Intent i = getIntent();
        mess=findViewById(R.id.resultat2);
        //mess.setTypeface(type,Typeface.BOLD);
        mess.setTextColor(Color.RED);
        mess.setTextSize(20);
        String msg1 = i.getStringExtra("msg1");
        mess.setText(msg1);

        TextView tv1 = findViewById(R.id.resultat);
        Intent in = getIntent();
        String notes = in.getStringExtra("notes");
        if(notes!=null) {
            tv1.setText((getResources().getString(R.string.note))+" "+notes);
        }
        msp1=getSharedPreferences("myPref",Context.MODE_PRIVATE);
        String n = msp1.getString("keyn", " ");
        etNom.setText(n);
        String p = msp1.getString("keyp", "");
        etPass.setText(p);
    }

    public void login(View v){
        etNom=findViewById(R.id.nameEditText);
        etPass=findViewById(R.id.passEditText);
        sNom=etNom.getText().toString();
        sPass=etPass.getText().toString();
        if( sPass.equals("12345") && !sNom.equals("")){
            Intent i = new Intent(this, fen2.class);
            i.putExtra("leNom", sNom);
            startActivity(i);

            SharedPreferences.Editor edit = msp1.edit();
            edit.putString("keyn", sNom);
            edit.putString("keyp", sPass);
            edit.apply();
        }else{
            String msg = (getResources().getString(R.string.missInfo));
            Intent i = new Intent(this, mauvaisMotPasse.class);
            i.putExtra("erreur", msg);
            startActivity(i);
        }
    }

    public void clear(View view) {
        etNom=findViewById(R.id.nameEditText);
        etNom.setText("");
        etPass=findViewById(R.id.passEditText);
        etPass.setText("");
        mess.setText(" ");
        TextView tv1 = findViewById(R.id.resultat);
        tv1.setText(" ");
        SharedPreferences.Editor edit = msp1.edit();
        edit.clear();
        edit.apply();
    }
}