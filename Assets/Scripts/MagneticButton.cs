using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MagneticButton : MonoBehaviour {
	private enum CalcMode {
		Root, Quadratic
	}
	
	[SerializeField] private bool debug;
	[SerializeField] private CalcMode mode = CalcMode.Quadratic;
	[Range(0, 1)] [SerializeField] private float power = .5f;
	[SerializeField] private float range = 250;
	[SerializeField] private float maxDistance = 100;

	private Vector3 tether;
	private Vector3 relativeTether;
	private RectTransform rt;

	private void Start() {
		rt = GetComponent<RectTransform>();
		tether = rt.position;
		relativeTether = rt.localPosition;
	}

	private void Update() {
		// Current mouse position, calc distance to tether, calc dir opposite to mouse-button dir
		Vector3 mPos = Input.mousePosition;
		float distToTether = Vector3.Distance(mPos, tether);

		// Do not continue if cursor is out of range but draw debug line
		if (distToTether > range) {
			if (debug) Debug.DrawLine(mPos, tether, Color.red);
			return;
		}

		// Calculate normalized vector 
		Vector3 movementDir = -(mPos - tether).normalized;
		if (debug) Debug.DrawRay(tether, movementDir * 1500, Color.green);

		float distanceNormalized = distToTether / range;
		
		float moveDistance;
		if (mode == CalcMode.Root) {
			moveDistance = (1 - Mathf.Sqrt(distanceNormalized)) * power; // Simple root function
		}
		else {
			moveDistance = Mathf.Pow(distanceNormalized - 1, 6) * Mathf.Sqrt(power);
		}

		rt.localPosition = relativeTether + movementDir * moveDistance * maxDistance;

		if (debug) {
			Debug.DrawLine(mPos, rt.position, Color.cyan);
			Debug.DrawLine(mPos, tether, Color.blue);
		}
	}
}