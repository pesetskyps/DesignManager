using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class LoadSceneOnClick
{

    public static void LoadScene(string level)
    {
        var currentScene = Application.loadedLevelName;
        var scenes = EditorBuildSettings.scenes;
        List<string> avaliableScenes = new List<string>();
        foreach (var scene in scenes)
        {
            var path = scene.path;
            var f = path.LastIndexOf("/");
            var l = path.IndexOf(".unity");
            string[] tempsceneName = path.Split('/');
            if (tempsceneName.Length != 0)
                avaliableScenes.Add(tempsceneName[tempsceneName.Length - 1].Split('.')[0]);
        }

        if (level != currentScene && avaliableScenes.Contains(level))
        { Application.LoadLevel(level); }
        else
        {
            Debug.Log("No scene found or build settings not correct");
        }
        //loadingImage.SetActive(true);

    }
}
