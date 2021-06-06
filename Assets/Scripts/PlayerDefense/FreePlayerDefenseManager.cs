using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

using static MapsInfo;

public class FreePlayerDefenseManager : MonoBehaviour
{
    public List<GameObject> walls;
    public GameObject wallSpawner;
    
    public GameObject fireBallPrefab;
    private float noteWidth = 1f;

    public MusicData musicData;
    private float timePerBeat = 0;

    public FreeBeatmapCreation beatmapCreation;

    private Fst_SongMap mappedSong;

    private int obstacleCounter = 0;
    public AudioSource _audio;
    public FreePhaseManager phaseManager;

    public Transform TopRightMax;
    public Transform BottomLeftMax;

    public bool justChangedPhase = false;
    public float changingPhaseTime = 0f;
    private float lastNotePosition = 0f;

    private float lastWallTime = 0f;

    public GameObject warningPrefab;
    public Transform transformWarningSpawn;
    private float warningLifeTime = 0.5f;

    void Start()
    {
        noteWidth = fireBallPrefab.GetComponent<Renderer>().bounds.size.x;

        mappedSong = beatmapCreation.songMapping;

        timePerBeat = 60f / musicData.BPM;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn fireball
        if (mappedSong._notes.Length > phaseManager.noteCounter)
        {
            if (mappedSong._notes[phaseManager.noteCounter]._time <= (_audio.time / timePerBeat))
            {
                float leftLimit = -6f;
                float rightLimit = 7f;
                float randomX = Random.Range(leftLimit, rightLimit);

                float margin = 0.5f;
                // if this note want to spawn at the same place or 0.5f (the margin) on each side as the last one, make it spawn somewhere else
                if (randomX >= lastNotePosition - noteWidth - margin && randomX <= lastNotePosition + margin)
                {
                    float leftDiff = Mathf.Abs(leftLimit - randomX);
                    float rightDiff = rightLimit - randomX;

                    // note is more on the right, so shift it to the left
                    if (rightDiff < leftDiff)
                    {
                        randomX -= noteWidth + Random.Range(0f, 3f);
                    }
                    else // note is more on the left, so shift it to the right
                    {
                        randomX += noteWidth + Random.Range(0f, 3f);
                    }
                }

                phaseManager.noteCounter++;

                // don't spawn notes the two first second after chaging phase
                if (justChangedPhase == true && Time.time - changingPhaseTime <= 1f)
                {
                    return;
                }
                else if (justChangedPhase == true)
                {
                    justChangedPhase = false;
                }
                lastNotePosition = randomX;
                StartCoroutine(InstanciateNote(randomX));
            }
        }
//        spawn walls to dogde
        if (mappedSong._obstacles.Length > obstacleCounter)
        {
            if (mappedSong._obstacles[obstacleCounter]._time <= (_audio.time / timePerBeat))
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

    IEnumerator InstanciateNote(float randomX)
    {
        Instantiate(warningPrefab, new Vector2(randomX, transformWarningSpawn.position.y), Quaternion.identity);

        yield return new WaitForSeconds(warningLifeTime);

        Instantiate(fireBallPrefab, new Vector2(randomX, 5f), Quaternion.identity);
    }
}
