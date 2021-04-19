using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using static MapsInfo;

public class EnemyAttackManager : MonoBehaviour
{
    public List<GameObject> walls;
    public GameObject fireBallPrefab;
    public GameObject wallSpawner;

    private float BPMSpookyScarySkeletons = 128f;
    private float timePerBeat = 0;

    public BeatmapCreation beatmapCreation;

    private Fst_SongMap mappedSong;

    private int obstacleCounter = 0;
    private int noteCounter = 0;
    public AudioSource audio;

    private float lastWallTime = 0f;

    void Start()
    {
        mappedSong = beatmapCreation.songMapping;

        timePerBeat = 60f / BPMSpookyScarySkeletons;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn fireball
        if (mappedSong._notes.Length > noteCounter)
        {
            if (mappedSong._notes[noteCounter]._time <= (audio.time / timePerBeat))
            {
                float randomX = Random.Range(-6.5f, 7f);

                //UnityEngine.Debug.Log("x " + mappedSong._notes[noteCounter]._lineIndex);
                //UnityEngine.Debug.Log("y " + mappedSong._notes[noteCounter]._lineLayer);
                //UnityEngine.Debug.Log("Should pop at " + mappedSong._notes[noteCounter]._time + " Popekd at " + audio.time);
                Instantiate(fireBallPrefab, new Vector2(randomX, 4), Quaternion.identity);
                noteCounter++;
            }

        }
        // spawn walls to dogde
        if (mappedSong._obstacles.Length > obstacleCounter)
        {
            if (mappedSong._obstacles[obstacleCounter]._time <= ( audio.time / timePerBeat))
            {
                // wait at least one sec to pop another wall
                if (audio.time - lastWallTime < 1f)
                {
                    obstacleCounter++;
                    return;
                }
                int rand = Random.Range(0, walls.Count);
                Instantiate(walls[rand], wallSpawner.transform.position, Quaternion.identity);
                lastWallTime = audio.time;
                obstacleCounter++;
            }
        }
    }
}
