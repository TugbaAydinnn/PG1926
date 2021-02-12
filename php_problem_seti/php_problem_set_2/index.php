<html>
  <head>
  <title>FORMLAR</title>
  <link rel="stylesheet" href="duzen.css">
  </head>
  <body>
  <h1>MUKEMMEL SAYI BULMA</h1>
  <form action="index.php" method="post">
  <input type="text"name="sayi" placeholder="Bir sayi giriniz..."><br><br>
  <input type="submit" value="Gönder">
    </form>
<br><br>
<?php
 $kontrol=0;
 $toplam=0;
 $sayi= $_POST['sayi'];
 for ($bolenSayi=1; $bolenSayi<$sayi; $bolenSayi++){
   if($sayi % $bolenSayi==0){
     $kontrol=1;
     $toplam=$toplam+$bolenSayi;
     echo $toplam."<br>";
     echo $sayi."<br>";
     echo $bolenSayi."<br>";
        if($sayi==$toplam){
            $mesaj = "<script>alert('Mukemmel Sayidir.')</script>";
            echo $mesaj;
            break;
        }
        
    
      
    
   }
 
   }
 if($sayi!=$toplam){
    $mesaj = "<script>alert('Mukemmel Sayi Degildir.')</script>";
    echo $mesaj;
    
 }
    
   if($sayi==1 and $kontrol=1){
    $mesaj = "<script>alert('Mukemmel Sayi Degildir.')</script>";
    echo $mesaj;
    }
?>