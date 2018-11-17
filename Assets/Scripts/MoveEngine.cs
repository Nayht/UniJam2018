using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEngine : MonoBehaviour {

	Rigidbody2D rb;
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
	}
	
	public void move(Vector2 direction) {
		Vector2 velocity = direction;
		velocity.Normalize();
		// normalize depending on age
		if (true) {
			velocity = velocity*speed_adult;
		}
		rb.velocity = velocity;
	}
}
