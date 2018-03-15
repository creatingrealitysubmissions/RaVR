using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public double[] timesRem = new double[20];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < timesRem.Length; i++)
            timesRem[i] = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
