using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;
using static MapsInfo;

public class BeatmapCreation : MonoBehaviour
{
    public Fst_SongMap songMapping;
    public MusicData musicData;

    // Do the mapping of the music level
    void Awake()
    {
        TextAsset jsonTextfile = Resources.Load<TextAsset>(musicData.musicDataPath);
        MapsInfo mapReading = new MapsInfo();
        mapReading.InitLevelData(jsonTextfile.text);
        songMapping = mapReading.GetSongMapping();
    }
}
