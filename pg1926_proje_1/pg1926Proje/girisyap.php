<?php

$aktif = 5;
require_once "_ayarlar.php";
require_once '_ust_kisim.php';
require_once "_menu.php";
?>
<html>
<head>
    <title>Giriş Sayfası</title>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
</head>
<body>
 <form action="?" method="post" enctype="application/
 x-www-form-urlencoded">
     <label for="kullanici_adi">Kullanıcı Adı</label>
     <input type="text" name="kullanici_adi"  id="kullanici_adi" 
     autocomplete="off" placeholder="Kullanıcı Adınızı Yazınız" />

     <label for="parola">Parola</label>
     <input type="password" name="sifre"  id="sifre" autocomplete="off"
     placeholder="Parolanızı Yazınız" />

     <button type="button" name="gonder" id="gonder">Oturum Aç</button>
 </form>
 <script type="text/javascript">
 $("#gonder").click(function(){
     var kullanici=$("#kullanici_adi");
     var sifre =$("#sifre");
     if(kullanici.val()===""){
         alert("Lütfen kullanıcı adınızı yazınız.");
     }
     else if(sifre.val()==""){
        alert("Lütfen şifrenizi yazınız.");
     }
     else{
         var veriler="kullanici=" +kullanici.val() + "&parola="+sifre.val();
        $.ajax({
            type: "POST",
            url:"hosgeldiniz.php",
            data: veriler,
            cache: false,
            success:function(karsiSayfadninakiDegerleri){
                alert(karsiSayfadninakiDegerleri);
                    if(karsiSayfadninakiDegerleri == "hata"){
                       
                        alert("Kullanıcı adı veya  parolanız hatalıdır.");
                    }
                    else{
                        window.location.href = 'deneme.php';
                    }
            }

        });

     }
 });
 </script>
 </body>
 </html>
<?php
require_once "_alt_kisim.php";
?>