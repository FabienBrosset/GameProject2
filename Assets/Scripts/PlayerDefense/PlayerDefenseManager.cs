using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using static MapsInfo;

public class PlayerDefenseManager : MonoBehaviour
{
    public List<GameObject> walls;
    public GameObject fireBallPrefab;
    public GameObject wallSpawner;

    private float BPMSpookyScarySkeletons = 110f;
    private float timePerBeat = 0;

    public BeatmapCreation beatmapCreation;

    private Fst_SongMap mappedSong;

    private int obstacleCounter = 0;
    public AudioSource _audio;
    public PhaseManager phaseManager;

    public Transform TopRightMax;
    public Transform BottomLeftMax;

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
        if (mappedSong._notes.Length > phaseManager.noteCounter)
        {
            if (mappedSong._notes[phaseManager.noteCounter]._time <= (_audio.time / timePerBeat))
            {
                float randomX = Random.Range(-6.5f, 7f);

                //UnityEngine.Debug.Log("x " + mappedSong._notes[phaseManager.noteCounter]._lineIndex);
                //UnityEngine.Debug.Log("y " + mappedSong._notes[phaseManager.noteCounter]._cutDirection);
                //UnityEngine.Debug.Log("Should pop at " + mappedSong._notes[noteCounter]._time + " Poped at " + audio.time);
                Instantiate(fireBallPrefab, new Vector2(randomX, 4), Quaternion.identity);
                phaseManager.noteCounter++;
            }
        }
        // spawn walls to dogde
        if (mappedSong._obstacles.Length > obstacleCounter)
        {
            if (mappedSong._obstacles[obstacleCounter]._time <= ( _audio.time / timePerBeat))
            {
                // wait at least one sec to pop another wall
                if (_audio.time - lastWallTime < 1f)
                {
                    obstacleCounter++;
                    return;
                }
                int rand = Random.Range(0, walls.Count);
                Instantiate(walls[rand], wallSpawner.transform.position, Quaternion.identity);
                lastWallTime = _audio.time;
                obstacleCounter++;
            }
        }
    }

    private float GetXPosition(int lineIndex, int cutDirection)
    {
        int position = lineIndex + cutDirection;
        return TopRightMax.position.x - (position * (Mathf.Abs(TopRightMax.position.x - BottomLeftMax.position.x) / 8) + 2.375f / 2f);
    }
}
