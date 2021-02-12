<?php
session_start();
if(isset($_SESSION["pg1926"])==FALSE){
    $menuekle=[
        ["link"=>"girisyap.php","butonAdi"=>"Giriş Yap" ]
    ];
}
else{
    $menuekle=[
        ["link"=>"hosgeldiniz.php","butonAdi"=>"Size ÖZel" ],
        ["link"=>"cikisyap.php","butonAdi"=>"Çıkış Yap" ]
    ];

}
$menu=[
    ["link"=>"index.php","butonAdi"=>"Anasayfa" ],
    ["link"=>"hakkimizda.php","butonAdi" =>"Hakkımızda" ],
    ["link"=>"iletisim.php","butonAdi" =>"İletişim"],
    ["link"=>"kayitol.php","butonAdi" =>"Kayıt Ol"],
   
];

$veriler=[
    "menu"=>array_merge($menu,$menuekle),
    "altkisim"=>"Tüm hakları saklıdır.2020-".date("Y")
];
