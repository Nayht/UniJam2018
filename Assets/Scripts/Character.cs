﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
	public static Object spirit;

	private InputManager inputManager;
	private MoveEngine moveEngine;
	private Collider2D collider;
	
	[SerializeField] public string name;
	[SerializeField] public Age age;
	[SerializeField] public Age acceptsAge;

	public bool is_player = false;
	public bool has_dialogue = false;
	public float counter_life; // time the character has been possessed
	[SerializeField]
	private float max_life = 30f;
	public float animation_time = 1f;

	private int dialogueProgression;

	public Slider mainSlider;
	public Image slider_fill;
	
	// Use this for initialization
	void Start () {
		moveEngine = GetComponent<MoveEngine>();
		inputManager = GetComponent<InputManager>();
		collider = GetComponent<Collider2D>();
		counter_life = 0;
		mainSlider = (GameObject.FindObjectsOfType(typeof(Slider)) as Slider[])[0];
		slider_fill = (GameObject.Find("SliderFill")).GetComponent<Image>();
		spirit = Resources.Load("Prefabs/Spirit");
	}
	
	// Update is called once per frame
	void Update () {
		if (is_player)
		{
			grow_old();
		}
		//temporary
		SpriteRenderer spr = GetComponent<SpriteRenderer>();
		switch(age)
		{
			case Age.ELDER:
				spr.color = Color.grey;
				break;
			case Age.ADULT:
				spr.color = Color.red;
				break;
			case Age.TEEN:
				spr.color = Color.yellow;
				break;
			case Age.CHILD:
				spr.color = Color.cyan;
				break;
			default:
				spr.color = Color.red;
				break;
		}
	}

	void grow_old() {
		counter_life += Time.deltaTime;
		mainSlider.value = (max_life - counter_life)/max_life;
		if (mainSlider.value > 0.5f)
		{
			slider_fill.color = new Color(0f,0.8f,0f);
		}
		else if (mainSlider.value > 0.2f)
		{
			slider_fill.color = new Color(0.8f,0.8f,0f);
		}
		else
		{
			slider_fill.color = new Color(0.8f,0f,0f);
		}
		if (counter_life > max_life)
		{
			// TODO : animation
			if (age < Age.ELDER)
			{
				counter_life = 0f;
				age++;
			}
			else
			{
				Character nearest = find_nearest_possessable();
				if (nearest != null)
					nearest.switch_corpse(this);
				else
				{
					// TODO : Message caché
					// "Félicitations, cette situation n'était pas supposée arriver, voici une nouvelle chance de continuer"
					counter_life = 0;
					age = Age.CHILD;
				}
			}
		}
	}

	// finds the nearest Character you can possess
	public Character find_nearest_possessable() {
		float distance_min = -1f;
		float distance_cur;
		Character[] others = GameObject.FindObjectsOfType(typeof(Character)) as Character[];
		Character nearest = null;
		foreach ( Character other in others)
		{
			distance_cur = (other.GetComponent<Transform>().position - transform.position).magnitude;
			if (can_ultimate_possess(other, distance_cur, distance_min))
			{
				distance_min = distance_cur;
				nearest = other;
			}
		}
		return nearest;
	}

	// returns if the Character can be possessed with the last chance nearest Character available switch
	private bool can_ultimate_possess (Character other, float distance_cur, float distance_min)
	{
		return (other != this &&						// not the same object
				other.is_young_enough() &&				// young enough
				other.GetComponent<SpriteRenderer>().isVisible &&	// is seen by the camera
				!other.has_dialogue &&					// has no dialog
				(distance_cur < distance_min || distance_min == -1f));	// is less far than another
	}

	// returns if the Character is young enough to be possessed
	public bool is_young_enough() {
		if (age < Age.ELDER)
			return true;
		else 
			return counter_life < max_life;
	}

	public void set_active_player() {
		is_player = true;
		moveEngine.can_move = true;
		collider.isTrigger = false;
		inputManager.time_last_proxy_possess = Time.time;
	}

	public void switch_corpse(Character other) {
		if (is_young_enough() && !has_dialogue)
		{
			MoveEngine other_move_engine = other.GetComponent<MoveEngine>();
			InputManager other_input_manager = other.GetComponent<InputManager>();
			Collider2D other_collider = other.GetComponent<Collider2D>();

			other.is_player = false;
			other_move_engine.move(Vector2.zero);
			other_move_engine.can_move = false;
			other_input_manager.chase_mouse = false;
			other_collider.isTrigger = true;
			// TODO : launch animation
			GameObject spirit_orb = Instantiate(spirit) as GameObject;
			spirit_orb.GetComponent<SpiritTravel>().initialize(other.transform.position, transform.position, animation_time);
			//
			Invoke("set_active_player", animation_time);
		}
	}
}
