using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MoveCubeToPlayer : MonoBehaviour, IInputClickHandler
{

    public GameObject player; //set this by using hololens api
    private bool running = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float step;
        if (running)
        {
            step = (float)(2 * Time.deltaTime);
            if (Vector3.Distance(transform.position, player.transform.position) > 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            }
            else {
                running = false;
            }
        }
    }

    private void OnMouseDown()
    {
        running = true;
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        running = true;
    }
}
