using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeButton : MonoBehaviour, IInputClickHandler {

    public int buttonNum; //sets which button this is
    public GameObject player;

    public void OnInputClicked(InputClickedEventData eventData)
    {
            if (player.GetComponent<AudioManager>().isRunning(buttonNum))
                player.GetComponent<AudioManager>().disable(buttonNum, 0);
            else
        StartCoroutine(player.GetComponent<AudioManager>().setClip(buttonNum, 0));
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
