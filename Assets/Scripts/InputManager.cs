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
	[SerializeField]
	private float distance_dialogue = 0.5f;

	// to see if click is relevant
	private float time_click_down;
	private float time_click_up;
	private float time_relevant = 1.0f;
	private float distance_relevant = 2.0f;

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

	// called if has been clicked
	void OnMouseOver() {
		if (Input.GetMouseButtonDown(1))
		{
			time_click_down = Time.time;
		}
		if (Input.GetMouseButtonUp(1))
		{
			time_click_up = Time.time;
			if (time_click_up - time_click_down < time_relevant)
			{
				Collider2D[] collider_nearby;
				Vector2 position = new Vector2(transform.position.x, transform.position.y);
				collider_nearby = Physics2D.OverlapCircleAll(position,distance_relevant);
				//for( int i = 0 ; i < collider_nearby.length ; i++)
				foreach (Collider2D col in collider_nearby)
				{
					col.GetComponent<MoveEngine>().can_move = false;
				}
				moveEngine.can_move = true;
			}
		}
	}
/*
	void possession() {
		if (Input.GetMouseButtonDown(1)) // right click
		{
		}
	}
	*/

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
