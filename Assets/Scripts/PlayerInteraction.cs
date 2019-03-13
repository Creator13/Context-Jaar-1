using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
	private NpcController interactor;

	public void SetInteractor(NpcController interactor) {
		this.interactor = interactor;
	}

	private void Update() {
		if (Input.GetButtonDown("Interact")) {
			if (interactor) {
				Debug.Log(interactor.Interact(gameObject));
			}
		}
	}
}