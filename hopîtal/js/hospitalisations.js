

var tabPatients=[
  { "dossier": 1, "nom": "Léger","prénom": "Émile ", "naissance": "26 mars 1917", "sexe": "M"},
  { "dossier": 2, "nom": "Bernard","prénom": "Marie ", "naissance": "3 février 1946", "sexe": "F"},
  { "dossier": 3, "nom": "Chartrand","prénom": "Guy ", "naissance": "5 avril 1959", "sexe": "M"},
  { "dossier": 4, "nom": "Côté","prénom": "André ", "naissance": "2 septembre 1978", "sexe": "M"},
  { "dossier": 5, "nom": "Lavoie","prénom": "Carole ", "naissance": "4 novembre 1973", "sexe": "F"},
  { "dossier": 6, "nom": "Martin","prénom": "Diane ", "naissance": "2 décembre 1965", "sexe": "F"},
  { "dossier": 7, "nom": "Lacroix","prénom": "Pauline ", "naissance": "25 janvier 1956", "sexe": "F"},
  { "dossier": 8, "nom": "St-Jean","prénom": "Arthur ", "naissance": "7 octobre 1912", "sexe": "M"},
  { "dossier": 9, "nom": "Béchard","prénom": "Marc ", "naissance": "8 août 1980", "sexe": "M"},
  { "dossier": 10, "nom": "Chartrand","prénom": "Mario ", "naissance": "23 juillet 1947", "sexe": "M"}
];

var tabEtablissements = [
  { "établissement": 1234, "nom": "Centre hospitalier Sud","adresse": "1234 boul.Sud, Montréal,Qc ", "code postal": "H2M 3Y5", "téléphone": "(514)-323-1234"},
  { "établissement": 2346, "nom": "Hôpital Nord","adresse": "7562 rue du Souvenir, Nordville, Qc ", "code postal": "J4R 2Z5", "téléphone": "(450)-222-3333"},
  { "établissement": 3980, "nom": "Hôpital Centre","adresse": "4637 boul.de l'Église, Montréal, Qc", "code postal": "H3J 4K8", "téléphone": "(514)-123-5678"},
  { "établissement": 4177, "nom": "Centre hospitalier Est","adresse": "12 rue Bérnard, Repentigny, Qc", "code postal": "J8R 3K5", "téléphone": "(450)-589-2345"},
  { "établissement": 7306, "nom": "Hôpital du salut","adresse": "11 rue de la Rédemption, St-Basile, Qc", "code postal": "J8H 2D4", "téléphone": "(450)-345-6789"},
  { "établissement": 5895, "nom": "Dernier recours","adresse": "999 rue St-Pierre, longueuil, Qc", "code postal": "J7B 3J6", "téléphone": "(450)-555-6741"}
  ];
  
var tabHospitalisations =[
  { "code établissement": 1234, "no dossier patient": 5,"date admission": "14-août-01", "date sortie": "14-août-01", "spécialité": "médecine"  },
  { "code établissement": 1234, "no dossier patient": 10,"date admission": "12-déc.-92", "date sortie": "12-déc.-92", "spécialité": "chirurgie"  },
  { "code établissement": 2346, "no dossier patient": 8,"date admission": "03-mars-03", "date sortie": "05-mars-03", "spécialité": "médecine"  },
  { "code établissement": 2346, "no dossier patient": 1,"date admission": "11-nov.-97", "date sortie": "12-nov.-97", "spécialité": "orthopédie"  },
  { "code établissement": 2346, "no dossier patient": 3,"date admission": "12-avr.-95", "date sortie": "30-avr.-95", "spécialité": "médecine"  },
  { "code établissement": 3980, "no dossier patient": 5,"date admission": "14-févr.-00", "date sortie": "14-mars-00", "spécialité": "médecine"  },
  { "code établissement": 3980, "no dossier patient": 5,"date admission": "01-janv.-01", "date sortie": "01-févr.-01", "spécialité": "médecine"  },
  { "code établissement": 3980, "no dossier patient": 9,"date admission": "03-avr.-95", "date sortie": "08-avr.-95", "spécialité": "orthopédie" },
  { "code établissement": 3980, "no dossier patient": 7,"date admission": "27-nov.-99", "date sortie": "04-déc.-99", "spécialité": "chirurgie"  },
  { "code établissement": 3980, "no dossier patient": 10,"date admission": "28-avr.-97", "date sortie": "05-mai-97", "spécialité": "chirurgie"  },
  { "code établissement": 4177, "no dossier patient": 3,"date admission": "03-août-01", "date sortie": "05-déc.-01", "spécialité": "médecine"  },
  { "code établissement": 4177, "no dossier patient": 3,"date admission": "02-févr.-02", "date sortie": "23-févr.-02", "spécialité": "orthopédie"  },
  { "code établissement": 7306, "no dossier patient": 2,"date admission": "23-mai-98", "date sortie": "27-mai-98", "spécialité": "orthopédie"  }
];

