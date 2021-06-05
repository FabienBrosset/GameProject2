using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;


public class MusicsInfo : MonoBehaviour
{
	//Info.dat Json classes declaration
	//Contain information of all beatmaps for a songs
	[Serializable]
	public class DifficultyBeatmap
    {
		public string _difficulty;
		public int _difficultyRank;
		public string _beatmapFilename;
		public float _noteJumpMovementSpeed;
		public float _noteJumpStartBeatOffset;
    }

	//Contain an array of all beatmaps per set
	[Serializable]
	public class DifficultyBeatmapsSets
	{
		public string _beatmapCharacteristicName;
		public DifficultyBeatmap[] _difficultyBeatmaps;
	}

	//Contain global information of the music
	[Serializable]
	public class SongData
    {
		public string _version;
		public string _songName;
		public string _songAuthorName;
		public float _beatsPerMinute;
		public float _songTimeOffset;
		public string _songFilename;
		public string _coverImageFilename;
		public DifficultyBeatmapsSets[] _difficultyBeatmapSets;
		public string _folderPath;
    }

	public List<SongData> Musics;

	//Parse the global information of the song + add the folderPath
	void Start()
    {
	}

	public void refreshDataMusic()
    {
		string dataPath = Application.persistentDataPath + "/Songs";

		Musics.Clear();

		foreach (string dirPath in Directory.GetDirectories(dataPath, "*", SearchOption.AllDirectories))
		{
			string content = File.ReadAllText(Path.Combine(dirPath, "info.json"));
			SongData songdata = JsonUtility.FromJson<SongData>(content);
			songdata._folderPath = dirPath;
			Musics.Add(songdata);
		}
	}
}
