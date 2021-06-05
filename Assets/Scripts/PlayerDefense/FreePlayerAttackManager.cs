using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static MapsInfo;

public class FreePlayerAttackManager : MonoBehaviour
{

    public float speedValue = 3f;

    public GameObject keyNotePrefab;
    public float distanceInstantiate = 4f;

    public MusicData MusicData;
    private float timePerBeat = 0;

    public FreeBeatmapCreation beatmapCreation;

    private Fst_SongMap mappedSong;

    public AudioSource audio;

    private float lastTime = 0f;
    private float actualTime = 0;

    public bool justChangedPhase = false;
    public float changingPhaseTime = 0f;

    public FreePhaseManager phaseManager;

    void Start()
    {
        mappedSong = beatmapCreation.songMapping;

        timePerBeat = 60f / MusicData.BPM;

        lastTime = Time.deltaTime + 0.1f;
    }

    void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime < lastTime)
        {
            return;
        }

        if (mappedSong._notes.Length > phaseManager.noteCounter)
        {
            if (mappedSong._notes[phaseManager.noteCounter]._time <= (audio.time / timePerBeat))
            {
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
                //UnityEngine.Debug.Log("x " + mappedSong._notes[noteCounter]._lineIndex);

                if (mappedSong._notes[phaseManager.noteCounter]._lineIndex == 0)
                {
                    CreateKeyNote(new Vector2(distanceInstantiate, 0f), "left", speedValue);
                }
                else if (mappedSong._notes[phaseManager.noteCounter]._lineIndex == 1)
                {
                    CreateKeyNote(new Vector2(-distanceInstantiate, 0f), "right", speedValue);
                }
                else if (mappedSong._notes[phaseManager.noteCounter]._lineIndex == 2)
                {
                    CreateKeyNote(new Vector2(0f, -distanceInstantiate), "up", speedValue);
                }
                else if (mappedSong._notes[phaseManager.noteCounter]._lineIndex == 3)
                {
                    CreateKeyNote(new Vector2(0f, distanceInstantiate), "down", speedValue);
                }

                lastTime = actualTime + 0.2f;

                //UnityEngine.Debug.Log("y " + mappedSong._notes[noteCounter]._lineLayer);
                //UnityEngine.Debug.Log("Should pop at " + mappedSong._notes[noteCounter]._time + " Popekd at " + audio.time);
                //Instantiate(fireBallPrefab, new Vector2(randomX, 4), Quaternion.identity);
            }


        }
    }

    private void CreateKeyNote(Vector2 pos, string direction, float speed)
    {
        GameObject _key = Instantiate(keyNotePrefab, pos, new Quaternion());

        _key.GetComponent<KeyNoteScript>().direction = direction;
        _key.GetComponent<KeyNoteScript>().speed = speed;
    }
}
