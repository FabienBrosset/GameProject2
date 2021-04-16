using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class SetProjectSongsData : MonoBehaviour
{
    // Set the basics project songs to the persistent data file at the first launch of the game
    void Start()
    {
        // Check if the Song file is in the PersistentDataAlready
        string SongsPath = Application.persistentDataPath + "/Songs";
        if (!Directory.Exists(SongsPath)) {
            Directory.CreateDirectory(SongsPath);
        }
        // For each Musics Folder in assets will be copied inside the PersitentData in the Songs's folder (except the .meta files)
        foreach (string dirPath in Directory.GetDirectories("Assets/Resources/Musics", "*", SearchOption.AllDirectories))
        {
            var folder = Directory.CreateDirectory(dirPath.Replace("Assets/Resources/Musics", SongsPath));
            foreach (string file in Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories))
                File.Copy(file, file.Replace(dirPath, SongsPath + "/" + folder), true);
            foreach (string file in Directory.GetFiles(SongsPath + "/" + folder, "*.meta", SearchOption.AllDirectories))
                File.Delete(file);
        }
    }
}
