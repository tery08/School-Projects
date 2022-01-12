//Travail pratique réalisé par Tatyana Sharlandzhieva, 851622
//Classe Jeu-source: Studium

package com.exemple.tp2;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;


import android.graphics.Typeface;
import android.media.MediaPlayer;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.graphics.Color;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {
    private Button[]table = new Button [9];
    private Jeu unJeu;
    private int[]tabGagne= new int[3];
    private boolean termine=false;
    private TextView tv;
    private TextView v;
    private Typeface type;
    private Typeface type1;
    private Button btn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        table[0] = findViewById(R.id.button0);
        table[1] = findViewById(R.id.button1);
        table[2] = findViewById(R.id.button2);
        table[3] = findViewById(R.id.button3);
        table[4] = findViewById(R.id.button4);
        table[5] = findViewById(R.id.button5);
        table[6] = findViewById(R.id.button6);
        table[7] = findViewById(R.id.button7);
        table[8] = findViewById(R.id.button8);
        v=findViewById(R.id.textView);
        v.setTextColor(Color.WHITE);
        type1 = v.getTypeface();
        v.setTypeface(type1,Typeface.BOLD);
        v.setTextSize(18);
        btn =findViewById(R.id.newGame);
        btn.setText(getResources().getString(R.string.nouveau));
        btn.setBackgroundColor(Color.WHITE);
        btn.setTextColor(Color.LTGRAY);
        for( int i = 0; i<9; i++){ table[i].setBackgroundColor(Color.WHITE);
            table[i].setTextColor(Color.DKGRAY);
        }
        unJeu=new Jeu();
    }

    public void nouveau (View v){
        termine = false;
        for( int i = 0; i<9; i++) {
            table[i].setText("");
            table[i].setTextColor(Color.DKGRAY);
            table[i].setBackgroundColor(Color.WHITE);
        }
        for(int j=0; j<3; j++){
            tabGagne[j]=0;
        }
        unJeu.initialise();
        tv.setText(" ");
        btn.setBackgroundColor(Color.WHITE);
        btn.setTextColor(Color.LTGRAY);
    }

    public int pos(Button c){
        int i=0;
        while(table[i]!= c)
            i++;
        return i;
    }

    public void marquer(int[]posGagnante){
        for(int i=0 ;i<3;i++){
            table[posGagnante[i]].setTextColor(Color.BLUE);
            table[posGagnante[i]].setBackgroundColor(Color.YELLOW);
            termine=true;
            btn.setBackgroundColor(Color.WHITE);
            btn.setTextColor(Color.DKGRAY);
        }
    }

    public void choix (View v){
        Button choix=(Button)v;
        int i;
        if(choix.getText().toString().equals("") && termine!=true){
            choix.setText("X");
             i = pos(choix);
            unJeu.setX(i);
                if(unJeu.gagnant ("X",tabGagne)){
                    marquer(tabGagne);
                    String message=(getResources().getString(R.string.msg));
                    tv = findViewById(R.id.ticTextView);
                    type = tv.getTypeface();
                    tv.setTypeface(type,Typeface.BOLD);
                    tv.setTextColor(Color.WHITE);
                    tv.setTextSize(20);
                    tv.setText("X "+message);
                    btn.setBackgroundColor(Color.YELLOW);
                    btn.setTextColor(Color.DKGRAY);

                }else if(unJeu.isPartieNulle()== false){
                       i = unJeu.getO();
                       table[i].setText("O");
                        if(unJeu.gagnant ( "O",tabGagne)) {
                            MediaPlayer media=MediaPlayer.create(this, R.raw.sound2);
                            media.start();
                            marquer(tabGagne);
                            String message=(getResources().getString(R.string.msg));
                            tv = findViewById(R.id.ticTextView);
                            type = tv.getTypeface();
                            tv.setTypeface(type,Typeface.BOLD);
                            tv.setTextColor(Color.YELLOW);
                            tv.setTextSize(20);
                            tv.setText("O "+message);
                            btn.setBackgroundColor(Color.YELLOW);
                            btn.setTextColor(Color.DKGRAY);
                        }
                }else if(unJeu.isPartieNulle()== true){
                    MediaPlayer media1=MediaPlayer.create(this, R.raw.sound1);
                    media1.start();
                    String message=(getResources().getString(R.string.nulle));
                    tv = findViewById(R.id.ticTextView);
                    type = tv.getTypeface();
                    tv.setTypeface(type,Typeface.BOLD);
                    tv.setTextColor(Color.YELLOW);
                    tv.setTextSize(20);
                    tv.setText(message);
                    btn.setBackgroundColor(Color.YELLOW);
                    btn.setTextColor(Color.DKGRAY);
                }

        }
    }
   /* @Override
    public void onRestoreInstanceState(Bundle  saveState) {
        super.onRestoreInstanceState( saveState);


        tv= findViewById(R.id.ticTextView);
        tv.setText(saveState.getString("zone"));


        table[0] = findViewById(R.id.button0);
        table[0].setText(saveState.getString("bt0"));
        table[1] = findViewById(R.id.button1);
        table[1].setText(saveState.getString("bt1"));
        table[2] = findViewById(R.id.button2);
        table[2].setText(saveState.getString("bt2"));
        table[3] = findViewById(R.id.button3);
        table[3].setText(saveState.getString("bt3"));
        table[4] = findViewById(R.id.button4);
        table[4].setText(saveState.getString("bt4"));
        table[5] = findViewById(R.id.button5);
        table[5].setText(saveState.getString("bt5"));
        table[6] = findViewById(R.id.button6);
        table[6].setText(saveState.getString("bt6"));
        table[7] = findViewById(R.id.button7);
        table[7].setText(saveState.getString("bt7"));
        table[8] = findViewById(R.id.button8);
        table[8].setText(saveState.getString("bt8"));
    }

    @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
    @Override
    public void onSaveInstanceState(Bundle  outState) {
        super.onSaveInstanceState( outState);
        outState.putString("zone", ((TextView)findViewById(R.id.ticTextView)).getText().toString());
        outState.putString("bt0", ((Button)findViewById(R.id.button0)).getText().toString());
        outState.putString("bt1", ((Button)findViewById(R.id.button1)).getText().toString());
        outState.putString("bt2", ((Button)findViewById(R.id.button2)).getText().toString());
        outState.putString("bt3", ((Button)findViewById(R.id.button3)).getText().toString());
        outState.putString("bt4", ((Button)findViewById(R.id.button4)).getText().toString());
        outState.putString("bt5", ((Button)findViewById(R.id.button5)).getText().toString());
        outState.putString("bt6", ((Button)findViewById(R.id.button6)).getText().toString());
        outState.putString("bt7", ((Button)findViewById(R.id.button7)).getText().toString());
        outState.putString("bt8", ((Button)findViewById(R.id.button8)).getText().toString());


    }*/
}


