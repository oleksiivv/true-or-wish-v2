using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsController : MonoBehaviour
{
    public List<Image> ukrLanguageOptions, engLanguageOptions;

    public Color32 normalColor, chosenColor;

    public MenuLanguageController menuLanguageController;

    public GameObject panel;

    public StudyController study;

    public TimerSettingssController timer;

    void Start(){
        SwitchLanguageOptions();

        //SetPanelVisibility(false);

        if (PlayerPrefs.GetInt("FirstLaunch", 0) == 0){
            SetPanelVisibility(true);

            PlayerPrefs.SetInt("FirstLaunch", 1);
        }
    }

    public void SetPanelVisibility(bool active){
        panel.SetActive(active);

        if (!active){
            if (PlayerPrefs.GetInt("studied", 0) == 0){
                study.SetPanelActive(true);
                PlayerPrefs.SetInt("studied", 1);
            }
        }
    }

    void SwitchLanguageOptions(){
        if (PlayerPrefs.GetString("language", "eng") == "eng") {
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

        menuLanguageController.Start();
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
