package com.example.myapplication;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.text.Html;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;

import java.io.IOException;
import java.util.List;
import java.util.Locale;

public class DBHelper extends SQLiteOpenHelper {
    public DBHelper(Context context) {
        super(context, "Kullanicilar.db", null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase DB) {
        DB.execSQL("create Table KullaniciDetay(kul_id REAL NOT NULL  DEFAULT (RANDOM()),ad text NOT NULL,soyad text NOT NULL,email text NOT NULL,adres text NOT NULL,sehir text NOT NULL,dtarihi text NOT NULL,telno text PRIMARY KEY NOT NULL )");
        DB.execSQL("create Table KullaniciKart(kart_id INTEGER  PRIMARY KEY AUTOINCREMENT,telno text NOT NULL,KART text NOT NULL,skt text NOT NULL,cvv text NOT NULL,ip text NOT NULL,FOREIGN KEY (telno)REFERENCES KullaniciDetay (telno) ON UPDATE CASCADE ON DELETE CASCADE)");    }




    @Override
    public void onUpgrade(SQLiteDatabase DB, int i, int i1) {
        DB.execSQL("drop Table if exists KullaniciDetay");
        DB.execSQL("drop Table if exists KullaniciKart");
    }

    public Boolean insertuserdata(String ad,String soyad,String email,String adres,String sehir,String dtarihi,String telno){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues= new ContentValues();
        contentValues.put("ad",ad);
        contentValues.put("soyad",soyad);
        contentValues.put("email",email);
        contentValues.put("adres",adres);
        contentValues.put("sehir",sehir);
        contentValues.put("dtarihi",dtarihi);
        contentValues.put("telno",telno);

        long result=DB.insert("KullaniciDetay",null,contentValues);
        if (result==-1){
            return false;
        }else{
            return true;
        }

    }
    public Boolean insertusercard(String telno,String KART,String skt,String cvv,String ip){
        SQLiteDatabase DB=this.getWritableDatabase();
        ContentValues contentValues= new ContentValues();
        contentValues.put("telno",telno);
        contentValues.put("KART",KART);
        contentValues.put("skt",skt);
        contentValues.put("cvv",cvv);
        contentValues.put("ip",ip);



        long result=DB.insert("KullaniciKart",null,contentValues);
        if (result==-1){
            return false;
        }else{
            return true;
        }

    }
    public Cursor getData(){
        SQLiteDatabase DB=this.getWritableDatabase();
        Cursor cursor=DB.rawQuery("Select * from KullaniciDetay ",null);
        return cursor;
    }
    public Cursor getData2(){
        SQLiteDatabase DB=this.getWritableDatabase();
        Cursor cursor=DB.rawQuery("Select * from KullaniciKart ",null);
        return cursor;
    }


}