var modal = document.getElementById('modal');
var btn1 = document.getElementById("btn1");
var btn2 = document.getElementById("btn2");
var btn3 = document.getElementById("btn3");
var btn4 = document.getElementById("btn4");
var btn5 = document.getElementById("btn5");
var span = document.getElementsByClassName("close")[0];
var message = document.getElementById("message");
var message1 = document.getElementById("message1"); 
var sel = document.getElementById('sel');
var sel1 = document.getElementById('sel1');
var sel2 = document.getElementById('sel2');
var myTable = document.getElementById("myTable");
var myTable1 = document.getElementById("myTable1");
var btnF = document.getElementById("btnF");
var cite = document.getElementById("cite");
var col = [];


//création des colonnes d'un tableau// 
function createCol(obj){
	 for (var i = 0; i < obj.length; i++) {
        for (var key in obj[i]) {
            if (col.indexOf(key) === -1) {
                    col.push(key);
            }
        }
    }
}

//création d'un tableau//
function createTable(obj) { 

    sel.style.display = "none";
    sel1.style.display = "none";
	sel2.style.display = "none";    
	btnF.style.display = "none";
    myTable.style.display = "block";
    myTable1.style.display = "none";	
	span.style.display = "block";
	message.style.display = "none";
    message1.style.display = "none";
	cite.style.display = "block"; 
	col.length=0;
    var table = document.createElement("table");	
	createCol(obj);
	//création des en-têtes des colonnes//	                           
    var tr = table.insertRow(-1);                   
        for (var i = 0; i < col.length; i++) {
            var th = document.createElement("th");      
            th.innerHTML = col[i];
            tr.appendChild(th);
        } 
    //création des lignes du tableau//		
    for (var i = 0; i < obj.length; i++) {
        tr = table.insertRow(-1);
        for (var j = 0; j < col.length; j++) {
            var tabCell = tr.insertCell(-1);
            tabCell.innerHTML = obj[i][col[j]];
        }
    }
	//ajout du tableau dans la division prévue à cet effet//
    myTable.innerHTML = "";
    myTable.appendChild(table);
    modal.style.display = "block";	 		
    }
	
//fonction pour le bouton "Liste des patients"//	
btn1.onclick=function(){ 
    createTable(tabPatients);
    cite.innerHTML = "Il y a " + tabPatients.length + " patients.";
}

//fonction pour le bouton "Liste des éttablissements"//
btn2.onclick=function(){ 
    createTable(tabEtablissements);
    cite.innerHTML = "Il y a " + tabEtablissements.length + " établissements.";
}

//fonction pour le bouton "Liste des hospitalisations"//
btn3.onclick=function(){ 
createTable(tabHospitalisations);
cite.innerHTML = "Il y a " + tabHospitalisations.length + " hospitalisations.";
}

