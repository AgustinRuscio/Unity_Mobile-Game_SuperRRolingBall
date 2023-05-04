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
    private string _nextLevel;

    public int _levelCoins;

    private bool _paused;


    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        EventManager.Subscribe(EventEnum.AddCoin, AddLocalCoin);


        _changer = new SceneChanger().SetSceneToChangeName(_nextLevel);
    }

    void Update()
    {
        if (_paused) return;

        if (_ball.DeathCondition())
        {
            //PonerCanvas de muerte
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
