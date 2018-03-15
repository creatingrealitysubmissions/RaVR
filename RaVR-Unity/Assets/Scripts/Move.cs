using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private float speed = 2;
    private float mod = 0.01F;
    float mover;
    float timer = 5;
    float initTime;
    Vector3 rotMod;
    


    // Use this for initialization
    void Start () {
        mover = Random.value * 1 - 0.5F;
        initTime = timer;
        rotMod = new Vector3(Random.value * 4 - 2, Random.value * 4 - 2, Random.value * 4 - 2);
    }
	
	// Update is called once per frame
	void Update () {
        if (timer <= 0)
            Destroy(gameObject);
        timer -= Time.deltaTime;
        float step = speed * Time.deltaTime;
        transform.Rotate(rotMod);
        transform.SetPositionAndRotation(new Vector3(transform.position.x + mover*0.1F, transform.position.y, transform.position.z+step), transform.rotation);
    }
}
