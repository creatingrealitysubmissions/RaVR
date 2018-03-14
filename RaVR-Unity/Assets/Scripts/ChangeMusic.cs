using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour {

    public int src;
    public int clip;
    public GameObject manager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void change() {
        StartCoroutine(manager.GetComponent<AudioManager>().setClip(src, clip));
    }
}
