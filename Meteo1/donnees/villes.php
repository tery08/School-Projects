<!--Travail pratique réalisé par Tatyana Sharlandzhieva, matricule 851622 -->

<?php
  include ("entete.php"); //inclure la tête de la page
?>
<hr id="l2">
<div id="contenu">
    <!--construction d'un card pour chaque ville, l'image correspond à la ville choisie,
     source: https://www.w3schools.com/bootstrap4/bootstrap_cards.asp -->
    <div class="container" >
        <div class="card img-fluid" >
            <?php
                $selected = $_GET['ville'];  // recuperation de l'option choisie de tp1.php
                //$picture=lcfirst($selected);
                $pic="../images/".$selected.".jpg";  
                echo "<img class='card-img-top' src='$pic' alt='$pic'>"; //choix d'image (background card)
            ?>
            <div class='card-img-overlay'>
                <?php
                    $info="";
                    $in="&nbsp";
                    $te="&nbsp";
                    $hu="Humidite:";
                    $ve="Vent:";
                    $de="&nbsp";
                    $image;
                    $tab="<table >";
                    $selected = $_GET['ville'];        
                    echo "<h3 class='card-title'>Ville: ".ucfirst( $selected)."</h3>";
                    $lien=lcfirst($selected).".txt";
                    //obtenation du fichier correspondant à la ville choisie
                    $fichier =array_filter(array_map("trim", file("http://www.iro.umontreal.ca/~dift1147/pages/TPS/tp1/".$lien)), "strlen");
                    //vérification s'il a un problème avec le fichier
                    if(!$fichier){
                        echo "ERREUR: problème avec le fichier";
                        exit;    
                    }    
                    $nb = count($fichier);   // Nombre total des lignes dans le fichier
                    
                    //construction du tableau avec les données météo
                    for($i = 0; $i < $nb; $i++) {    //loop les lignes pour détérminer de quelle donnée il s'agit
                    $line=trim($fichier[$i]);                             
		                if(strlen($line)>1 && substr($line, 0, 2)=="in"){  
                            $info=explode(":",$line);               
                            $in=trim($info[1]);                          
                            $image="../images/".$in.".gif";     //nom de fichier "Ensoleille", "Neige", "Nuageux" ou "Pluie"        
                        }   
        
                        if(strlen($line)>1 && substr($line, 0, 2)=="te") { 
                            $te= ucfirst($line);                                                                                                                                              
                        }  
          
                        if (strlen($line)>1 && substr($line, 0, 2)=="hu") {                                
                            $hu= ucfirst($line);                                                                                                                             
                        }  
          
                        if (strlen($line)>1 && substr($line, 0, 2)=="ve") {
                            $ve= ucfirst($line);
                        }                                                                                                                                  
               
                        if (strlen($line)>1 && substr($line, 0, 2)=="de") {
                            $desc=explode(":",$line);                                                
                            $de=$desc[1];                                                                                                                                              
                        }                                              
                    }
    
                    $tab.="<tr><td colspan='3'><img src='$image' id='image'><br>".$in."</td></tr>";
                    $tab.="<tr><td width=33%>".$te."</td><td width=33%>".$hu."</td><td width=33%>".$ve."</td></tr>";
                    $tab.="<tr><td colspan='3'>".$de." </td></tr>";
                    $tab.="</table>"; 
                    echo $tab;  //visualisation du tableau            
                ?> 

                <a id= 'but' href='tp1.php' class='btn btn-primary'>Retour</a>
            </div>
        </div>
    </div>
</div>
<!--inclure le pied de la page -->
<?php       
    include ("pied.php");
?>

