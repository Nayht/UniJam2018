using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofController : MonoBehaviour {

	private SpriteRenderer sr;
	[SerializeField] private float timeToFade = 1;
	private float invTimeToFade;


	void Start () {
		sr = this.GetComponent<SpriteRenderer> ();
		invTimeToFade = 1 / timeToFade;
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag == "Character") {
			StartCoroutine (Fade());
		}
	}

	IEnumerator Fade() {
		Color tmp = sr.color;
		float time = 0;
		float deltaTime;
		while (time < timeToFade) {
			deltaTime = Time.deltaTime;
			time += deltaTime;
			tmp.a = 1 - time*invTimeToFade;
			sr.color = tmp;
			yield return null;
		}
		tmp.a = 0f;
		sr.color = tmp;
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag == "Character") {
			StartCoroutine (FadeBack());
		}
	}

	IEnumerator FadeBack() {
		Color tmp = sr.color;
		float time = 0;
		float deltaTime;
		while (time < timeToFade) {
			deltaTime = Time.deltaTime;
			time += deltaTime;
			tmp.a = time*invTimeToFade;
			sr.color = tmp;
			yield return null;
		}
		tmp.a = 1f;
		sr.color = tmp;
	}

}
