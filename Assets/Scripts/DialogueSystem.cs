using System;
using Dialogue;
using UnityEngine;

[Serializable]
public class DialogueSystem {
	[SerializeField] private DialogueGraph dialogue;
	
	public DialogueSystem() {
		
	}

	public DialogueGraph GetDialogueGraph() {
		return dialogue;
	}

}