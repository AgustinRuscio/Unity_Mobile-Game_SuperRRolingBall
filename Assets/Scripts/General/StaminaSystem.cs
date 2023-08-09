using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class StaminaSystem : MonoBehaviour
{
    public static StaminaSystem instance;

    private int _maxStamina = 6;
    private int _minstamina = 0;

    private int _stamina; //current

    private float _timeToRecharge = 30;

    [SerializeField]
    private TextMeshProUGUI _timerText;

    [SerializeField]
    private TextMeshProUGUI _staminaText;

    DateTime nextStaminaTime;
    DateTime lastStaminaTime;

    TimeSpan timer;

    public bool recharging = false;

    [SerializeField]
    private string _notifTitle = "Stamina maxima";

    [SerializeField]
    private string _notifText = "Full stamina, come and play!";

    private int _id;



    private void Awake()
    {
        _staminaText = GameObject.Find("Stamina Number").GetComponent<TextMeshProUGUI>(); 
        _timerText = GameObject.Find("Stamina Timer").GetComponent<TextMeshProUGUI>();
        
        if (instance == null)
        {
            instance = this;
            Load();
        }
        else
        {
            Destroy(this);
        }

       



    }

    private void Start()
    {

        if (!PlayerPrefs.HasKey("Stamina"))
        {
            PlayerPrefs.SetInt("Stamina", 6);
            Load();
            StartCoroutine(RechargeStamina());

        }
        else
        {
            Load();
            StartCoroutine(RechargeStamina());

        }

        if (_stamina < _maxStamina)//Noti
        {
            timer = nextStaminaTime - DateTime.Now;
            _id = NotificationManager.Instance.DisplayNotification(_notifTitle, _notifText, //Noti
                  AddDuration(DateTime.Now, ((_maxStamina - (_stamina) + 1) * _timeToRecharge) + 1 + (float)timer.TotalSeconds)); //Noti
            Debug.Log(_id + "if");
        }

    }


    public IEnumerator RechargeStamina()
    {
           
        UpdateTimer();
        UpdateStamina();

        recharging = true;

        while (_stamina < _maxStamina)
        {
            DateTime currentTime = DateTime.Now;
            DateTime nextTime = nextStaminaTime;

            bool staminaAdd = false;    

            while (currentTime > nextTime) 
            {
                if (_stamina < _maxStamina)
                {

                    staminaAdd = true;
                    _stamina++;
                    UpdateStamina();

                    DateTime timeToAdd = lastStaminaTime > nextTime ? lastStaminaTime : nextTime; // chequeamos si la last es mayor que la next y si es asi, usara la last sino usara la next.
                    nextTime = AddDuration(timeToAdd, _timeToRecharge);

                }
                else
                {
                    break;
                }                                            
 
            }

            if (staminaAdd == true)
            {
                lastStaminaTime = DateTime.Now;
                nextStaminaTime = nextTime;
            }

            UpdateTimer();
            UpdateStamina();
            Save();
            yield return null;
        }
        
        NotificationManager.Instance.CancelNotification(_id); //Noti
        recharging = false;
        

    }

    private DateTime AddDuration(DateTime timeToAdd, float duration)
    {
        return timeToAdd.AddSeconds(duration);
       // return timeToAdd.AddMinutes(duration); esto es para el juego real, segundos es para testeo.
    }


    public void UpdateStamina()
    {
        _staminaText.text = _stamina.ToString() + "/" + _maxStamina.ToString();
        
    }



    public void UpdateTimer()
    {
        if (_stamina >= _maxStamina)
        {
            _timerText.text = "Full";
            return;

        }

        timer = nextStaminaTime - DateTime.Now;
        string timeValue = string.Format("{0:D2}:{1:D1}", timer.Minutes, timer.Seconds);
        _timerText.text = timeValue;
    }


    void Save()
    {
        PlayerPrefs.SetInt("Stamina", _stamina);
        PlayerPrefs.SetString("nextStaminaTime", nextStaminaTime.ToString());
        PlayerPrefs.SetString("lastStaminaTime", lastStaminaTime.ToString());
    }

    void Load()
    {
        _stamina = PlayerPrefs.GetInt("Stamina");
        nextStaminaTime = StringToDateTime(PlayerPrefs.GetString("nextStaminaTime"));
        lastStaminaTime = StringToDateTime(PlayerPrefs.GetString("lastStaminaTime"));
    }

    DateTime StringToDateTime (string dateTime)
    {
        if (string.IsNullOrEmpty(dateTime))
        {
            return DateTime.UtcNow;
        }
        else
        {
            return DateTime.Parse(dateTime);
        }
       
    }


    public void UseEnergy()
    {
        if (_stamina >= 1)
        {
            _stamina--;
            UpdateStamina();

           NotificationManager.Instance.CancelNotification(_id); //Noti
           _id = NotificationManager.Instance.DisplayNotification(_notifTitle, _notifText, AddDuration(DateTime.Now, ((_maxStamina - (_stamina) + 1) * _timeToRecharge) + 1 + (float)timer.TotalSeconds));

            if (recharging == false)
            {
                if (_stamina +1 == _maxStamina) 
                {
                    nextStaminaTime = AddDuration(DateTime.Now, _timeToRecharge);
                    UpdateStamina();
                }
                StartCoroutine(RechargeStamina());
                Debug.Log("tenes " + _stamina + " actualmente");
                
            }

        }
        else
        {
            Debug.Log ("not enougth energy");
        }

    }
    bool n = true;
    public void AddStamina()
    {
        if (n)
        {
            n = false;  
            _stamina ++;
            Debug.Log(n);
        
      
            if (_stamina > _maxStamina || _stamina ==_maxStamina)
            {
                _stamina = _maxStamina;
                _timerText.text = "Full";
            }
            PlayerPrefs.SetInt(ConstantStrings.staminaKey, _stamina);
            UpdateStamina();
            Debug.Log(_stamina);
            StartCoroutine(ChargeStamina());
        }

    }


    public void DeveloperAddStamina()
    {
        _stamina++;
        if (_stamina > _maxStamina || _stamina == _maxStamina)
        {
            _stamina = _maxStamina;
            _timerText.text = "Full";
        }
        PlayerPrefs.SetInt(ConstantStrings.staminaKey, _stamina);
        UpdateStamina();
        Debug.Log(_stamina);
        StartCoroutine(ChargeStamina());

    }


    public void DeveloperRestStamina()
    {
        _stamina--;

        if (_stamina <= _minstamina)
        {
            _stamina = _minstamina;
                       
        }
        PlayerPrefs.SetInt(ConstantStrings.staminaKey, _stamina);
        UpdateStamina();

        Debug.Log(_stamina);
        StartCoroutine(ChargeStamina());
        UpdateTimer();
    }


    public float GetActualStamina()
    {
        return _stamina;
    }


    IEnumerator ChargeStamina()
    {

        yield return new WaitForSeconds(1);
        n = true;

    }
}
