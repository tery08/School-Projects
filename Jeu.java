import java.util.*;
import java.util.ArrayList;

public class Jeu implements TicTacToe{
	
	List<Integer> posX=new ArrayList<Integer>(); //contient les positions de X
	List<Integer> posO=new ArrayList<Integer>(); //contient les position de O
	// les trios gagnants
	List<Integer> ligne1= Arrays.asList(0,1,2);
	List<Integer> ligne2= Arrays.asList(3,4,5);
	List<Integer> ligne3= Arrays.asList(6,7,8);
	List<Integer> col1= Arrays.asList(0,3,6);
	List<Integer> col2= Arrays.asList(1,4,7);
	List<Integer> col3= Arrays.asList(2,5,8);
	List<Integer> diag1= Arrays.asList(0,4,8);
	List<Integer> diag2= Arrays.asList(2,4,6);
	List<List> win=new ArrayList<List>(){{ add(ligne1); add(ligne2);add(ligne3);add(col1);add(col2);add(col3);add(diag1);add(diag2);}};
	Set<Integer> set=new HashSet<Integer>();
	Set<Integer> set1=new HashSet<Integer>();
	Set<Integer> set2=new HashSet<Integer>();
	Set<Integer> set3=new HashSet<Integer>();
	Set<Integer> set4=new HashSet<Integer>();
	List<Integer> tab1 = Arrays. asList(0,2,6,8); 
	List<Integer> tab2 = Arrays. asList(1,3,5,7);
	int[] tabG=new int [3];
	int pos;
	
	
	public Jeu() {		}
	 /* pour initialiser un jeu de tic tac toe */
	public void initialise(){
		posX.clear();
		posO.clear();
		set.clear();
		set1.clear();
		set2.clear();
		set3.clear();
		set4.clear();
		}
    	

	
	/* pour recevoir l'index de la cellule choisie par X */
	public void setX( int cellule){	
		posX.add(cellule);	
		
	}	
	
	
	public int getO(){	
			
		unX();	//position du 1er O	(juste un X sur le tableau)							 	
		deuxXsansO(); // position de O quand les deux X sont sur un trio gagnant (deux X un O sur le tableau)			
		deuxXunO(); // les deux X et le O se trouvent sur un trio gagnant (deux X un O sur le tableau)
		intersectionO(); //O se trouve au centre et un des X se trouve sur une colonne , l'autre sur une ligne hor.	(deux X un O sur le tableau)					
		deuxXcentreX();	// un des X se trouve au centre, l'autre à côté, la 3e position est libre (deux X un O sur le tableau)				
		deuxOsansX();  // les deux O se trouvent sur un trio gagnant et la 3e position est libre, O se trouve au centre (troix X deux O sur le tableau)
		deuxX(); // deux X sur un trio, 3e position libre, O se trouve au centre (troix X deux O sur le tableau)
		troisXcentreX();
		troisOquantreX();
		quatreX(); // deux X se trouvent sur un trio gagnant, la 3e position est libre (quantre X trois O sur le tableau)
		troisO(); // deux O se trouvent sur un trio, la 3 e position est libre (quantre X trois O sur le tableau)
		
		return pos;
	}	
	public void unX(){	
		if(posX.size()==1 && posO.size()==0) {
			if(!posX.contains(4)) {
				posO.add(4);
				pos=4;							
					}else {																																
						Random randomNo = new Random();						 
						int m = tab1.get(randomNo.nextInt(tab1.size()));					
						posO.add(m);
						pos=m;	
						
					}		
		}	
	}
	public void deuxXsansO(){
		for(int i = 0 ; i < win.size(); i++) {							 
			for(int j = 0 ; j< 3;j++) {	
				if(win.get(i).containsAll(posX) && Collections.disjoint(win.get(i), posO) && posX.size()==2 && posO.size()==1) {
					int m=(int)(win.get(i)).get(j);												
						if(!posX.contains(m) ) {
							posO.add(m);
							pos=m;
							
						}
				}
			}
		}
	}
	
