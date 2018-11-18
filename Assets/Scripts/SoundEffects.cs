using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Play(string s)
    {
        GameObject son = GameObject.Find("son_" + s);
        if(son==null)
        {
            son = GameObject.Find(s);
        }
        if(son !=  null)
        {
            son.GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("Son non trouvé !");
        }
    }
}
