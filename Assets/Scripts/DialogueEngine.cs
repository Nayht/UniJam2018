using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Ink.Runtime;

public class DialogueEngine : MonoBehaviour
{
	private Story story;
	
	[SerializeField]
	private string storyLocation;

	private TextAsset storyAsset;

	private List<string> currentTags;
	
	// Use this for initialization
	void Start ()
	{
		currentTags = new List<string>();
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
		
	}
	
	public void Progress()
	{
		if (story.canContinue)
		{
			GuiManager.Display(story.Continue());
		}
		else
		{
			foreach (string tag in currentTags)
			{
				Debug.Log(tag);
			}
			if (story.currentChoices.Count > 0)
			{
				ManageChoices();
			}
			else if(!currentTags.Contains("Ended"))
			{
				currentTags = currentTags.Union(story.currentTags).ToList();
				if (currentTags.Contains("GoodAge") && !currentTags.Contains("GoodAgeEnded"))
				{
					currentTags.Remove("Ended");
					story.ChoosePathString("GoodAge");
				}
				else
				{
					GuiManager.HideDisplay();
					InputManager.inDialogue = false;
				}

			}
			else
			{
				if (currentTags.Contains("GoodAge") && !currentTags.Contains("GoodAgeEnded"))
				{
					currentTags.Remove("Ended");
					story.ChoosePathString("GoodAge");
				}
				else
				{
					currentTags.Remove("Ended");
					story.ChoosePathString("OneLiner");
				}
			}
		}
	}

	public void GoodAgeProgress()
	{
		currentTags.Add("GoodAge");
		Progress();
	}

	private void ManageChoices()
	{
		foreach (var choice in story.currentChoices)
		{
			Debug.Log("Choix : "+choice.text);
		}

		story.ChooseChoiceIndex(0);
	}
}
