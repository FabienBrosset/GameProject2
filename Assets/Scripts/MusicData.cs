using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicData : MonoBehaviour
{
    public string musicDataPath;
    public string audioClipPath;
    public float BPM;

    void Awake()
    {
        if (musicDataPath == "")
            musicDataPath = PlayerPrefs.GetString("MusicPath");
        if (audioClipPath == "")
            audioClipPath = PlayerPrefs.GetString("AudioPath");
        if (BPM == 0f)
            BPM = PlayerPrefs.GetFloat("BPM");
    }
}
