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
}
