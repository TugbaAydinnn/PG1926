<?php
session_start();
require_once 'veritabani.php';

function baglantiolustur(){
    $sunucu_adi='localhost';
$kullanici_adi='root';
$parola='';
$veritabani='pg1926veritabani';
$baglanti = mysqli_connect($sunucu_adi,$kullanici_adi,$parola,$veritabani);
if(!$baglanti){
    die("Baglanti Hatası: ".mysqli_connect_error());
}
$baglanti->set_charset("utf8");
return $baglanti;
}

