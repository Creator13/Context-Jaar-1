using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class MovingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	[SerializeField] private float minRange = 100;
	[SerializeField] private float maxRange = 250;
	[SerializeField] private float speed = 1;
	[SerializeField] private float timeout = .7f;

	private bool moving;
	private Vector3 movePos;
	private float dist;
	private Vector3 moveDir;

	private float hoverTime;
	private bool hover;

	private RectTransform rt;

	private void Start() {
		if (minRange > maxRange) {
			maxRange = minRange;
			Debug.LogWarning("minRange exceeded maxRange so the maxRange was changed to the value of minRange.");
		}

		rt = GetComponent<RectTransform>();
	}

	private void Update() {
		if (hover && !moving) {
			hoverTime += Time.deltaTime;
		}

		if (hoverTime > timeout && !moving) {
			hoverTime = 0;
			MovePosition();
		}

		if (moving) {
			Move();
		}
	}

	public void OnPointerEnter(PointerEventData eventData) {
		hover = true;
	}

	public void OnPointerExit(PointerEventData eventData) {
		hover = false;
		hoverTime = 0;
	}

	private void MovePosition() {
		Vector3 randomDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
		float dist = Random.Range(minRange, maxRange);

		movePos = transform.position + randomDir * dist;
		//TODO clamp
		moving = true;
	}

	private void Move() {
		if (Vector3.Distance(transform.position, movePos) < .25f) {
			moving = false;
		}

		transform.position = Vector3.Lerp(transform.position, movePos, Time.deltaTime * speed);
	}
}