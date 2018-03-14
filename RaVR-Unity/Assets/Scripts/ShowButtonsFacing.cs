using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonsFacing : MonoBehaviour {

    public GameObject[] children;
    public GameObject cam;
    public int[] enable;

	// Use this for initialization
	void Start () {
        enable = new int[6];
        for (int i = 0; i < 6; i++)
            enable[i] = 0;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < children.Length; i++) {
            Vector3 start = cam.transform.position;
            Vector3 end = children[i].transform.position;
            Vector3 dir = new Vector3(transform.eulerAngles.x, Vector3.Angle(start, end), transform.eulerAngles.z);

            RaycastHit hit;
           Physics.Raycast(cam.transform.position, dir, out hit);
            if (hit.collider != null && hit.collider.gameObject == children[i])
                enable[i] = 1;

        }
        for (int i = 0; i < 6; i++) {
            if (enable[i] != 1)
                children[i].GetComponent<CubeButton>().enabled = false;
            else
                children[i].GetComponent<CubeButton>().enabled = true;
        }
	}
}
