using System.Collections;
using System.Collections.Generic;
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
		Progress();
	}

	void UpdateGUI(string dialogueOutput)
	{
		
	}
	
	void Progress()
	{
		if (story.canContinue)
		{
			Debug.Log(story.Continue());
		}
		else
		{
			if (story.currentChoices.Count > 0)
			{
				manageChoices();
			}
		}
	}

	void manageChoices()
	{
		for (int i = 0; i < story.currentChoices.Count; i++)
		{
			Choice choice = story.currentChoices[i];
			Debug.Log("Choix : "+choice.text);
		}
		story.ChooseChoiceIndex(0);
	}
}
