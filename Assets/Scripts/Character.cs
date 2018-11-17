using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Character : MonoBehaviour
{
	[SerializeField]
	public Age age;
	private Age acceptsAge;

	public bool is_player = false;
	[FormerlySerializedAs("has_dialog")] public bool has_dialogue = false;

	private int dialogueProgression;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