	public void deuxXunO() {
		for(int i = 0 ; i < win.size(); i++) {			
			for(int j = 0 ; j < 3; j++) {	   
				if(win.get(i).containsAll(posX)  && !Collections.disjoint(win.get(i), posO) && posX.size()==2 && posO.size()==1 && posO.contains(4) ){
					if( posX.contains(0) && posX.contains(2)){													
						posO.add(1);
						pos=1;
						
						}else if (posX.contains(0) && posX.contains(6)){	
							posO.add(3);
							pos=3;
							
						}else if (posX.contains(2) && posX.contains(8)){	
							posO.add(5);
							pos=5;
							
						}else if (posX.contains(6) && posX.contains(8)){	
							posO.add(7);
							pos=7;
							
						}	
					if(( posX.contains(0) && posX.contains(8)) || (posX.contains(2) && posX.contains(6))) {
						Random randomNo = new Random();						 
						int m = tab2.get(randomNo.nextInt(tab2.size()));							
						posO.add(m);
						pos=m;
						
						break;					
							}else if (tab2.containsAll(posX)){   						    				
								Random randomNo = new Random();				 
								int m = tab1.get(randomNo.nextInt(tab1.size()));				
								posO.add(m);					 		
								pos=m;
								
								break;
							}							
				}				
			}			 	  	  
		} 
	}
	
	public void intersectionO(){
		for(int i = 0 ; i < win.size(); i++) {			
			for(int j = 0 ; j < 3; j++) {	
				if(!Collections.disjoint(win.get(i), posX) && !win.get(i).containsAll(posX) && !tab1.containsAll(posX) && Collections.disjoint(win.get(i), posO) && posX.size()==2 && posO.size()==1 && posO.contains(4)){	   				
					int m =(int)(win.get(i).get(j));
	   				if(!set1.add(m) && !posX.contains(m)) {
	   					posO.add(m);
	   					pos=m;
	   					
	   				}else {
	   			    	set1.add(m);
	   			    }		                              	                 
	   	        } 	    	   	    		   	
				
	    	   }										
			}
		}
	
	public void deuxXcentreX(){
		for(int i = 0 ; i < win.size(); i++) {							 
			for(int j = 0 ; j< 3;j++) {															   						
				 if(win.get(i).containsAll(posO) && win.get(i).containsAll(posX) && !Collections.disjoint(tab1, posX) && posX.size()==2 && posO.size()==1 && posX.contains(4))  {	
					 Random randomNo = new Random();						 
					 int m = tab2.get(randomNo.nextInt(tab2.size()));				
						 posO.add(m);
						 pos=m;
						 
						 break;
					 }										
				 }
			}
		}
	
	public void deuxOsansX(){		
		for(int i = 0 ; i < win.size(); i++) {			
			for(int j = 0 ; j< 3;j++) {					
				if(win.get(i).containsAll(posO) && Collections.disjoint(win.get(i), posX) && posX.size()==3 && posO.size()==2   ) {
					int m=(int)(win.get(i)).get(j); 
						if(!posO.contains(m)  ) {											
							posO.add(m);
							pos=m;
							
					}						
				}	
			}  
		}
		
	}
	public void troisO(){		
		for(int i = 0 ; i < win.size(); i++) {			
			for(int j = 0 ; j< 3;j++) {					
				if(!Collections.disjoint(win.get(i), posO) && Collections.disjoint(win.get(i), posX) && posX.size()==4 && posO.size()==3   ) {
					int m=(int)(win.get(i)).get(j); 
						if(!posO.contains(m)  ) {											
							posO.add(m);
							pos=m;
							
					}						
				}	
			}  
		}
		
	}
	public void troisOquantreX(){		
		for(int i = 0 ; i < win.size(); i++) {			
			for(int j = 0 ; j< 3;j++) {					
				if(!Collections.disjoint(win.get(i), posO) && Collections.disjoint(win.get(i), posX) && posX.size()==4 && posO.size()==3   ) {
					int m=(int)(win.get(i)).get(j); 
						if(!posO.contains(m)  ) {											
							posO.add(m);
							pos=m;
							
					}						
				}	
			}  
		}
		
	}
	
