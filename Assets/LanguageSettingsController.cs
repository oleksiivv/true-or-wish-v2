using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsController : MonoBehaviour
{
    public List<Image> ukrLanguageOptions, engLanguageOptions;

    public Color32 normalColor, chosenColor;


    public GameObject panel;

    //public StudyController study;

    public TimerSettingssController timer;

    void Start(){
        //SetPanelVisibility(false);

        if (PlayerPrefs.GetInt("FirstLaunch", 0) == 0){
            SetPanelVisibility(true);
            SwitchLanguageOptions();

            PlayerPrefs.SetInt("FirstLaunch", 1);
        }

        SwitchLanguageOptions();
    }

    public void SetPanelVisibility(bool active){
        panel.SetActive(active);
        SwitchLanguageOptions();

        if (!active){
            if (PlayerPrefs.GetInt("studied", 0) == 0){
                //study.SetPanelActive(true);
                PlayerPrefs.SetInt("studied", 1);
            }
        }
    }

    void SwitchLanguageOptions(){
        if (PlayerPrefs.GetString("language", "ukr") == "eng") {
            foreach(var urkLangOption in ukrLanguageOptions){
                urkLangOption.GetComponent<Image>().color = normalColor;
            }

            foreach(var engLangOption in engLanguageOptions){
                engLangOption.GetComponent<Image>().color = chosenColor;
            }
        } else {
            foreach(var urkLangOption in ukrLanguageOptions){
                urkLangOption.GetComponent<Image>().color = chosenColor;
            }

            foreach(var engLangOption in engLanguageOptions){
                engLangOption.GetComponent<Image>().color = normalColor;
            }
        }

        MenuLanguageController.Translate();
        timer.SwitchTimer();
    }

    public void ChoseUkr(){
        PlayerPrefs.SetString("language", "ukr");

        SwitchLanguageOptions();
    }

    public void ChoseEng(){
        PlayerPrefs.SetString("language", "eng");

        SwitchLanguageOptions();
    }
}