//fonction pour le bouton "Hospitalisations par patient"//
btn4.onclick = function() {
	
    sel.style.display = "block";
    sel1.style.display = "none";
    sel2.style.display = "none";
    myTable.style.display = "none";
    myTable1.style.display = "none";
    btnF.style.display = "none";
    span.style.display = "block";
    message.style.display = "block";
    message1.style.display = "none";
    cite.style.display = "block";
	
    message.innerHTML = "Choisir le code de patient";
	col.length=0;
    sel.length=0;
    sel.options[sel.options.length] = new Option("Choisir");
    for(var i=0;i<tabPatients.length;i++){
        var dossier = tabPatients[i];
        sel.options[sel.options.length] = new Option(dossier["dossier"]+" ("+dossier["prénom"]+dossier["nom"]+")");
        modal.style.display = "block";		
        cite.innerHTML = "Choisir le code de patient pour afficher tous ses hospitalisations."; 
    }
}	
//comportement selon la option choisie de la liste déroulante créee en cliquant sur btn4//
sel.onchange = function(){ 

    sel1.style.display = "none";
    sel2.style.display = "none";
    myTable.style.display = "none";
    btnF.style.display = "none";
    span.style.display = "block";
    message.style.display = "none";	
    message1.style.display = "none";
    cite.style.display = "block";
	
    var x=0;     
    col.length=0;
    var table = document.createElement("table");        		
    createCol(tabHospitalisations);                   
    var tr = table.insertRow(-1);                   
        for (var i = 0; i < col.length; i++) {
            var th = document.createElement("th");      
            th.innerHTML = col[i];
            tr.appendChild(th);
        }			               
        for (var i = 0; i < tabHospitalisations.length; i++) {
		    var y = document.getElementById("sel").value;
            var res = y.substr(0, 2);
		    var dossier = tabHospitalisations[i];
            if(res==dossier["no dossier patient"]){
       		    x=x+1;	
			    sel.style.display = "none";
		        myTable.style.display = "block";	
                var tr = table.insertRow(-1); 
                for (var j = 0; j < col.length; j++) {	            			
                    var tabCell = tr.insertCell(-1);
                    tabCell.innerHTML = tabHospitalisations[i][col[j]];
				
				}        
		    }	
        }			                    
    myTable.innerHTML = "";
    myTable.appendChild(table);
    modal.style.display = "block";
    var choix = document.getElementById("sel").value;
    var nom=choix.substring(3, choix.length-1);		
	if(x>0){
		cite.innerHTML = nom +" a été chospitalisé "+ x + " fois";    
           }else{cite.innerHTML = nom+ " n'a pas été hospitalisé "; 
           }
}

//fonction pour le bouton "Hospitalisations par un établissement donné ou par une spécialité donnée", création d'une liste déroulante//
btn5.onclick = function() {
	
    myTable.style.display = "none";
    myTable1.style.display = "none";
    sel2.style.display = "block";
    sel1.style.display = "none";
    sel.style.display = "none";
    span.style.display = "none";
    btnF.style.display = "block";
    message.style.display = "block";
    message1.style.display = "none";
    cite.style.display = "block";
         
    message.innerHTML = "Choisir l'établissement"; 
    sel2.length=0;
    sel2.options[sel2.options.length] = new Option("Choisir...");
    for(var i=0;i<tabEtablissements.length;i++){
        var dossier = tabEtablissements[i];
        sel2.options[sel2.options.length] = new Option(dossier["établissement"]+" ("+dossier["nom"]+")");
        modal.style.display = "block";
	    var x = document.getElementById("sel2").options.length;	
        cite.innerHTML = "Choisir l'établissement pour afficher les spécialiés"; 
    }
}	

