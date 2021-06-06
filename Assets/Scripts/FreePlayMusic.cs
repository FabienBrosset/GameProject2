using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FreePlayMusic : MonoBehaviour
{
    public AudioSource audioSrc;
    public MusicData musicData;
    public FreePhaseManager phaseManager;

    void Start()
    {
        Debug.Log("freeplaymusic :" + musicData.audioClipPath + ".wav");
        if (audioSrc == null) audioSrc = new AudioSource();
        StartCoroutine(LoadTrack(musicData.audioClipPath + ".wav"));
    }

    IEnumerator LoadTrack(string filename)
    {
        var www = new WWW(filename);

        while (www.progress < 0.2)
        {
            yield return new WaitForSeconds(0.1f);
        }

        AudioClip clip = www.GetAudioClip(false, true, AudioType.OGGVORBIS);
        audioSrc.clip = clip;
        phaseManager.CalculatePhaseChangingTime(audioSrc.clip.length);
        audioSrc.Play();
    }

    private void Update()
    {
    }
}
