using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emmiter : MonoBehaviour {
    public float rate;
    private float rateInit;

    public int number;

    public GameObject cube;

	// Use this for initialization
	void Start () {
        rateInit = rate;
	}

    // Update is called once per frame
    void Update() {
        if (rate <= 0) {
            for(int i = (int)(Random.value*number); i < number; i++)
            {
                Instantiate(cube);
            }
            rate = rateInit;
        }
        rate -= Time.deltaTime;
	}
}
