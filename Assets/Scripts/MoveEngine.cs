using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEngine : MonoBehaviour {

	private Character character;
	private Rigidbody2D rb;

	public bool can_move = false; // only active for the current possessed character, can be set false for dialogs and other stuff
	[SerializeField]
	private float speed_modifier = 1.5f;
	[SerializeField]
	private float speed_elder = 0.8f;
	[SerializeField]
	private float speed_adult = 1.0f;
	[SerializeField]
	private float speed_teen = 1.5f;
	[SerializeField]
	private float speed_child = 1.2f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		character = GetComponent<Character>();
	}

	void Update() {
		if (!character.is_player)
		{
			lambda_move();
		}
	}
	
	public void move(Vector2 direction) {
		if (can_move)
		{
			Vector2 velocity = direction;
			velocity.Normalize();
			velocity = velocity*speed_modifier;
			// normalize depending on age
			switch (character.age)
			{
				case Age.ELDER:
					velocity = velocity*speed_elder;
					break;
				case Age.ADULT:
					velocity = velocity*speed_adult;
					break;
				case Age.TEEN:
					velocity = velocity*speed_teen;
					break;
				case Age.CHILD:
					velocity = velocity*speed_child;
					break;
				default:
					velocity = velocity*speed_adult;
					break;
			}
			rb.velocity = velocity;
		}
	}

	public void lambda_move() {
		switch (character.direction)
		{
			case Direction.UP:
				move(new Vector2(0, 1));
				break;
			case Direction.DOWN:
				move(new Vector2(0, -1));
				break;
			case Direction.LEFT:
				move(new Vector2(-1, 0));
				break;
			case Direction.RIGHT:
				move(new Vector2(1, 0));
				break;
			default:
				move(new Vector2(0, -1));
				break;
		}
	}
}
