using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Ink.Runtime;

public class DialogueEngine : MonoBehaviour
{
	private Story story;
	private Character character;
	
	[SerializeField]
	private string storyLocation;

	private TextAsset storyAsset;

	private List<string> currentTags;

    private InputManager inputManager;
	// Use this for initialization
	void Start ()
	{
		character = GetComponent<Character>();
        inputManager = GetComponent<InputManager>();

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
			GuiManager.Display(character.name,story.Continue());
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
                    inputManager.ownDialogue = false;
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
	}

	private void ManageChoices()
	{
        GuiManager.Display("Vous", story.currentChoices[0].text);

		story.ChooseChoiceIndex(0);
	}
}