	public void deuxX(){
		for(int i = 0 ; i < win.size(); i++) {							 
			for(int j = 0 ; j< 3;j++) {	
				if(Collections.disjoint(win.get(i), posO) && !Collections.disjoint(win.get(i), posX) && posX.size()==3 && posO.size()==2 ) {
					int m=(int)(win.get(i)).get(j);												
					if(!posX.contains(m) ) {
						posO.add(m);
						pos=m;
						
					}
				}
			}
		}
	}
	public void quatreX(){
		for(int i = 0 ; i < win.size(); i++) {							 
			for(int j = 0 ; j< 3;j++) {	
				if(Collections.disjoint(win.get(i), posO) && !Collections.disjoint(win.get(i), posX) && posX.size()==4 && posO.size()==3 ) {
					int m=(int)(win.get(i)).get(j);												
					if(!posX.contains(m) ) {
						posO.add(m);
						pos=m;
						
					}
				}
			}
		}
	}
	public void troisXcentreX(){
		int k=0;
		for(int i = 0 ; i < win.size(); i++) {
			if(Collections.disjoint(win.get(i), posO) && posX.size()==3 && posO.size()==2 && posX.contains(4)){						
				for(int j = 0 ; j < 3; j++) {					   				
					int m =(int)(win.get(i).get(j));	   							 
	   				if(!posX.contains(m) && set4.add(m) ) {
	   					set4.add(m);	   				
	   					k=m;	   						   					   					
	   				}	
				}
	   				if(set4.size()==2 && !posO.contains(k)) {
	   					posO.add(k);
	   					pos=k;
	   						   	         	    	   	    		   					
	    	   }										
			}
		}
	}
	public boolean gagnant(String joueur, int[] tabG ){	
		if(joueur=="O") {
			for(int i = 0 ; i < win.size(); i++){	
				for(int j = 0 ; j < win.get(i).size(); j++) {
					int	m=(int)(win.get(i)).get(j);					
						if( posO.contains(m) && Collections.disjoint(win.get(i), posX) && win.get(i).containsAll(posO) ){		
							set2.add(m);
							tabG[j]=m;											
						}					
				}
			if(set2.size()==3 ) {
				return true;	
			}
		}
	}
	if(joueur=="X") {
			for(int i = 0 ; i < win.size(); i++){	
				for(int j = 0 ; j < win.get(i).size(); j++) {
					int	m=(int)(win.get(i)).get(j);
						if( posX.contains(m) && win.get(i).containsAll(posX) && Collections.disjoint(win.get(i), posO)){						
							set3.add(m);
							tabG[j]=m;											
						}					
				}
			}
			if(set3.size()==3) {
				return true;	
			}						
		}
		return false;
	}
	
	public void testDebug(int[] indicesCoups){
		for(int i=0; i<indicesCoups.length; i++){
			if(i%2==0 ) {
				posX.add(indicesCoups[i]);	 				        
			 		}else if((i%2!=0 )){
			 			posO.add(indicesCoups[i]);	 
			 		}  
	        }
		 System.out.print("Positions de X:\n");
		 for (int j = 0; j <posX.size(); j++) {
			 System.out.print(posX.get(j)+"\n");
		 }
		 System.out.print("Positions de O:\n");
		 for (int j = 0; j <posO.size(); j++) {
	            System.out.print(posO.get(j)+"\n");
		 }
	}
	public boolean isPartieNulle(){
		if(!gagnant("O", tabG ) || !gagnant("X", tabG )) {
		 if(posX.size()==5 && posO.size()==4) {			
			 return true;		 
		 }
		}
		 return false;
	 }	
}