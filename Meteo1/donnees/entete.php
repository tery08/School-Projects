<!--Travail pratique réalisé par Tatyana Sharlandzhieva, matricule 851622 -->

<!DOCTYPE html>
<html lang="fr">
    <head>
       <meta charset="utf-8">
        <title>Travail pratique #1</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>  
        <script  language="javascript" src="../js.js"></script>
		<link rel="stylesheet" href="../css/bootstrap-4.5.2-dist/css/bootstrap.min.css"/>
        <link rel="stylesheet" type="text/css" href="../css/styles.css"/>   	
    </head>

    <body>    
        <div id="entete">
            <!--Visualiser date/ heure -->
            <h1>Informations météorologiques</h1>
            <h2>Le
            <?php
                setlocale(LC_TIME, 'fr_CA');
                ini_set('date.timezone', 'Canada/Eastern');
                echo ucfirst(strftime("%A %d %B %Y - %H:%M:%S")) . "\n";
            ?>
            </h2>
        </div >


