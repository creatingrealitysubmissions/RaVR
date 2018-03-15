using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public GameObject[] audioSources; // array of sources for each type of sound
    public AudioClip[,] clips; // 2D array of audio clips. First param is type of sound; second is clip number.
    public AudioClip[] oneDClip; // 1 dimentional clip array to edit the 2d one in inspector
    public AudioClip[] sounds;
    public bool[] vocal;
    public bool[] vocalPlayed;
    public GameObject clock;
    public int mod;


	// Use this for initialization
	void Start () {
        vocalPlayed = new bool[audioSources.Length];
        int depth = (oneDClip.Length) / (audioSources.Length);
        clips = new AudioClip[audioSources.Length, depth];
        for (int i = 0; i < oneDClip.Length; i++)
            oneDClip[i] = sounds[(int)(Random.value * sounds.Length)];
        for (int x = 0; x < audioSources.Length; x++) {
            for (int y = 0; y < clips.GetLength(1); y++) {
                clips[x, y] = oneDClip[x*clips.GetLength(1) + y];
            }
        }
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].GetComponent<AudioSource>().Play();
        }
        for(int i = 0; i < audioSources.Length; i++)
            vocalPlayed[i] = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (clock.GetComponent<Timer>().timesRem[i+mod] <= 0)
            {
                if (!vocal[i] || !vocalPlayed[i])
                {
                    audioSources[i].GetComponent<AudioSource>().Play();
                    if (audioSources[i].GetComponent<AudioSource>().clip != null)
                        vocalPlayed[i] = true;
                }
                else {
                    vocalPlayed[i] = false;
                    audioSources[i].GetComponent<AudioSource>().clip = null;
                }
                if (audioSources[i].GetComponent<AudioSource>().clip != null)
                    clock.GetComponent<Timer>().timesRem[i + mod] = audioSources[i].GetComponent<AudioSource>().clip.length - 0.075;
                else
                    clock.GetComponent<Timer>().timesRem[i + mod] = 7.5;
            }
            else
            {
                clock.GetComponent<Timer>().timesRem[i + mod] -= Time.deltaTime;
            }
        }

    }

    // sets clip being played.
    public IEnumerator setClip(int source, int clip) {
        yield return new WaitUntil(() => clock.GetComponent<Timer>().timesRem[source + mod] <= 0);
        audioSources[source].GetComponent<AudioSource>().clip = clips[source, clip];
    }
    public void disable(int source, int clip)
    {
        audioSources[source].GetComponent<AudioSource>().clip = null;
    }
    public bool isRunning(int s) {
        return audioSources[s].GetComponent<AudioSource>().clip != null;
    }
}

