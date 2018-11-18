using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {

    // Use this for initialization
    private Vector2 target;
    private Vector2 startPosition;
    private float timeout;
    private float timeBeforeMoving;
    private float timeSinceLastMove;
    private bool isMoving;


    float wanderRange;

    void Start () {
        this.wanderRange = 0.05f;
        this.timeSinceLastMove=0;
        this.timeBeforeMoving = Random.value * 5 + 5;
	}
	
	// Update is called once per frame
	void Update () {
        this.timeSinceLastMove += Time.deltaTime;
        if (this.timeSinceLastMove > this.timeBeforeMoving)
        {
            wander();
            this.timeSinceLastMove = 0;
        }
        this.transform.Translate((this.target-this.startPosition)*0.05f);
	}

    void wander()
    {
        this.isMoving = true;
        float wanderRange = 0.1f;
        float xWander = (Random.value - 0.5f)*wanderRange;
        float yWander = (Random.value - 0.5f)*wanderRange;
        this.target = new Vector2(this.transform.position.x+xWander, this.transform.position.y+yWander);
        this.startPosition = this.transform.position;
    }
}
