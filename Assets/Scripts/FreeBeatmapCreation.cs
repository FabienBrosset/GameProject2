using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;
using static MapsInfo;

public class FreeBeatmapCreation : MonoBehaviour
{
    public Fst_SongMap songMapping;
    public MusicData musicData;

    // Do the mapping of the music level
    void Awake()
    {
        Debug.Log("freebtp :" + musicData.musicDataPath + ".json");
        string content = File.ReadAllText(musicData.musicDataPath + ".json");
        MapsInfo mapReading = new MapsInfo();
        mapReading.InitLevelData(content);
        songMapping = mapReading.GetSongMapping();
    }
}
