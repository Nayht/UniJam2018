using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrefour : MonoBehaviour {



	void OnTriggerExit2D(Collider2D col)
	{

		if(col.gameObject.tag == ("Character"))
		{
			MoveEngine me = col.GetComponent<MoveEngine>();
			bool b = me.can_move;
			
			Character chara = col.GetComponent<Character>();
			bool b2 = chara.is_player;

			if(b && !b2)
			{
				
				int r =Random.Range(1,4);
				chara.direction = (Direction)(((int)(chara.direction)+r) %4);
				chara.Change(chara.age, chara.direction);
			}

		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
