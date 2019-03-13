using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

	[SerializeField] private Sprite left;
	[SerializeField] private Sprite right;
	[SerializeField] private Sprite up;
	[SerializeField] private Sprite down;

	private GameObject player;
	protected PlayerInteraction pi;
	protected bool inRange;
	
	private void Start() {
		player = GameObject.FindWithTag("Player");
		pi = player.GetComponent<PlayerInteraction>();
	}

	private void Update() {
		float distToPlayer = Vector3.Distance(transform.position, player.transform.position);

//		Debug.Log(gameObject.name + ": " + distToPlayer);
		
		if (distToPlayer < 1.5f) {
//			Debug.Log("Distance small enough");
			if (!inRange) {
				Debug.Log("Hello!");
				pi.SetInteractor(this);
				inRange = true;
			}
		}
		else {
//			Debug.Log("Distance too big");

			inRange = false;
		}
		
	}

	public virtual string Interact(GameObject go) {
		return inRange ? "Hello back!" : null;
	}
}