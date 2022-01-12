// Travail pratique réalisé par Tatyana Sharlandzhieva, 851622
//source pour l'image:https://stackoverflow.com/questions/11737607/how-to-set-the-image-from-drawable-dynamically-in-android

package com.exemple.devoir3_tatyanasharlandzhieva;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.graphics.Typeface;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;


public class fen3 extends AppCompatActivity {
    private TextView tv;
    private TextView tv1;
    private TextView message;
    private ImageView iv;
    private String nom;
    private String user;
    private String ch = "";
    private String total="";
    private Typeface type;
    private SharedPreferences msp;
    private Button backList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_fen3);
        msp=getSharedPreferences("myPref", Context.MODE_PRIVATE);
        String n = msp.getString("us", " ");
        Intent intent = getIntent();
        nom = intent.getStringExtra("choix");
        user = intent.getStringExtra("user");
        tv=findViewById(R.id.infoTextView);
        tv1=findViewById(R.id.testTextView);
        tv1.setText(getResources().getString(R.string.welcome)+" "+user);
        backList =findViewById(R.id.retour);
        backList.setText(getResources().getString(R.string.backList));
        message =findViewById(R.id.noteTextView);
        message.setText(getResources().getString(R.string.appreciation));

        String resourceId = "@drawable/"+nom;
        int imageResource = getResources().getIdentifier(resourceId, null, getPackageName());
        Drawable drawable = ContextCompat.getDrawable(this, imageResource);
        iv = (ImageView) findViewById(R.id.imageView);
        iv.setImageDrawable(drawable);

        int fileRes = getResources().getIdentifier(nom, "raw", getPackageName());
        InputStream is = getResources().openRawResource(fileRes);
        InputStreamReader isr = new InputStreamReader(is);
        BufferedReader entree = new BufferedReader(isr);
        try {
            while  ((ch = entree.readLine()) != null) {
                total+=ch+"\n";
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
        tv.setText(total);
    }

    public void click(View v){
        String sNote;
        EditText note;
        note=findViewById(R.id.noteEditText);
        sNote=note.getText().toString();
        Double n=Double.valueOf(sNote);
        if(n>=0.0 && n<=3.0){
            Intent in = new Intent(this, fen2.class);
            in.putExtra("note", n);
            in.putExtra("nom", nom);
            if(user!=null) {
                in.putExtra("user1", user);
            }
            startActivity(in);
        }else{
            message=findViewById(R.id.noteTextView);
            message.setTypeface(type, Typeface.BOLD);
            message.setTextColor(Color.RED);
        }
    }
}