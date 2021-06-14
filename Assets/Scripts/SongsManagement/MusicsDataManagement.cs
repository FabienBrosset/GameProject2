using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicsDataManagement : MonoBehaviour
{
    public GameObject selectMusic;
    public GameObject musicContent;
    public GameObject selectDifficulty;
    public GameObject difficultyContent;
    public GameObject selectedLevel;
    public GameObject launchGameButton;

    public MusicsInfo musicsInfo;

    private float BPM;
    private string folderPath;
    private string MusicPath;
    private string AudioPath;

    void Start()
    {
        RefreshData();
    }

    public void RefreshData()
    {
        string SongsPath = Application.persistentDataPath + "/Songs";
        if (!Directory.Exists(SongsPath))
        {
            Directory.CreateDirectory(SongsPath);
        }


        foreach (string dirPath in Directory.GetDirectories(SongsPath, "*", SearchOption.AllDirectories))
        {
            string deleteFile;

            var folder = Directory.CreateDirectory(dirPath.Replace("Assets/Resources/Musics", SongsPath));
            foreach (string file in Directory.GetFiles(dirPath, "*.dat", SearchOption.AllDirectories))
            {
                deleteFile = file;
                File.Copy(file, file.Replace(".dat", ".json"), true);
                File.Delete(deleteFile);
            }
            foreach (string file in Directory.GetFiles(dirPath, "*.egg", SearchOption.AllDirectories))
            {
                deleteFile = file;
                File.Copy(file, file.Replace(".egg", ".wav"), true);
                File.Delete(deleteFile);
            }
            foreach (string file in Directory.GetFiles(dirPath, "*.ogg", SearchOption.AllDirectories))
            {
                deleteFile = file;
                File.Copy(file, file.Replace(".ogg", ".wav"), true);
                File.Delete(deleteFile);
            }
        }
        FillDynamicList();
        Transform transform;
        for (int i = 0; i < difficultyContent.transform.childCount; i++)
        {
            transform = difficultyContent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }
    }

    public void FillDynamicList()
    {
        selectedLevel.SetActive(false);
        launchGameButton.SetActive(false);
        musicsInfo.refreshDataMusic();

        Transform transform;
        for (int i = 0; i < musicContent.transform.childCount; i++)
        {
            transform = musicContent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }

        float y = 50f;
        int contentSize = 0;
        for (int i = 0; i != musicsInfo.Musics.Count; i++)
        {
            y -= 60;
            contentSize += 1;

            GameObject myNewMusic = Instantiate(selectMusic, new Vector3(0, y, 0), Quaternion.identity);
            myNewMusic.transform.SetParent(musicContent.transform, false);

            byte[] pngBytes = System.IO.File.ReadAllBytes(Path.Combine(musicsInfo.Musics[i]._folderPath, musicsInfo.Musics[i]._coverImageFilename));
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(pngBytes);
            var newSprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), Vector2.one * 0.5f);

            Image[] images = myNewMusic.GetComponentsInChildren<Image>();
            images[1].sprite = newSprite;

            Text[] texts = myNewMusic.GetComponentsInChildren<Text>();
            texts[0].text = musicsInfo.Musics[i]._songName;
            texts[1].text = musicsInfo.Musics[i]._songAuthorName;

            myNewMusic.transform.GetComponent<Button>().onClick.AddListener(() => SelectMusic(texts[0].text, texts[1].text, images[1]));
        }
        musicContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 60 * contentSize);
    }

    private void SelectMusic(string songName, string authorName, Image cover)
    {
        Transform transform;
        for (int i = 0; i < difficultyContent.transform.childCount; i++)
        {
            transform = difficultyContent.transform.GetChild(i);
            GameObject.Destroy(transform.gameObject);
        }

        float y = 50f;
        int contentSize = 0;

        for (int i = 0; i < musicsInfo.Musics.Count; i++)
        {
            if (songName == musicsInfo.Musics[i]._songName)
            {
                foreach (MusicsInfo.DifficultyBeatmapsSets _dbs in musicsInfo.Musics[i]._difficultyBeatmapSets)
                    foreach (MusicsInfo.DifficultyBeatmap _db in _dbs._difficultyBeatmaps)
                    {
                        y -= 60;
                        contentSize += 1;
                        GameObject myNewDiff = Instantiate(selectDifficulty, new Vector3(0, y, 0), Quaternion.identity);
                        myNewDiff.transform.SetParent(difficultyContent.transform, false);
                        Text mytext = myNewDiff.GetComponentInChildren<Text>();
                        mytext.text = _db._difficulty + _dbs._beatmapCharacteristicName;
                        myNewDiff.transform.GetComponent<Button>().onClick.AddListener(() => SelectDifficulty(mytext.text, _db._beatmapFilename));
                    }
                folderPath = musicsInfo.Musics[i]._folderPath;
                AudioPath = Path.Combine(folderPath, musicsInfo.Musics[i]._songFilename.Replace(".egg", ""));
                BPM = musicsInfo.Musics[i]._beatsPerMinute;
            }
        }
        difficultyContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 60 * contentSize);

        Image[] images = selectedLevel.GetComponentsInChildren<Image>();
        images[1].sprite = cover.sprite;

        Text[] texts = selectedLevel.GetComponentsInChildren<Text>();
        texts[0].text = songName;
        texts[1].text = authorName;
        texts[2].text = "...";

        selectedLevel.SetActive(true);
        launchGameButton.SetActive(false);
    }

    private void SelectDifficulty(string difficultyName, string fileName)
    {
        Text[] texts = selectedLevel.GetComponentsInChildren<Text>();
        texts[2].text = difficultyName;

        MusicPath = Path.Combine(folderPath, fileName.Replace(".dat", ""));

        launchGameButton.SetActive(true);
    }

    public void LaunchLevel()
    {
        PlayerPrefs.SetString("MusicPath", MusicPath);
        PlayerPrefs.SetString("AudioPath", AudioPath);
        PlayerPrefs.SetFloat("BPM", BPM);
        Debug.Log(PlayerPrefs.GetString("MusicPath"));
        Debug.Log(PlayerPrefs.GetString("AudioPath"));
        Debug.Log(PlayerPrefs.GetFloat("BPM"));
        SceneManager.LoadScene("FreeModeFight", LoadSceneMode.Single);
    }
}
