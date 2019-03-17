using Dialogue;
using Dialogue.Nodes;
using UnityEngine;

public class GameManager : MonoBehaviour {
	[SerializeField] private DialogueSystem dialogueSystem;

	private void Start() {
		DialogueGraph graph = dialogueSystem.GetDialogueGraph();
		graph.Initialize();
		
		for (int i = 0; i < graph.nodes.Count - 1; i++) {
			DialogueNode node = graph.GetCurrent();
			if (node is TextNode textNode) {
				Debug.Log(textNode.GetText());
			}
			else if (node is BinaryChoiceNode bcNode) {
				Debug.Log("Binary choice: " + bcNode.GetChoiceText(0) + " or " + bcNode.GetChoiceText(1));
				int choice = Mathf.RoundToInt(Random.Range(0, 1));
				Debug.Log("Chose: " + bcNode.GetChoiceText(choice));
				bcNode.SetChoice(choice);
			}
			graph.Continue();
		}
		
	}
}