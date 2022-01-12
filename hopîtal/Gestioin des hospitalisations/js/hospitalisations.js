function cite(){
    var btn = document.createElement("button");
    btn.innerHTML = "Status";
    btn.setAttribute ("id", "but1");
	btn.setAttribute ("onclick", "status()");
    document.getElementById("status").appendChild(btn);
    var cite="<cite>Je passerai ma vie et j'exercerai mon art dans l'innocence et la pureté.</cite> Serment d'Hippocrate";   
    document.getElementById("cite").innerHTML = cite;     
}

var xmlPat=null;
var xmlEtab=null;
var xmlHosp=null;

function afficher123 (){
	document.getElementById('sel').style.display = "none";
    document.getElementById('sel1').style.display = "none";
	document.getElementById('sel2').style.display = "none"; 
    document.getElementById("test").style.display = "none";	
    document.getElementById('myTable1').style.display = "none";	
	document.getElementById('myTable').style.display = "block";	
	document.getElementById("message").style.display = "none";
    document.getElementById("message1").style.display = "none";
	document.getElementById("modal").style.display = "block"; 
	document.getElementsByClassName("close")[0].style.display = "block";
	document.getElementById("cite").style.display = "block";
}

// fonctionnement de bouton "Liste des patients"//
function listePatients(){
	$.ajax({		
		type:"GET",
		url:"xml/tabPatients.xml",
		dataType: "xml",
		success:function(reponse){			
			xmlPat=reponse;
			afficherPatients();						
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

function afficherPatients(){	
    afficher123();	
    var tabPat=xmlPat.getElementsByTagName('patient');
    var taille = tabPat.length;
    var rep="<table>";
    rep+="<thead><tr><th>dossier</th><th>nom</th><th>prénom</th><th>naissance</th><th>sexe</th></tr></thead>";
    for(var i=0;i<taille;i++){
	    var unPat=tabPat[i];
	    var dossier=unPat.getElementsByTagName('dossier')[0].firstChild.nodeValue;
	    var nom=unPat.getElementsByTagName('nom')[0].firstChild.nodeValue;
	    var prenom=unPat.getElementsByTagName('prénom')[0].firstChild.nodeValue;
	    var naissance=unPat.getElementsByTagName('naissance')[0].firstChild.nodeValue;
	    var sexe=unPat.getElementsByTagName('sexe')[0].firstChild.nodeValue;
	    rep+="<tr><td>"+dossier+"</td><td>"+nom+"</td><td>"+prenom+"</td><td>"+naissance+"</td><td>"+sexe+"</td></tr>";			
    }
    rep+="</table>";
    document.getElementById("myTable").innerHTML=rep;	
    document.getElementById("cite").innerHTML = "Il y a " + taille + " patients."; 
}

// fonctionnement de bouton "Liste des établissements"//
function listeEtablissements(){
	$.ajax({		
		type:"GET",
		url:"xml/tabEtablissements.xml",
		dataType: "xml",
		success:function(reponse){
			xmlEtab=reponse;
			afficherEtablissements();						
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

function afficherEtablissements(){	
    afficher123();
    var tabEtab=xmlEtab.getElementsByTagName('edifice');
    var taille = tabEtab.length;
    var rep="<table>";
    rep+="<thead><tr><th>etablissement</th><th>nom</th><th>adresse</th><th>codePostale</th><th>telephone</th></tr></thead>";
    for(var i=0;i<taille;i++){
	    var unEtab=tabEtab[i];
	    var etablissement=unEtab.getElementsByTagName('etablissement')[0].firstChild.nodeValue;
	    var nom=unEtab.getElementsByTagName('nom')[0].firstChild.nodeValue;
	    var adresse=unEtab.getElementsByTagName('adresse')[0].firstChild.nodeValue;
	    var codePostale=unEtab.getElementsByTagName('codePostale')[0].firstChild.nodeValue;
	    var telephone=unEtab.getElementsByTagName('telephone')[0].firstChild.nodeValue;
	    rep+="<tr><td>"+etablissement+"</td><td>"+nom+"</td><td>"+adresse+"</td><td>"+codePostale+"</td><td>"+telephone+"</td></tr>";			
    }
    rep+="</table>";
    document.getElementById("myTable").innerHTML=rep;
    document.getElementById("cite").innerHTML = "Il y a " + taille + " etablissements."; 
}    

// fonctionnement de bouton "Liste des hospitalisations"//
function listeHospitalisations(){
	$.ajax({		
		type:"GET",
		url:"xml/tabHospitalisations.xml",
		dataType: "xml",
		success:function(reponse){
			xmlHosp=reponse;
			afficherHospitalisations();						
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

function afficherHospitalisations(){
    afficher123();	
    var tabHosp=xmlHosp.getElementsByTagName('hospitalisation');
    var taille = tabHosp.length;
    var rep="<table>";
    rep+="<thead><tr><th>codeEtablissement</th><th>noDossierPatient</th><th>dateAdmission</th><th>dateSortie</th><th>specialite</th></tr></thead>";
    for(var i=0;i<taille;i++){
	    var unHosp=tabHosp[i];
	    var codeEtablissement=unHosp.getElementsByTagName('codeEtablissement')[0].firstChild.nodeValue;
	    var noDossierPatient=unHosp.getElementsByTagName('noDossierPatient')[0].firstChild.nodeValue;
	    var dateAdmission=unHosp.getElementsByTagName('dateAdmission')[0].firstChild.nodeValue;
	    var dateSortie=unHosp.getElementsByTagName('dateSortie')[0].firstChild.nodeValue;
	    var specialite=unHosp.getElementsByTagName('specialite')[0].firstChild.nodeValue;
	    rep+="<tr><td>"+codeEtablissement+"</td><td>"+noDossierPatient+"</td><td>"+dateAdmission+"</td><td>"+dateSortie+"</td><td>"+specialite+"</td></tr>";			
    }
    rep+="</table>";
    document.getElementById("myTable").innerHTML=rep;
    document.getElementById("cite").innerHTML = "Il y a " + taille + " hospitalisations."; 
}

// fonctionnement de bouton "Hospitalisation par patient", création d'une liste déroulante des noms des patients//
function SelectPatient(){
	$.ajax({		
		type:"GET",
		url:"xml/tabPatients.xml",
		dataType: "xml",
		success:function(reponse){
			xmlPat=reponse;
			dropDownPat();				
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

function dropDownPat(){
    document.getElementById('sel').style.display = "block";    
    document.getElementById('myTable').style.display = "none"; 
    document.getElementById('myTable1').style.display = "none"; 	
    document.getElementById('message').style.display = "block";	
	document.getElementById("message1").style.display = "none";
    document.getElementById('message').innerHTML = "Choisir le code de patient";
    document.getElementById('sel1').style.display = "none"; 
    document.getElementById('test').style.display = "none"; 
	document.getElementById("modal").style.display = "block"; 
	document.getElementById('sel').length=0;
	document.getElementById("cite").style.display = "block";
	document.getElementsByClassName("close")[0].style.display = "block";
    var tabPat=xmlPat.getElementsByTagName('patient');	
    var taille = tabPat.length;
	var opt=null;       
    opt+="<option>Choisir</option>"
    for(var i=0;i<taille;i++){
       opt+="<option>"
	   var unPat=tabPat[i];
	   var dossier=unPat.getElementsByTagName('dossier')[0].firstChild.nodeValue;
	   var nom=unPat.getElementsByTagName('nom')[0].firstChild.nodeValue;
	   var prenom=unPat.getElementsByTagName('prénom')[0].firstChild.nodeValue;
	   opt+=dossier+" ( "+prenom+" "+nom+")";
       opt+="</option>";
    }
    document.getElementById("sel").innerHTML=opt;
    document.getElementById("cite").innerHTML = "Choisir le code de patient pour afficher tous ses hospitalisations.";  
 }   

//permet d'afficher les hospitalisations du patient choisi de la liste déroulante//	
function afficherChoix(){
	$.ajax({		
		type:"GET",
		url:"xml/tabHospitalisations.xml",
		dataType: "xml",
		success:function(reponse){
			xmlHosp=reponse;
			afficherHospPat();						
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

function afficherHospPat(){
    var x=0;
	var y = document.getElementById("sel").value;
    var res = y.substring(0, 2);
    var dossier=res.trim();
    var tabHosp=xmlHosp.getElementsByTagName('hospitalisation');
    var taille = tabHosp.length;
    var rep="<table>";
    rep+="<thead><tr><th>codeEtablissement</th><th>noDossierPatient</th><th>dateAdmission</th><th>dateSortie</th><th>specialite</th></tr></thead>";	
    for (var i = 0; i < taille; i++) {       
       var unHosp=tabHosp[i];
       var codeEtablissement=unHosp.getElementsByTagName('codeEtablissement')[0].firstChild.nodeValue;
	   var noDossierPatient=unHosp.getElementsByTagName('noDossierPatient')[0].firstChild.nodeValue;
	   var dateAdmission=unHosp.getElementsByTagName('dateAdmission')[0].firstChild.nodeValue;
	   var dateSortie=unHosp.getElementsByTagName('dateSortie')[0].firstChild.nodeValue;
	   var specialite=unHosp.getElementsByTagName('specialite')[0].firstChild.nodeValue;
            if(dossier==noDossierPatient){
       		    x=x+1;					               		
	            rep+="<tr><td>"+codeEtablissement+"</td><td>"+noDossierPatient+"</td><td>"+dateAdmission+"</td><td>"+dateSortie+"</td><td>"+specialite+"</td></tr>";
                document.getElementById("message").style.display = "none";
			    document.getElementById("sel").style.display = "none";
		        document.getElementById("myTable").style.display = "block";		
            }
    }
    rep+="</table>";
    document.getElementById("myTable").innerHTML=rep;
    document.getElementsByClassName("close")[0].style.display = "block";
    var choix = document.getElementById("sel").value;
    var nom=choix.substring(4, choix.length-1);		
	if(x>0){
		document.getElementById("cite").innerHTML = nom +" a été hospitalisé "+ x + " fois";    
           }else{document.getElementById("cite").innerHTML = nom+ " n'a pas été hospitalisé "; 
           }                 
}

// fonctionnement de bouton "Hospitalisations pour un établissement donné ou pour une spécialité donnée", création de deux listes déroulantes, créations de deux tableaux//
function SelectEtablissement(){
	$.ajax({		
		type:"GET",
		url:"xml/tabEtablissements.xml",
		dataType: "xml",
		success:function(reponse){
			xmlEtab=reponse;
			dropDownEtab();				
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	

//liste déroulante pour les établissements//
function dropDownEtab() {
	document.getElementById('sel').style.display = "none";
    document.getElementById('sel1').style.display = "none";
	document.getElementById("test").style.display = "block";
    document.getElementById('sel2').style.display = "inline"; 		   
    document.getElementById('myTable1').style.display = "none";	
	document.getElementsByClassName("close")[0].style.display = "none";
	document.getElementById("message").style.display = "block";
    document.getElementById("message1").style.display = "none";
	document.getElementById("cite").style.display = "block"; 	
    document.getElementById('myTable').style.display = "none";
    document.getElementById("modal").style.display = "block"; 	
    document.getElementById("message").innerHTML = "Choisir l'établissement"; 
    document.getElementById('sel2').length=0;
    if(document.getElementById('test').lastChild) { 
        document.getElementById('test').removeChild(document.getElementById('test').lastChild); 
    }	
	
	var tabEtab=xmlEtab.getElementsByTagName('edifice');
    var taille = tabEtab.length;   
    var opt=null;
    opt+="<option>Choisir...</option>"
    for(var i=0;i<taille;i++){
        opt+="<option>"
	    var unEtab=tabEtab[i];
	    var etablissement=unEtab.getElementsByTagName('etablissement')[0].firstChild.nodeValue;
	    var nom=unEtab.getElementsByTagName('nom')[0].firstChild.nodeValue;
	    opt+=etablissement+" ("+nom+")";
        opt+="</option>";
    }
    document.getElementById("sel2").innerHTML=opt;
	var btn = document.createElement("button");
    btn.innerHTML = "Fermer";
    btn.setAttribute ("id", "btnF");
	btn.setAttribute ("onclick", "fermer()");
    document.getElementById("test").appendChild(btn);
    document.getElementById("cite").innerHTML = "Choisir l'établissement pour afficher les spécialiés";   
}

//permet de créer une 2e liste déroulante des spécialités correpondantes à l'établissement choisi dans la 1e liste//   
 function selectSpec(){
	$.ajax({		
		type:"GET",
		url:"xml/tabHospitalisations.xml",
		dataType: "xml",
		success:function(reponse){
			xmlHosp=reponse;
			dropDownSpec();				
		},
		fail: function(){
			alert("probleme");			
		}
	});
}
	  
//listé déroulante pour les spécialités, création d'un tableau qui contient l'information de l'établissement choisi//
function dropDownSpec(){ 
    document.getElementById('sel').style.display = "none";
    document.getElementById('sel1').style.display = "block";
	document.getElementById('sel2').style.display = "inline"; 
    document.getElementById('btnF').style.display = "inline"; 	
    document.getElementById('myTable1').style.display = "none";	
	document.getElementsByClassName("close")[0].style.display = "none";
	document.getElementById("message").style.display = "block";
    document.getElementById("message1").style.display = "block";
	document.getElementById("cite").style.display = "block"; 	
    document.getElementById('myTable').style.display = "none"; 
    document.getElementById("modal").style.display = "block"; 	
    document.getElementById("message").innerHTML = "Choisir l'établissement"; 
    document.getElementById('sel1').length=0;	
	var p="<p>Choisir la spécialité</p>";
	var p1="<p>( Seules les spécialités présentes dans nos dossiers pour cet établissement apparaissent dans la lsite déroulante)</p>";
	document.getElementById("message1").innerHTML = p+p1;
	var tabHosp=xmlHosp.getElementsByTagName('hospitalisation');
    var taille = tabHosp.length;  
    var test=[];
    var y = document.getElementById("sel2").value;
    var res = y.substr(0, 4);	
    var opt=null;
    opt+="<option>Choisir la spécialité</option>"	
       for(var i=0;i<taille;i++){
           var unHosp=tabHosp[i];
	       var codeEtablissement=unHosp.getElementsByTagName('codeEtablissement')[0].firstChild.nodeValue;
	       var specialite=unHosp.getElementsByTagName('specialite')[0].firstChild.nodeValue;
	            if(res==codeEtablissement){
                    if(!test.includes( specialite, 0 )){
					    opt+="<option>"	
                        test.push(specialite);
                        opt+=specialite;
                        opt+="</option>";
                    }
                }		
        }
        document.getElementById("sel1").innerHTML=opt;
        document.getElementById("cite").innerHTML = "Choisir la spécialité pour afficher tous les hospitalisationis";  	
	$.ajax({		
		type:"GET",
		url:"xml/tabEtablissements.xml",
		dataType: "xml",
		success:function(reponse){
			xmlEtab=reponse;
							
		},
		fail: function(){
			alert("probleme");			
		}
	});
	var tabEtab=xmlEtab.getElementsByTagName('edifice');
	var p=tabEtab.length;
	var x = document.getElementById("sel2").value;
    var res = x.substr(0, 4);
    var z = document.getElementById("sel1").options.length;			
	if(z>1){
        for (var i = 0; i < p; i++) {			    
			var unEtab=tabEtab[i];
			var etablissement=unEtab.getElementsByTagName('etablissement')[0].firstChild.nodeValue;
	        if(res==etablissement){		    
			   var rep="<table>";                		
			   var nom=unEtab.getElementsByTagName('nom')[0].firstChild.nodeValue;
	           var adresse=unEtab.getElementsByTagName('adresse')[0].firstChild.nodeValue;
	           var codePostale=unEtab.getElementsByTagName('codePostale')[0].firstChild.nodeValue;
	           var telephone=unEtab.getElementsByTagName('telephone')[0].firstChild.nodeValue;
	           rep+="<tr><td>"+"Code de l'établissement: "+etablissement+"</td><td>"+"Nom: "+nom+"</td><td>"+"Adresse: "+adresse+"</td><td>"+"CodePostale: "+codePostale+"</td><td>"+"Téléphone: "+telephone+"</td></tr>";				            
            }
        }
        rep+="</table>";		
        document.getElementById("myTable").innerHTML = "";
        document.getElementById("myTable").innerHTML = rep;
		document.getElementById("cite").innerHTML = "Choisir la spécialité pour afficher tous les hospitalisationis";        
	}else{
	    var p3="<p>Il n'y a pas de spécialités présentes dans nos dossiers pour cet établissement</p>";	
	    document.getElementById("message1").innerHTML = p3;
        document.getElementById("cite").innerHTML = "Il n'y a pas de spécialités pour cet établissement ";
        document.getElementById("sel1").style.display = "none";
         }
}



//les deux focntions suivantes permettent d'aficher les hospitalisations correpondantes à la spécialié et à l'établissement choisi//
function choixSpec(){
$.ajax({		
		type:"GET",
		url:"xml/tabHospitalisations.xml",
		dataType: "xml",
		success:function(reponse){
			xmlHosp=reponse;
			tableauSpecialite();				
		},
		fail: function(){
			alert("probleme");			
		}
	});
}	
	
function tableauSpecialite(){ 
    document.getElementById('sel').style.display = "none";
    document.getElementById('sel1').style.display = "none";	
    document.getElementById('sel2').style.display = "none"; 	
	document.getElementById('btnF').style.display = "none";    
    document.getElementById('myTable1').style.display = "block";	
	document.getElementsByClassName("close")[0].style.display = "block";
	document.getElementById("message").style.display = "none";
    document.getElementById("message1").style.display = "none";
	document.getElementById("cite").style.display = "block"; 	
    document.getElementById('myTable').style.display = "block";                                        
    document.getElementById("modal").style.display = "block";                     	
    var x=0;
    var y = document.getElementById("sel1").value;
    var z = document.getElementById("sel2").value;
	var res = z.substr(0, 4);
    var tabHosp=xmlHosp.getElementsByTagName('hospitalisation');
	var taille=tabHosp.length;	   
    var rep="<table>";
    rep+="<thead><tr><th>codeEtablissement</th><th>noDossierPatient</th><th>dateAdmission</th><th>dateSortie</th><th>specialite</th></tr></thead>";	
    for (var i = 0; i < taille; i++) {	
	   var unHosp = tabHosp[i];
       var codeEtablissement=unHosp.getElementsByTagName('codeEtablissement')[0].firstChild.nodeValue;
	   var noDossierPatient=unHosp.getElementsByTagName('noDossierPatient')[0].firstChild.nodeValue;
	   var dateAdmission=unHosp.getElementsByTagName('dateAdmission')[0].firstChild.nodeValue;
	   var dateSortie=unHosp.getElementsByTagName('dateSortie')[0].firstChild.nodeValue;
	   var specialite=unHosp.getElementsByTagName('specialite')[0].firstChild.nodeValue;							
            if(y==specialite&& res==codeEtablissement){	
		    x=x+1;
            rep+="<tr><td>"+codeEtablissement+"</td><td>"+noDossierPatient+"</td><td>"+dateAdmission+"</td><td>"+dateSortie+"</td><td>"+specialite+"</td></tr>";   	
		    }
    }
    rep+="</table>";
    document.getElementById("myTable1").innerHTML = "";
    document.getElementById("myTable1").innerHTML=rep;
    document.getElementById("cite").innerHTML = "Il y a "+x+" hospitalisations pour l'établissement: "+z.toString()+" avec la spécialité "+y.toString();
    	                            				
}

//comportement en cliquant sur le bouton "Fermer"//
function fermer() {
    document.getElementById("modal").style.display = "none";
	var mess="Cliquez sur un bouton afin d'afficher l'information";
	document.getElementById("cite").innerHTML = mess;
}

//comportement en cliquant sur le "x"//
function x() {
    document.getElementById("modal").style.display = "none";
	var mess="Cliquez sur un bouton afin d'afficher l'information";
	document.getElementById("cite").innerHTML = mess;  
}

//comportement en cliquant sur le bouton "Status"//
function status() {
    document.getElementById("modal").style.display = "none";
	var mess="Cliquez sur un autre bouton afin d'afficher l'information";
	document.getElementById("cite").innerHTML = mess;
}
