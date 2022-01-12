//source: MaMeteoASynch de Studium
package com.exemple.devoir4_tatyanasharlandzhieva;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;

public class MainActivity extends AppCompatActivity {
    private ListView liste;
    private String[] maneges;
    private int choix;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        maneges = getResources().getStringArray(R.array.maneges);
        liste = findViewById(R.id.choix);
        Intent intent = new Intent(this, info.class);
        liste.setChoiceMode(ListView.CHOICE_MODE_SINGLE);
        liste.setAdapter(new ArrayAdapter<String>(this,android.R.layout.simple_list_item_multiple_choice,maneges));
        liste.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                choix=i;
                intent.putExtra("choix", choix);
                startActivity(intent);
            }
        });
    }
}