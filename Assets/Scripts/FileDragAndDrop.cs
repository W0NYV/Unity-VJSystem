using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System.Linq;
using B83.Win32;


public class FileDragAndDrop : MonoBehaviour
{
    //List<string> log = new List<string>();

    public GameObject videoPlayer;
    void OnEnable ()
    {
        // must be installed on the main thread to get the right thread id.
        UnityDragAndDropHook.InstallHook();
        UnityDragAndDropHook.OnDroppedFiles += OnFiles;
    }
    void OnDisable()
    {
        UnityDragAndDropHook.UninstallHook();
    }

    void OnFiles(List<string> aFiles, POINT aPos)
    {
        // do something with the dropped file names. aPos will contain the 
        // mouse position within the window where the files has been dropped.

        string URL = aFiles.Aggregate((a, b) => a + "\n\t" + b);

        string str = "Dropped " + aFiles.Count + " files at: " + aPos + "\n\t" + URL;
        
        Debug.Log(str);
        
        //log.Add(str);

        videoPlayer.GetComponent<VideoPlayer>().url = "file:///" + URL;
    }

    // private void OnGUI()
    // {
    //     if (GUILayout.Button("clear log"))
    //         log.Clear();
    //     foreach (var s in log)
    //         GUILayout.Label(s);
    // }
}