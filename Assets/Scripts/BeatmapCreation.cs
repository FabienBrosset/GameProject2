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

    // Do the mapping of the music level
    void Start()
    {
        //string dataPath = Path.Combine(Application.persistentDataPath, "Songs");

        // Parse and stock all the values for the given level
        TextAsset jsonTextfile = Resources.Load<TextAsset>("Musics/SpookyScarySkeleton/HardStandard");
        MapsInfo mapReading = new MapsInfo();
        mapReading.InitLevelData(jsonTextfile.text);
        //mapReading.InitLevelData(Path.Combine(dataPath, "SpookyScarySkeleton/HardStandard.dat"));

        // Get back the stocked values to create the beatmap level
        songMapping = mapReading.GetSongMapping();

        // Here is the different values for each notes and obstacles

            //Debug.Log("Notes _time " + songMapping._notes[0]._time);  // Temps d'apparition
            //Debug.Log("Notes _lineIndex " + songMapping._notes[0]._lineIndex);  // Position en x
            //Debug.Log("Notes _lineLayer " + songMapping._notes[0]._lineLayer);  // Position en y
            //Debug.Log("Notes _type " + songMapping._notes[0]._type);  // Ne seras pas utile
            //Debug.Log("Notes _cutDirection " + songMapping._notes[0]._cutDirection);  // Peut être utilisé pour différencier les notes (éclair, boule de feu..)

            //// Je pense qu'on peut prendre les obstacles en compte également et en faire des notes. Ça peut augmenter le nombre mécaniques
            //Debug.Log("Obstacles _time " + songMapping._obstacles[0]._time);  // Temps d'apparition //
            //Debug.Log("Obstacles _lineIndex " + songMapping._obstacles[0]._lineIndex);  // Position en x
            //Debug.Log("Obstacles _type " + songMapping._obstacles[0]._type);  //  Type de l'obstacle
            //Debug.Log("Obstacles _duration " + songMapping._obstacles[0]._duration);  // Ne seras pas utile
            //Debug.Log("Obstacles _width " + songMapping._obstacles[0]._width);  // Taille de l'obstacle
            //Debug.Log("Version" + songMapping._version);
    }
}
