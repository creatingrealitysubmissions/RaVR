using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public GameObject[] audioSources; // array of sources for each type of sound
    public AudioClip[,] clips; // 2D array of audio clips. First param is type of sound; second is clip number.
    public AudioClip[] oneDClip; // 1 dimentional clip array to edit the 2d one in inspector
    public double[] timesRem;

	// Use this for initialization
	void Start () {
        int depth = (oneDClip.Length) / (audioSources.Length);
        clips = new AudioClip[audioSources.Length, depth];
        for (int x = 0; x < audioSources.Length; x++) {
            for (int y = 0; y < clips.GetLength(1); y++) {
                clips[x, y] = oneDClip[x*clips.GetLength(1) + y];
            }
        }
        timesRem = new double[audioSources.Length];
        for (int i = 0; i < timesRem.Length; i++)
            timesRem[i] = 0;
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].GetComponent<AudioSource>().Play();
        }
        StartCoroutine(setClip(1, 0));
        StartCoroutine(setClip(0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (timesRem[i] <= 0)
            {
                audioSources[i].GetComponent<AudioSource>().Play();
                if (audioSources[i].GetComponent<AudioSource>().clip != null)
                    timesRem[i] = audioSources[i].GetComponent<AudioSource>().clip.length - 0.075;
                else
                    timesRem[i] = 7.5;
            }
            else
            {
                timesRem[i] -= Time.deltaTime;
            }
        }

    }

    // sets clip being played.
    public IEnumerator setClip(int source, int clip) {
        yield return new WaitUntil(() => timesRem[source] <= 0);
        audioSources[source].GetComponent<AudioSource>().clip = clips[source, clip];
    }
}

