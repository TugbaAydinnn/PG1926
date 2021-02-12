<?php
$aktif = 4;
require_once "_ayarlar.php";
require_once '_ust_kisim.php';
require_once "_menu.php";
require_once 'veritabani.php';
$baglanti=baglantiolustur();

?>


<html>
    <head>
        <title>Kayıt Ol Formu</title>

    </head>
    <body>
    <?php
    if(isset($_POST["gonder"])){
        
        $kullanici_adi=$_POST["kullanici_adi"];
        $sifre=$_POST["parola"];
        $ad=$_POST["isim"];
        $soyad=$_POST["soyisim"];
        $tarih=date("Y-m-d H:i:s");
        
        $yeniSifre=(base64_encode(md5(md5($sifre))));
        $kayıt_ekle=mysqli_query($baglanti,"INSERT INTO kullanicilar 
        (kullanici_adi,parola,isim,soyisim,olusturulma_tarihi) VALUES
        ('$kullanici_adi','$$yeniSifre','$ad','$soyad','$tarih')");
        if($kayıt_ekle==True){
            echo '<h3 style="color:green;"> Kayıt İşlemi Başarılı</h3>';
        }
        else{
            echo '<h3 style="color:red;"> Kayıt İşlemi Başarısız</h3>';
        }
       

    }
    else{



    ?>
        <form action="?" method="post" enctype="application/x-www-form-urlencoded">
        
            <label for="kullanici_adi">Kullanıcı Adı:</label>
            <input type="text" name="kullanici_adi" placeholder="kullanıcı Adı Giriniz" autocomplete="off">
            <br><br>  
            Şifre: <input type="password" name="parola" placeholder="Parola Giriniz" autocomplete="off">
            <br><br> 
            isim: <input type="text" name="isim" placeholder="İsim Giriniz" autocomplete="off">
            <br><br> 
            Soyisim:<input type="text" name="soyisim" placeholder="Soyisim Giriniz" autocomplete="off">
            <br><br> <br> 
            <button type="submit" name="gonder">GÖNDER</button>
            
        </form>
        <?php } ?>
    
    </body>
</html>