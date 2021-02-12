<?php
$aktif = 5;
require_once 'veritabani.php';
$baglanti=baglantiolustur();

require_once "_ayarlar.php";
require_once '_ust_kisim.php';
require_once "_menu.php";


if(isset($_SESSION["pg1926"]) == FALSE){
    echo '<meta http-equiv="refresh" content="0;URL=girisyap.php">';
    die();
}

?>

<html>
  <head>
    <title>Moogle</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="./pg1926.css">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>  
    <script src="./movieProvider.js"></script>
  </head>
  <body>
    <div class='header'>
      <p class='title'>
        Moogle
</p>
      <div class='search-area'>
        <input placeholder='Aramak istediğiniz filmi yazınız' id='movieNameInput'/>
      </div>
      <div class='movie-showcase'>
      <img id='moviePoster'/>
      <p id='movieName'>Lütfen bir film aratınız</p>
      <p id='moviePlot'></p>
    </div>
      <p>
         <button id='movieSearchButton' onclick='searchForMovie()'>Ara</button>
      </p>
      

    </div>
    
  </body>
</html>
<?php
require_once "_alt_kisim.php";
?>