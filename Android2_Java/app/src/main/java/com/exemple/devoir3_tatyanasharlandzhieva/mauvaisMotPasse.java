// Travail pratique réalisé par Tatyana Sharlandzhieva, 851622
package com.exemple.devoir3_tatyanasharlandzhieva;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

public class mauvaisMotPasse extends AppCompatActivity {
    private Button back;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_mauvais_mot_passe);
        TextView tv = findViewById(R.id.passwordTextView);
        back =findViewById(R.id.back);
        back.setText(getResources().getString(R.string.back));
        Intent i = getIntent();
        String msg = i.getStringExtra("erreur");
        tv.setText(msg);
    }
    public void retour(View v){
        String msg1 = (getResources().getString(R.string.res2));
        Intent i = new Intent(this, MainActivity.class);
        i.putExtra("msg1", msg1);
        startActivity(i);
    }
}