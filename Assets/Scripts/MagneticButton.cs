using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MagneticButton : MonoBehaviour {
	private enum CalcMode {
		Root, Quadratic
	}
	
	[SerializeField] private bool debug;							// Debug mode toggle
	[SerializeField] private CalcMode mode = CalcMode.Quadratic;	// Calculation mode
	[Range(0, 1)] [SerializeField] private float power = .5f;		// Strength of movement force
	[SerializeField] private float range = 250;						// Range in which the button operates
	[SerializeField] private float maxDistance = 100;				// Distance the button moves from the tether point when the cursor is closest to the tether.

	private Vector3 tether;
	private Vector3 relativeTether;
	private RectTransform rt;

	private void Start() {
		rt = GetComponent<RectTransform>();
		
		// Save absolute tether position
		tether = rt.position;
		// Save tether position relative to canvas
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

		// Calculate direction the button should move in, which is the opposite of the cursor-to-tether direction and
		// normalize
		Vector3 movementDir = -(mPos - tether).normalized;
		if (debug) Debug.DrawRay(tether, movementDir * 1500, Color.green);

		// Normalized distance from mouse to tether, relative to the button's detection range parameter
		float distanceNormalized = distToTether / range;
		
		float moveDistance;
		if (mode == CalcMode.Root) {
			// Calculate distance based on simple scaled root function 
			moveDistance = (1 - Mathf.Sqrt(distanceNormalized)) * power;
		}
		else {
			// Calculate distance based on quadratic formula
			moveDistance = Mathf.Pow(distanceNormalized - 1, 6) * Mathf.Sqrt(power);
		}

		// Apply new position
		rt.localPosition = Vector3.Lerp(rt.localPosition, relativeTether + movementDir * moveDistance * maxDistance, Time.deltaTime * 30);

		// Draw debug lines
		if (debug) {
			Debug.DrawLine(mPos, rt.position, Color.cyan);
			Debug.DrawLine(mPos, tether, Color.blue);
		}
	}
}