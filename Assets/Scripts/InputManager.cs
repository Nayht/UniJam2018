using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// over MonoBehaviours
	private MoveEngine moveEngine;
	private Transform transform;
	private Character character;
	private Collider2D collider;
	private Rigidbody2D rb;

	// to keep track of the mouse position to chase it
	private bool chase_mouse;
	private Vector2 mouse_position;
	[SerializeField]
	private float distance_stop = 0.1f;
	[SerializeField]
	private float distance_dialogue = 0.5f;
	private float min_velocity = 0.01f;

	// to see if click is relevant
	private float time_click_down;
	private float time_click_up;
	private float time_relevant = 1.0f;
	private float distance_relevant = 2.0f;

	// Use this for initialization
	void Start () {
		moveEngine = GetComponent<MoveEngine>();
		transform = GetComponent<Transform>();
		character = GetComponent<Character>();
		collider = GetComponent<Collider2D>();
		rb = GetComponent<Rigidbody2D>();
		chase_mouse = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (character.is_player)
		{
			movementController();
		}
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
				Character other_character;
				MoveEngine other_move_engine;
				foreach (Collider2D col in collider_nearby)
				{
					other_character = col.GetComponent<Character>();
					if (other_character != null && col != collider) // if is a character and is not the same object
					{
						if (other_character.is_player)
						{
							other_move_engine = col.GetComponent<MoveEngine>();
							other_character.is_player = false;
							other_move_engine.move(Vector2.zero);
							other_move_engine.can_move = false;
							col.GetComponent<InputManager>().chase_mouse = false;
							col.isTrigger = true;
							// TODO : launch animation
							Debug.Log("WOOOOOSH, you are " + ((Age)character.age).ToString());
							moveEngine.can_move = true;
							character.is_player = true;
							collider.isTrigger = false;
							break;
						}
					}

				}
			}
		}
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
		/*
		if (rb.velocity.magnitude == 0f)
		{
			chase_mouse = false;
		}
		*/
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
