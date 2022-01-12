<!--Travail pratique réalisé par Tatyana Sharlandzhieva, matricule 851622 -->

<?php
include ("entete.php");
?>

<div id="contenu">
  <!--Carousel background de la page tp1.php,les images se trouevent dans le dossier local,
   la liste déroulante prend l'information de tp1-1.php (source: https://startbootstrap.com/snippets/full-slider/-->
  <header>
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
      <ol class="carousel-indicators">
        <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
        <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
      </ol>
    <div class="carousel-inner" role="listbox">     
      <div class="carousel-item active" style="background-image: url('../images/soleil.jpg')">
        <div class="carousel-caption d-none d-md-block">		
		      <?php
            include ("tp1-1.php");
          ?>
        </div>
      </div>      
      <div class="carousel-item" style="background-image: url('../images/Pluie.jpg')">
        <div class="carousel-caption d-none d-md-block">
		      <?php
            include ("tp1-1.php");
          ?>
        </div>
      </div>     
      <div class="carousel-item" style="background-image: url('../images/neige.jpg')">
        <div class="carousel-caption d-none d-md-block">
		      <?php
            include ("tp1-1.php");
          ?>
        </div>
      </div>
    </div>
    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
    </a>
    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
    </a>  
  </header>
</div>

<?php
	include ("pied.php");
?>

