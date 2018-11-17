using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class GuiManager : MonoBehaviour
{

	private static Text textDisplay;
	private static Image backgroundDisplay;
	
	// Use this for initialization
	void Start ()
	{
		textDisplay = GetComponentInChildren<Text>();
		backgroundDisplay = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Display(string toDisplay)
	{
		textDisplay.enabled = true;
		textDisplay.enabled = true;
		textDisplay.text = toDisplay;
	}

	public static void HideDisplay()
	{
		backgroundDisplay.enabled = false;
		textDisplay.enabled = false;
	}
}
