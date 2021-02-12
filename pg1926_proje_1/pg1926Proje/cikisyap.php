<?php
session_start();
session_destroy();
echo "Çıkış işlemi tamamlandı.";
echo'<meta http-equiv="refresh" content="0;URL=girisyap.php">';

/*
if(isset($_SESSION["pg1926"])==False){
  session_destroy();
  unset($_SESSION["Pg1926"]);
  //echo'<meta http-equiv="refresh" content="0;URL=girisyap.php">';
  
}*/

    //header("refresh:0;url:girisyap.php");
   ?>

