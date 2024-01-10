using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSettingssController : MonoBehaviour
{
    public GameObject timerOn, timerOff;

    public Text timerText, timerOnButtonText, timerOffButtonText;

    void Start(){
        SwitchTimer();
    }

    public void SwitchTimer(){
        timerOn.SetActive(false);
        timerOff.SetActive(true);

        timerText.text = PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Timer - 60 seconds"
            : "Таймер - 60 секунд";

        timerOnButtonText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Turn on" : "Ввімкнути";
        timerOffButtonText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Turn off" : "Вимкнути";

        if (PlayerPrefs.GetInt("timer", 0) == 0){
            timerOn.SetActive(true);
            timerOff.SetActive(false);

            timerText.text = PlayerPrefs.GetString("language", "eng") == "eng" 
                ? "Timer - off"
                : "Таймер - вимкнено";
        }

        Debug.Log(PlayerPrefs.GetInt("timer", 0));
    }

    public void TurnTimerOff(){
        PlayerPrefs.SetInt("timer", 0);

        SwitchTimer();
    }

    public void TurnTimerOn(){
        PlayerPrefs.SetInt("timer", 1);

        SwitchTimer();
    }
}