//comportement selon l'option choisie, création d'une deuxième liste, //
//création du tableau qui affiche les coordonnées de l'établissement choisi//
sel2.onchange = function(){ 
    sel1.style.display = "block";
    span.style.display = "none";
    message1.style.display = "block";
    cite.style.display = "block";
	
	var test=[];
    var y = document.getElementById("sel2").value;
    var res = y.substr(0, 4);
    sel1.length=0;
    col.length=0;
	
	//création du text après la 1ere liste déroulante//
    while (message1.firstChild) {
        message1.removeChild(message1.firstChild);
    }
    var para = document.createElement("p");
    var node = document.createTextNode("Choisir la spécialité");
    para.appendChild(node);
    message1.appendChild(para);
    var newElem = document.createElement("BR");
    message1.insertBefore(newElem, para);
	var para1 = document.createElement("p");
    var node1 = document.createTextNode("( Seules les spécialités présentes dans nos dossiers pour cet établissement apparaissent dans la lsite déroulante)");
    para1.appendChild(node1);
    message1.appendChild(para1);
    sel1.options[sel1.options.length] = new Option("Choisir la spécialité");
    for (var i = 0; i < tabHospitalisations.length; i++) {
        var dossier = tabHospitalisations[i];		
            if(res==dossier["code établissement"]){
                if(!test.includes( dossier["spécialité"], 0 )){
                    test.push(dossier["spécialité"])
                    sel1.options[sel1.options.length] = new Option(dossier["spécialité"]);
                }
            }
    }	
    var y = document.getElementById("sel1").options.length;
    if(y>1){	
        for (var i = 0; i < tabEtablissements.length; i++) {	
		    var y = document.getElementById("sel2").value;
            var res = y.substr(0, 4);
		    var dossier = tabEtablissements[i];
                if(res==dossier["établissement"]){			
			        for (var j = 0; j < tabEtablissements.length; j++) {
                        for (var key in tabEtablissements[j]) {
                            if (col.indexOf(key) === -1) {
                                col.push(key);
                            }
                        }
                    } 
		            var table = document.createElement("table");
                    var tr = table.deleteRow(-1); 							
                    var tr = table.insertRow(-1); 
                    for (var j = 0; j < col.length; j++) {	            			
                        var tabCell = tr.insertCell(-1);				
                        tabCell.innerHTML = col[j]+": "+tabEtablissements[i][col[j]];								
				    }
                }
        }			               
        myTable.innerHTML = "";
        myTable.appendChild(table);
		modal.style.display = "block";	
		cite.innerHTML = "Choisir la spécialité pour afficher tous les hospitalisationis";
    } else{
          cite.innerHTML = "Il n'y a pas de spécialités pour cet établissement ";
          var textnode = document.createTextNode("Il n'y a pas de spécialités présentes dans nos dossiers pour cet établissement");
          var textnode1 = document.createTextNode("");  
          para.replaceChild(textnode, para.childNodes[0]);
          para1.replaceChild(textnode1, para1.childNodes[0]);
          sel1.style.display = "none";
    }
}

//comportement correspondant à l'option choisie de la 2eme liste déroulante,//
// création d'un tableau// 
sel1.onchange = function(){ 
    
    sel.style.display = "none";
    sel1.style.display = "none";
    sel2.style.display = "none";
    btnF.style.display = "none";
    myTable.style.display = "block";
    myTable1.style.display = "block";
    span.style.display = "block";
    message.style.display = "none";
    message1.style.display = "none";
    cite.style.display = "block";
	
    var x=0;
    var y = document.getElementById("sel1").value;
    var z = document.getElementById("sel2").value;
    var col1 = [];
		for (var j = 0; j < tabHospitalisations.length; j++) {
            for (var key in tabHospitalisations[j]) {
                if (col1.indexOf(key) === -1) {
                    col1.push(key);
                }
            }
        } 
	//création du tableau affichant les hospitalisations correspondates//
	//à l'établissement et à la spécialité choisis//
    var table = document.createElement("table");        
    var tr = table.insertRow(-1);                   
    for (var i = 0; i < col1.length; i++) {
        var th = document.createElement("th");     
        th.innerHTML = col1[i];
        tr.appendChild(th);
    }			            	
    for (var i = 0; i < tabHospitalisations.length; i++) {						
		var res = z.substr(0, 4);
		var dossier = tabHospitalisations[i];
        if(y==dossier["spécialité"]&& res==dossier["code établissement"]){	
			x=x+1;
            var tr = table.insertRow(-1); 
            for (var j = 0; j < col.length; j++) {	            			
                var tabCell = tr.insertCell(-1);
                tabCell.innerHTML = tabHospitalisations[i][col1[j]];				
			}
        }
    }			                    
    myTable1.innerHTML = "";
    myTable1.appendChild(table);
	modal.style.display = "block";			
	cite.innerHTML = "Il y a "+x+" hospitalisations pour l'établissement: "+z.toString()+" avec la spécialité "+y.toString();
}

//comportement en cliquant sur le bouton "Fermer"//
btnF.onclick=function () {
    modal.style.display = "none";
	cite.style.display = "none"; 
}

//comportement en cliquant sur le "x"//
span.onclick=function () {
    modal.style.display = "none";
	cite.style.display = "none";  
}

//permet de fermer la division "modal" en cliquant n'importe où dans son intérieur //
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
		cite.style.display = "none"; 
    }
}

