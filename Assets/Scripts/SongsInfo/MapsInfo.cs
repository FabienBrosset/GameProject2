using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UIElements;

public class MapsInfo
{
	//<difficulty>.dat Json classes declaration
	//Contain all the notes informations
	[Serializable]
	public class Fst_Note
	{
		public float _time;
		public int _lineIndex;
		public int _lineLayer;
		public int _type;
		public int _cutDirection;
	}

	//Contain all the obstacles information
	[Serializable]
	public class Fst_Obstacles
	{
		public float _time;
		public int _lineIndex;
		public int _type;
		public int _duration;
		public int _width;
	}

	//Contain all the necessary informatios to do a beatmap
	[Serializable]
	public class Fst_SongMap
	{
		public string _version;
		public Fst_Note[] _notes;
		public Fst_Obstacles[] _obstacles;
	}

	public Fst_SongMap songMapping;




	//Parse all the usefull information to create a beatmap
	public void InitLevelData(string levelPath)
	{
		//		string content = File.ReadAllText(levelPath);
//		songMapping = JsonUtility.FromJson<Fst_SongMap>(content);
		songMapping = JsonUtility.FromJson<Fst_SongMap>(levelPath);
	}

	public Fst_SongMap GetSongMapping()
	{
		return songMapping;
	}
}