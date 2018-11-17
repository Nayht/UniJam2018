using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class DialogueEngine : MonoBehaviour
{

	private Story story;
	
	// Use this for initialization
	void Start ()
	{
		story = new Story("Assets/Dialogues/New Ink.json");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
