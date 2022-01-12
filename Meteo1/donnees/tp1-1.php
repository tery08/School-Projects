<!--Travail pratique réalisé par Tatyana Sharlandzhieva, matricule 851622 -->

<form id="form" action ="villes.php" method="GET" ><label id="choix" for="name"> Choix de la ville: </label>  
    <select id= "ville" name='ville' multiple size="3"> <!--création d'une liste déroulante dynamique-->
	<?php
	$file=fopen("http://www.iro.umontreal.ca/~dift1147/pages/TPS/tp1/villes.txt", "r");
		if(!$file){
			echo "<script>document.getElementById('ville').style.width = '220px';</script>";
			echo "<option value='Fichier introuvable'>Fichier introuvable</option>"; 
	    	exit;    
		}
		
		$ligne=fgets($file);
		while(!feof($file)){
			if(strlen($ligne)>1){	//si la longueur du $ligne >1 on utilise la fonction "explode" pour obtenir la partie avant : et après		
				$piece = explode(":", $ligne);
				$ville = explode(".", $piece[2]); //ici utilise la 2e parie du $ligne et on obtient les deux parties du nom du fichier qui sont séparées par un point
				echo "<option value='$ville[0]'>".ucfirst($ville[0])."</option>"; 	//on utilise la 1e partie qui répresente le nom de la ville
				                                                                   // et on modifie la 1e lettre en majuscule par la fonction ucfirst()		
			}
		$ligne=fgets($file);
		};			   
	fclose($file);
	?>
	</select >
	<div id="but">
	<button type="submit" class="btn btn-primary btn-lg">Afficher la météo</button>
	</div>
</form>