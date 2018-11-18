using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

// TODO Réussir à toggle tout l'historique

public class GuiManager : MonoBehaviour
{

	private static Text textDisplay;
	private static Image backgroundDisplay;
	private static Text historyText;
	private static ScrollView historyDisplay;
	
	// Use this for initialization
	void Start ()
	{
		textDisplay = GetComponentInChildren<Text>();
		backgroundDisplay = GetComponent<Image>();
//		historyDisplay = GameObject.Find("History");
		historyText = GameObject.Find("History Text").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Display(string name,string toDisplay)
	{
		textDisplay.enabled = true;
		backgroundDisplay.enabled = true;
		textDisplay.text = name+" :\n"+toDisplay;
		AddToHistory(name,toDisplay);
	}

	public static void HideDisplay()
	{
		backgroundDisplay.enabled = false;
		textDisplay.enabled = false;
	}

	public static void ToggleHistory()
	{
//		historyDisplay.SetEnabled(!historyDisplay.enabledSelf);
	}

	public static void AddToHistory(string name, string text)
	{
		historyText.text = historyText.text.Insert(0, "[" + name + "] : " + text+"\n");
	}
}
