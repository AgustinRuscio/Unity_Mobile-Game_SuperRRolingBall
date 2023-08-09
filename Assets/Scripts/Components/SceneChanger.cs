//--------------------------------------------
//          Agustin Ruscio & Merdeces Riego
//--------------------------------------------


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
        LevelLoader.nextLevel = _sceneName;
        SceneManager.LoadScene("LoadScene");
    }

    public void LoadScene(string sceneName)
    {
        LevelLoader.nextLevel = sceneName;
        SceneManager.LoadScene("LoadScene");
    }
}