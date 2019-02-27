using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour {

	private enum Direction {
		Up, Down, Left, Right, None
	}
	
	[SerializeField] private Sprite spLeft, spRight, spUp, spDown;

	[SerializeField] private Direction startDirection = Direction.Down;
	[SerializeField] private float walkingSpeed = 4;

	[SerializeField] private Camera followerCamera;
	[SerializeField] private float distanceToScreenEdge = .2f;
	
	private Direction moveDir = Direction.None;
	
	private SpriteRenderer spRenderer;
	private Rigidbody2D rb;

	private void Start() {
		spRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
		
		Sprite startSprite;
		
		switch (startDirection) {
			case Direction.Up:
				startSprite = spUp;
				break;
			case Direction.Down:
				startSprite = spDown;
				break;
			case Direction.Left:
				startSprite = spLeft;
				break;
			case Direction.Right:
				startSprite = spRight;
				break;
			default:
				startSprite = null;
				break;
		}

		spRenderer.sprite = startSprite;
	}

	private void Update() {
		followerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, followerCamera.transform.position.z);
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			if (Input.GetKeyDown(KeyCode.A)) {
				moveDir = Direction.Left;
			}
			else if (Input.GetKeyDown(KeyCode.D)) {
				moveDir = Direction.Right;
			}
			else if (Input.GetKeyDown(KeyCode.W)) {
				moveDir = Direction.Up;
			}
			else if (Input.GetKeyDown(KeyCode.S)) {
				moveDir = Direction.Down;
			}
		}
	}

	private void FixedUpdate() {
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			if (moveDir != Direction.None) {
				MovePlayer(moveDir);
			}
		}
	}

	private void MovePlayer(Direction dir) {
		Vector2 walkingVector;
		
		switch (dir) {
			case Direction.Up:
				spRenderer.sprite = spUp;
				walkingVector = Vector2.up * walkingSpeed;
				break;
			case Direction.Down:
				spRenderer.sprite = spDown;
				walkingVector = Vector2.down * walkingSpeed;
				break;
			case Direction.Left:
				spRenderer.sprite = spLeft;
				walkingVector = Vector2.left * walkingSpeed;
				break;
			case Direction.Right:
				spRenderer.sprite = spRight;
				walkingVector = Vector2.right * walkingSpeed;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
		}
		
		rb.MovePosition(rb.position += walkingVector * Time.fixedDeltaTime);
	}
	
}
