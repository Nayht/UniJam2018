using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// over MonoBehaviours
	private MoveEngine moveEngine;
	private DialogueEngine dialogEngine;
	private Transform transform;
	private Character character;
	private Collider2D collider;

	// to keep track of the mouse position to chase it
	private bool chase_mouse;
	private Vector2 mouse_position;
	[SerializeField]
	private float distance_stop = 0.1f;
	[SerializeField]
	private float distance_dialogue = 2.0f;

	// to see if click is relevant
	private float time_click_down;
	private float time_click_up;
	private float time_relevant = 1.0f;
	private float distance_relevant = 2.0f;

	public static bool inDialogue;
	
	// Use this for initialization
	void Start () {
		moveEngine = GetComponent<MoveEngine>();
		dialogEngine = GetComponent<DialogueEngine>();
		transform = GetComponent<Transform>();
		character = GetComponent<Character>();
		collider = GetComponent<Collider2D>();
		chase_mouse = false;
	}
	
	// Update is called once per frame
	void Update () {
		movementController();
		if (inDialogue && Input.GetMouseButtonUp(0) && dialogEngine != null)
		{
			dialogEngine.Progress();
		}

		if (Input.GetKeyUp("h"))
		{
			GuiManager.ToggleHistory();
		}
	}

	// called if moused over
	void OnMouseOver() {
		if (!inDialogue && !character.has_dialogue)
		{
			if (Input.GetMouseButtonDown(1))
			{
				time_click_down = Time.time;
			}

			if (Input.GetMouseButtonUp(1))
			{
				time_click_up = Time.time;
				if (time_click_up - time_click_down < time_relevant)
				{
					Character player = GetPlayerInRadius(distance_relevant);
					if (player != null)
					{
						MoveEngine player_move_engine = player.GetComponent<MoveEngine>();
						player.is_player = false;
						player_move_engine.move(Vector2.zero);
						player_move_engine.can_move = false;
						player.GetComponent<Collider2D>().isTrigger = true;
						// TODO : launch animation
						Debug.Log("WOOOOOSH");
						moveEngine.can_move = true;
						character.is_player = true;
						collider.isTrigger = false;
					}
				}
			}
		}
		else if (character.has_dialogue)
		{
			if (!inDialogue && Input.GetMouseButtonUp(0))
			{
				Character player = GetPlayerInRadius(distance_dialogue);
				if (player != null)
				{
					inDialogue = true;
					chase_mouse = false;
					if (player.age == character.acceptsAge)
					{
						Debug.Log("Good age");
						dialogEngine.GoodAgeProgress();
					}
					else
					{
						dialogEngine.Progress();
					}
				}
			}
		}
	}
	
	private Character GetPlayerInRadius(float radius)
	{
		Collider2D[] collider_nearby;
		Vector2 position = new Vector2(transform.position.x, transform.position.y);
		collider_nearby = Physics2D.OverlapCircleAll(position,radius);
		Character other_character;
		foreach (Collider2D col in collider_nearby)
		{
			other_character = col.GetComponent<Character>();
			if (other_character == null) continue;
			if (other_character.is_player)
			{
				return (other_character);
			}
		}

		return (null);
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
		if (Input.GetMouseButtonDown(0) && !inDialogue) // left click
		{
			// TODO : Need to check if anyone is under the mouse, you don't want to keep walking into people eternally
			chase_mouse = chase_mouse == false;
			mouse_position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		}
		if (chase_mouse && !inDialogue)
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
		if (keyboard_direction.magnitude > 0 && !inDialogue)
		{
			direction = keyboard_direction;
			chase_mouse = false;
		}
		// MOVE
		moveEngine.move(direction);
	}
}
