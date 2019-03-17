using System;
using Dialogue.Nodes;
using UnityEngine;
using XNode;

namespace Dialogue {
	[Serializable, CreateAssetMenu]
	public class DialogueGraph : NodeGraph {

		private DialogueNode entryPoint;
		private DialogueNode current;

		public void Initialize() {
			if (entryPoint != null) {
				current = entryPoint;
			}
			else {
				Debug.Log("Please set entry point");
			}
		}
		
		public void Continue() {
			if (entryPoint == null) {
				Debug.Log("Please set entry point");
				return;
			}
			
			if (current == null) {
				Initialize();
			}
			current.MoveNext();
		}

		public void SetEntryPoint(DialogueNode node) {
			entryPoint = node;
		}

		public DialogueNode GetEntryPoint() {
			return entryPoint;
		}

		public void SetCurrent(DialogueNode node) {
			current = node;
		}

		public DialogueNode GetCurrent() {
			return current;
		}
	}
}