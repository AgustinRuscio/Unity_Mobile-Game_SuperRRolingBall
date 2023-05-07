using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger
{
    [SerializeField] 
    private string _sceneName;

    public SceneChanger SetSceneToChangeName(string lvlName)
    {
        _sceneName = lvlName;
        return this;
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}