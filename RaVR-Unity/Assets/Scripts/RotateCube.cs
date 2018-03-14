using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube : MonoBehaviour {

    public int step = 1;
    public bool dir = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(dir)
            transform.Rotate(new Vector3(-step,-step,step));
        else
            transform.Rotate(new Vector3(step, step, -step));
    }
}
