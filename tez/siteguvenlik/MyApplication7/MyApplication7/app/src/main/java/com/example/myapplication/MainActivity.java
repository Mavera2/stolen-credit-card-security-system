package com.example.myapplication;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;

import android.Manifest;
import android.annotation.SuppressLint;
import android.content.Context;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.database.Cursor;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.wifi.WifiManager;
import android.os.Bundle;
import android.text.Html;
import android.text.format.Formatter;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.location.FusedLocationProviderClient;
import com.google.android.gms.location.LocationServices;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class MainActivity extends AppCompatActivity {

    EditText ad, soyad, email, adres, sehir, dtarihi, telno;
    EditText KART, skt, cvv;
    Button insert, view;
    DBHelper DB;


    TextView ip;


    public void dosyaYaz(String fileName, String veriler) {
        File path = getApplicationContext().getFilesDir();
        try {
            FileOutputStream writer = new FileOutputStream(new File(path, fileName));
            writer.write(veriler.getBytes());
            writer.close();
            Toast.makeText(getApplicationContext(), "Dosya Yazıldı " + fileName, Toast.LENGTH_SHORT).show();

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        ip = (TextView) findViewById(R.id.ip);
        WifiManager wifiManager = (WifiManager) getApplicationContext().getSystemService(WIFI_SERVICE);
        ip.setText("IP Adresiniz:" + Formatter.formatIpAddress(wifiManager.getConnectionInfo().getIpAddress()));

        ad = findViewById(R.id.ad);
        soyad = findViewById(R.id.soyad);
        email = findViewById(R.id.email);
        adres = findViewById(R.id.adres);
        sehir = findViewById(R.id.sehir);
        dtarihi = findViewById(R.id.dtarihi);
        telno = findViewById(R.id.telno);

        KART = findViewById(R.id.KART);
        skt = findViewById(R.id.skt);
        cvv = findViewById(R.id.cvv);

        insert = findViewById(R.id.btnInsert);
        view = findViewById(R.id.btnVıew);


        DB = new DBHelper(this);
        insert.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {


                String adTXT = ad.getText().toString();
                String soyadTXT = soyad.getText().toString();
                String emailTXT = email.getText().toString();
                String adresTXT = adres.getText().toString();
                String sehirTXT = sehir.getText().toString();
                String dtarihiTXT = dtarihi.getText().toString();
                String telnoTXT = telno.getText().toString();

                String kartTXT = KART.getText().toString();
                String sktTXT = skt.getText().toString();
                String cvvTXT = cvv.getText().toString();

                dosyaYaz("file.txt", Formatter.formatIpAddress(wifiManager.getConnectionInfo().getIpAddress()));

                Boolean checkinsertdata = DB.insertuserdata(adTXT, soyadTXT, emailTXT, adresTXT, sehirTXT, dtarihiTXT, telnoTXT);

                if (checkinsertdata == true)
                    Toast.makeText(MainActivity.this, "Yeni Kayıt Girildi", Toast.LENGTH_SHORT).show();
                else
                    Toast.makeText(MainActivity.this, "Yeni Kayıt Girilemedi!!", Toast.LENGTH_SHORT).show();

                Cursor res3 = DB.getData();
                StringBuffer buffer = new StringBuffer();


                while (res3.moveToNext() && res3.moveToLast()) {

                    buffer.append(res3.getString(7));
                    break;

                }

                Boolean checkinsertcard = DB.insertusercard(buffer.toString(), kartTXT, sktTXT, cvvTXT, Formatter.formatIpAddress(wifiManager.getConnectionInfo().getIpAddress()));
                if (checkinsertcard == true)
                    Toast.makeText(MainActivity.this, "Yeni Kayıt Girildi", Toast.LENGTH_SHORT).show();
                else
                    Toast.makeText(MainActivity.this, "Yeni Kayıt Girilemedi!!", Toast.LENGTH_SHORT).show();


            }
        });

        view.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Cursor res = DB.getData();
                Cursor res2 = DB.getData2();

                if (res.getCount() == 0) {
                    Toast.makeText(MainActivity.this, "Kayıt Bulunamadı", Toast.LENGTH_SHORT).show();
                    return;
                }
                if (res2.getCount() == 0) {
                    Toast.makeText(MainActivity.this, "Kayıt Bulunamadı", Toast.LENGTH_SHORT).show();
                    return;
                }
                StringBuffer buffer = new StringBuffer();
                StringBuffer buffer2 = new StringBuffer();
                while (res.moveToNext()) {
                    buffer.append("Kullanıcı No: " + res.getString(0) + "\n");
                    buffer.append("Ad: " + res.getString(1) + "\n");
                    buffer.append("Soyad: " + res.getString(2) + "\n");
                    buffer.append("Email: " + res.getString(3) + "\n");
                    buffer.append("Adres: " + res.getString(4) + "\n");
                    buffer.append("Sehir: " + res.getString(5) + "\n");
                    buffer.append("Dtarihi: " + res.getString(6) + "\n");
                    buffer.append("TelNo: " + res.getString(7) + "\n\n");

                }
                while (res2.moveToNext()) {
                    buffer2.append("Tel No: " + res2.getString(1) + "\n");
                    buffer2.append("Kart No: " + res2.getString(2) + "\n");
                    buffer2.append("Kart SKT: " + res2.getString(3) + "\n");
                    buffer2.append("Kart CVV: " + res2.getString(4) + "\n");
                    buffer2.append("IP Adres: " + res2.getString(5) + "\n\n");
                }
                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.this);
                builder.setCancelable(true);
                builder.setTitle("Kullanıcı Girisleri");
                builder.setMessage(buffer.toString());
                builder.show();

                AlertDialog.Builder builder2 = new AlertDialog.Builder(MainActivity.this);
                builder2.setCancelable(true);
                builder2.setTitle("Kullanıcı Kart Girisleri");
                builder2.setMessage(buffer2.toString());
                builder2.show();


            }
        });
    }
}