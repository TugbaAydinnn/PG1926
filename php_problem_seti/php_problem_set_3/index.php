<html>
  <head>
  <title>FORMLAR</title>
  <link rel="stylesheet" href="sayfa.css">
  </head>
  <body>
  <h1>ASAL SAYI BULMA</h1>
  <form action="index.php" method="post">
  <input type="text"name="sayi" placeholder="Bir sayi giriniz..."><br><br>
  <input type="submit" value="Gönder">
    </form>
<br><br>
<?php
 $kontrol=0;
 $sayi= $_POST['sayi'];
 for ($bolenSayi=2; $bolenSayi<=($sayi/2) ; $bolenSayi++){
   if($sayi % $bolenSayi==0){
     $kontrol=1;
     echo "Girilen asal sayı değildir." ;
      
     break;
   }
   }
    
    if($kontrol==0 and $sayi==1){
        echo " Girilen sayi asal sayı degildir.";
        }
    else if($kontrol==0){
         echo " Girilen sayi asal sayıdır.";
        }
?>