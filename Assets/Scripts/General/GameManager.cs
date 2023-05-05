using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] 
    private BallStates _ball;

    private SceneChanger _changer;

    [SerializeField]
    private Transform _initialBallPos;

    [SerializeField]
    private string _nextLevel;

    public int _levelCoins;

    private int _currentSkin;

    private bool _paused;

    private string _levelName;

    [SerializeField]
    private GameObject[] _skinsList = new GameObject[8];

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        EventManager.Subscribe(EventEnum.AddCoin, AddLocalCoin);

        
        _levelName = SceneManager.GetActiveScene().name;

        _changer = new SceneChanger().SetSceneToChangeName(_nextLevel);

        
        _currentSkin = PlayerPrefs.GetInt(ConstantStrings.currentSkin);

        Debug.Log(_currentSkin);

        if (_levelName != "Tutorial")
            Instantiate(_skinsList[_currentSkin], _initialBallPos.position, _initialBallPos.rotation);

        _ball = FindObjectOfType<BallStates>();
    }

    void Update()
    {
        if (_paused) return;

        if (_ball.DeathCondition())
        {
            //PonerCanvas de muerte
            SceneManager.LoadScene(_levelName);
        }
    }

      
    public void OnLevelEndWin()
    {
        GameData.instance.AddCoinsToGeneral(_levelCoins);

        ChangeScene();
    }

    private void AddLocalCoin(params object[] coins)
    {
        _levelCoins += (int)coins[0];
        Debug.Log("Add coins");
    }

    public void SetGamePaused(bool ispaused) => _paused = ispaused;
    

    private void ChangeScene()
    {
        _changer.LoadScene();
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(EventEnum.AddCoin, AddLocalCoin);
    }


}
