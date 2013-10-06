using UnityEngine;
using System.Collections;

public class ShipSelectorGUI : MonoBehaviour {
	
	public Airship prototypeAirship;
	public Airplane prototypeAirplane;
	public Jetpack prototypeJetpack;
	
	void OnGUI () {
		GUI.Box(new Rect(10,10,100,120), "Choose Ship");

		if(GUI.Button(new Rect(20,40,80,20), "Airship")) {
			SelectShip(1);
		}

		if(GUI.Button(new Rect(20,70,80,20), "Airplane")) {
			SelectShip(2);
		}
		
		if(GUI.Button(new Rect(20,100,80,20), "Jetpack")) {
			SelectShip(3);
		}
	}
	void SelectShip(int Shiptype){
		
		switch (Shiptype){
    		case 1:
	        	Debug.Log("Spawn Airship as Player");	
				Airship PlayerAirship = (Airship)Instantiate(prototypeAirship, transform.position + transform.forward*15f, Quaternion.identity);
	        	break;
			case 2:
		    	Debug.Log("Spawn Airplane as Player");
				Airplane PlayerAirplane = (Airplane)Instantiate(prototypeAirplane, transform.position + transform.forward*15f, Quaternion.identity);
	        	break;
			case 3:
		    	Debug.Log("Spawn Jetpack as Player");
				Jetpack PlayerJetpack = (Jetpack)Instantiate(prototypeJetpack , transform.position + transform.forward*15f, Quaternion.identity);
	        	break;
			default:
		    	Debug.Log("Should never happen.");
		    	break;
		}
				
	}
}

