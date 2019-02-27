using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {

	private bool canInteract = false;
	private NpcController interactor;

	public void SetInteractor(NpcController interactor) {
		SetInRange(true);

		this.interactor = interactor;
	}

	public void SetInRange(bool inRange) {
		canInteract = inRange;
	}

	private void Update() {
		if (Input.GetButtonDown("Interact")) {
			Debug.Log(interactor.GetReply());
		}
	}
}