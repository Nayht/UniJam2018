using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	[SerializeField] private GameObject player;

	[SerializeField] private float minX;
	[SerializeField] private float maxX;
	[SerializeField] private float minY;
	[SerializeField] private float maxY;


	void Start () {
		FollowPlayer ();
	}
	

	void Update () {
		FollowPlayer ();
	}

	void FollowPlayer () {
		float X = player.transform.position.x;
		X = AdjustX (X);
		float Y = player.transform.position.y;
		Y = AdjustY (Y);
		float Z = this.transform.position.z;

		this.transform.position = new Vector3 (X, Y, Z);

	}
	float AdjustX (float X) {
        float newX = X;
		if (newX < minX) {
			newX = minX;
		}
		if (newX > maxX) {
			newX = maxX;
		}
        return newX;
	}
	float AdjustY (float Y) {
        float newY = Y;
		if (newY < minY) {
			newY = minY;
		}
		if (newY > maxY) {
			newY = maxY;
		}
        return newY;
	}

}
