using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//This class is a test file to load and play songs from the PersitentData folder
//////// DON'T DELETE IT ////////

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSrc;

    void Start()
    {
        if (audioSrc == null) audioSrc = new AudioSource();
        //StartCoroutine(LoadTrack(Path.Combine(Application.persistentDataPath + "/Songs/SpookyScarySkeleton/", "Spooky Scary Skeletons.wav")));
        audioSrc.clip = Resources.Load<AudioClip>("Musics/SpookyScarySkeleton/Spooky Scary Skeletons");
    }

    IEnumerator LoadTrack(string filename)
    {
        var www = new WWW(filename);

        while (www.progress < 0.2)
        {
            Debug.LogFormat("Progress loading {0}: {1}", filename, www.progress);
            yield return new WaitForSeconds(0.1f);
        }

        var clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
        audioSrc.clip = clip;
        Debug.Log("First time " + audioSrc.time);
        //audioSrc.Play();
    }

    void OnGUI() // deprecated, use ordinary .UI now available in Unity
    {
        if (GUI.Button(new Rect(0, 0, 100, 100), "Launch Music Test"))
        {
            audioSrc.Play();
        }
    }

    public void OnClick()
    {
        audioSrc.Play();
    }

    private void Update()
    {
        //Debug.Log("audio time : " + audioSrc.time);
    }
}
