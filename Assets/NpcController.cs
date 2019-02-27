using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

	[SerializeField] private Sprite left;
	[SerializeField] private Sprite right;
	[SerializeField] private Sprite up;
	[SerializeField] private Sprite down;

	private GameObject player;
	private PlayerInteraction pi;
	private bool inRange;
	
	private void Start() {
		player = GameObject.FindWithTag("Player");
		pi = player.GetComponent<PlayerInteraction>();
	}

	private void Update() {
		float distToPlayer = Vector3.Distance(transform.position, player.transform.position);

		if (distToPlayer < 1f) {
			if (!inRange) {
				Debug.Log("Hello!");
				pi.SetInteractor(this);
				inRange = true;
			}
		}
		else {
			if (pi) {
				pi.SetInRange(false);
			}

			inRange = false;
		}
		
	}

	public string GetReply() {
		return "Hello back!";
	}
}