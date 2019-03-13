using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Couch : NpcController {

	private bool isOccupied;
	
	public override string Interact(GameObject go) {
		if (isOccupied) {
			GetComponent<BoxCollider2D>().enabled = true;
			go.GetComponent<PlayerMovement>().SetMoveEnabled(true);
			
			isOccupied = false;
			return "bye.";
		}
		
		if (!inRange) return null;
		
		if (!isOccupied) {
			GetComponent<BoxCollider2D>().enabled = false;
			
			go.transform.position = transform.position - new Vector3(.5f, .5f, 0f);
			go.GetComponent<PlayerMovement>().SetMoveEnabled(false);
			
			isOccupied = true;
		}
		
		return "Couch says hi!";
	}
	
}