using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Ink.Runtime;

public class DialogueEngine : MonoBehaviour
{

	private Story story;
	
	[SerializeField]
	private string storyLocation;

	[SerializeField]
	private TextAsset storyAsset;
	
	// Use this for initialization
	void Start ()
	{
		if (string.IsNullOrEmpty(storyLocation))
		{
			storyLocation = "Dialogues/New_Ink";
		}

		storyAsset = Resources.Load(storyLocation) as TextAsset;
		story = new Story(storyAsset.text);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Thread.Sleep(2000);
		Progress();
	}

	private void UpdateGUI(string dialogueOutput)
	{
		
	}
	
	public void Progress()
	{
		if (story.canContinue)
		{
			GuiManager.Display(story.Continue());
		}
		else
		{
			if (story.currentChoices.Count > 0)
			{
				manageChoices();
			}
			else
			{
				GuiManager.HideDisplay();
			}
		}
	}

	private void manageChoices()
	{
		foreach (var choice in story.currentChoices)
		{
			Debug.Log("Choix : "+choice.text);
		}

		story.ChooseChoiceIndex(0);
	}
}
