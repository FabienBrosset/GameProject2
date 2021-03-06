using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

//This class is a test file to load and play songs from the PersitentData folder
//////// DON'T DELETE IT ////////

public class PlayMusic : MonoBehaviour
{
    public AudioSource audioSrc;
    public MusicData musicData;
    public PhaseManager phaseManager;

    private bool startMusic;

    void Start()
    {
        if (audioSrc == null) audioSrc = new AudioSource();

        AudioClip audioClip = Resources.Load<AudioClip>(musicData.audioClipPath);
        audioSrc.clip = audioClip;
        phaseManager.CalculatePhaseChangingTime(audioClip.length);
        startMusic = false;
        StartCoroutine(StartMusic());
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

    private void Update()
    {
        if (!audioSrc.isPlaying && startMusic)
        {
            PlayerPrefs.SetInt("player_score", -1);
            SceneManager.LoadScene("LoseScene");
        }
    }

    //void OnGUI() // deprecated, use ordinary .UI now available in Unity
    //{
    //    if (GUI.Button(new Rect(0, 0, 100, 100), "Launch Music Test"))
    //    {
    //        audioSrc.Play();
    //    }
    //}

    public IEnumerator StartMusic()
    {
        yield return new WaitForSeconds(1f);
        if (audioSrc.clip == null)
        {
            Debug.LogError("There is no music to play in audio.clip");
        }
        audioSrc.Play();
        startMusic = true;
    }
}
