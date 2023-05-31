using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private BallStates _ball;

    [SerializeField]
    private CoreCanvas _coreCanvas;

    [SerializeField]
    private GameObject[] _skinsList = new GameObject[8];

    private SceneChanger _changer;

    [SerializeField]
    private Transform _initialBallPos;

    [SerializeField]
    private GameObject _loseCanvas;

    [SerializeField]
    private string _nextLevel;

    private int _levelCoins;

    private int _currentSkin;

    private bool _paused;

    private string _levelName;
    

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        EventManager.Subscribe(EventEnum.AddCoin, AddLocalCoin);

        
        _levelName = SceneManager.GetActiveScene().name;

        _changer = new SceneChanger().SetSceneToChangeName(_nextLevel);

        
        _currentSkin = PlayerPrefs.GetInt(ConstantStrings.currentSkin);

        if (_levelName != "Tutorial")
            Instantiate(_skinsList[_currentSkin], _initialBallPos.position, _initialBallPos.rotation);

        _ball = FindObjectOfType<BallStates>();
    }

    void Update()
    {
        if (_paused) return;

        if (_ball.DeathCondition())
            _loseCanvas.SetActive(true);
    }

      
    public void OnLevelEndWin()
    {
        GameData.instance.AddCoinsToGeneral(_levelCoins);

        ChangeScene();
    }

    private void AddLocalCoin(params object[] coins)
    {
        _levelCoins += (int)coins[0];
        _coreCanvas.UpdateCanvas(_levelCoins);
    }

    public int GetLevelCoins()
    {
        return _levelCoins;
    }

    public void SetGamePaused(bool ispaused) => _paused = ispaused;
    

    private void ChangeScene() => _changer.LoadScene();
    

    private void OnDestroy() => EventManager.Unsubscribe(EventEnum.AddCoin, AddLocalCoin);
}