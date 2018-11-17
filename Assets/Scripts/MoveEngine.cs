using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEngine : MonoBehaviour {

	public bool can_move; // only active for the current possessed character, can be set false for dialogs and other stuff
	Rigidbody2D rb;
	[SerializeField]
	private float speed_modifier = 1.5f;
	[SerializeField]
	private float speed_old = 0.8f;
	[SerializeField]
	private float speed_adult = 1.0f;
	[SerializeField]
	private float speed_teen = 1.5f;
	[SerializeField]
	private float speed_child = 1.2f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		can_move = true;
	}
	
	public void move(Vector2 direction) {
		if (can_move)
		{
			Vector2 velocity = direction;
			velocity.Normalize();
			velocity = velocity*speed_modifier;
			// normalize depending on age
			if (true) {
				velocity = velocity*speed_adult;
			}
			rb.velocity = velocity;
		}
	}
}
