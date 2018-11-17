using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// over MonoBehaviours
	private MoveEngine moveEngine;
	private Transform transform;

	// to keep track of the mouse position to chase it
	private bool chase_mouse;
	private Vector2 mouse_position;
	[SerializeField]
	private float distance_stop = 0.1f;

	// Use this for initialization
	void Start () {
		moveEngine = GetComponent<MoveEngine>();
		transform = GetComponent<Transform>();
		chase_mouse = false;
	}
	
	// Update is called once per frame
	void Update () {
		movementController();
	}

	// gets the input and generates a direction for moveEngine.move
	void movementController() {
		Vector2 direction = Vector2.zero; // the direction of the movement
		Vector2 keyboard_direction; // the direction given by the keyboard
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		// MOUSE
		if (Input.GetMouseButtonDown(0)) // left click
		{
			// TODO : Need to check if anyone is under the mouse, you don't want to keep walking into people eternally
			chase_mouse = chase_mouse == false;
			mouse_position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		}
		if (chase_mouse)
		{
			direction = mouse_position - position;
			// if we are close enough we stop
			if (direction.magnitude < distance_stop)
			{
				chase_mouse = false;
			}
		}
		// KEYBOARD
		keyboard_direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		// the keyboard is prioritary
		if (keyboard_direction.magnitude > 0)
		{
			direction = keyboard_direction;
			chase_mouse = false;
		}
		// MOVE
		moveEngine.move(direction);
	}
}
