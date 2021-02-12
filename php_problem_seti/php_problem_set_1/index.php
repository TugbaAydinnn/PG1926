<?php
$degisken;
date_default_timezone_set('Europe/Istanbul');
$sayi=date(' H:i');
$altLimit=00.00;
$ustLimit=06.59;

function kontrol($altLimit, $ustLimit, $sayi) {
    if($sayi <$ustLimit && $sayi>$altLimit)
     return true;
   
    return false;
   
   }

if(kontrol(00.01,06.01,date('H:i'))){
echo "ESENLİKLER DİLERİM";
}
else if(kontrol(06.00,10.00,date('H:i'))){
    echo "GUNAYDIN";
}
else if(kontrol(10.01,17.00,date('H:i'))){
    echo "IYI GUNLER";
}
else if(kontrol(17.01,20.00,date('H:i'))){
    echo "IYI AKSAMLAR";
}
else{
    echo "IYI GECELER";
}




?>