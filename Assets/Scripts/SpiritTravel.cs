using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritTravel : MonoBehaviour {

	public float travel_time = 0f;
	public float time_lived;
	
	private Vector3 direction;
	private Vector3 travel_origin;

	// Use this for initialization
	void Start () {
		
	}

	public void initialize(Vector3 origin, Vector3 destination, float life_time) {
		travel_origin = origin;
		direction = destination - origin;
		transform.position = origin;
		travel_time = life_time;
		time_lived = 0f;
		gameObject.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		time_lived += Time.deltaTime;
		transform.position = travel_origin + (time_lived/travel_time)*direction;
		if (time_lived > travel_time)
		{
			Destroy(gameObject);
		}
	}
}
