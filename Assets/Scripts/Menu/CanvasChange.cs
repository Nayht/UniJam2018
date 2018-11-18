using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChange : MonoBehaviour {

	[SerializeField] private Canvas OtherCanvas;


	public void Change () {
		OtherCanvas.gameObject.SetActive (true);
		this.gameObject.SetActive (false);
	}

}
