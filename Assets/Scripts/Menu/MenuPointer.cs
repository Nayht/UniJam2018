using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPointer : MonoBehaviour {

	[SerializeField] Canvas mainCanvas;
	[SerializeField] Canvas controlCanvas;
	[SerializeField] List<GameObject> surbrilliances;

	int pointer = 2;
	bool isMainCanvas = true;

	// Use this for initialization
	void Start () {
		StartCoroutine (InputDetection());
		StartCoroutine (ConfirmDetection ());
		UpdateDisplay ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	//Contrôles clavier
	public void ChangeCanvasPointer () {
		isMainCanvas = !isMainCanvas;
		if (isMainCanvas) {
			Start ();
		} else {
			StartCoroutine (ControlScreen());
		}
	}

	IEnumerator InputDetection () {
		float input = Input.GetAxisRaw ("Vertical");
		bool pressed = false;
		while (isMainCanvas) {
			if (input == 0) {
				pressed = false;
			}
			if (input == 1) {
				if (!pressed) {
					PointerUp ();
					UpdateDisplay ();
				}
				pressed = true;
			}
			if (input == -1) {
				if (!pressed) {
					PointerDown ();
					UpdateDisplay ();
				}
				pressed = true;
			}
			yield return null;
			input = Input.GetAxisRaw ("Vertical");
		}
	}

	IEnumerator ConfirmDetection () {
		//En appuyant sur entrée, ça active le bouton sélectionné
		bool confirm = Input.GetKeyDown (KeyCode.KeypadEnter);
		while (isMainCanvas) {
			if (confirm) {
				if (pointer == 2) {
					StartGame ();
				}
				if (pointer == 0) {
					QuitGame ();
				}
				if (pointer == 1) {
					mainCanvas.GetComponent<CanvasChange> ().Change ();
					ChangeCanvasPointer ();
				}
			}
			yield return null;
			confirm = Input.GetKeyDown (KeyCode.Return);
		}
	}

	void PointerUp () {
		pointer++;
		if (pointer > 2) {
			pointer = 0;
		}
	}
	void PointerDown () {
		pointer--;
		if (pointer < 0) {
			pointer = 2;
		}
	}

	void UpdateDisplay() {
		Debug.Log (pointer);
		for (int i = 0; i < 3; i++) {
			if (pointer == i) {
				surbrilliances [i].SetActive (true);
			} else {
				surbrilliances [i].SetActive (false);
			}
		}
	}


	IEnumerator ControlScreen() {
		bool confirm = Input.GetKeyDown (KeyCode.KeypadEnter);
		while (!isMainCanvas) {
			if (confirm) {
				controlCanvas.GetComponent<CanvasChange> ().Change ();
				ChangeCanvasPointer();
			}
			yield return null;
			confirm = Input.GetKeyDown (KeyCode.Return);
		}
	}

	//Fonctions appelée par les boutons
	public void StartGame () {
		SceneManager.LoadScene ("level1");
	}


	public void QuitGame () {
		Application.Quit (); 
	}
}
