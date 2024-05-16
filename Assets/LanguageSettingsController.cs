using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSettingsController : MonoBehaviour
{
    public List<Image> ukrLanguageOptions, engLanguageOptions, polLanguageOptions;

    public Color32 normalColor, chosenColor;


    public GameObject panel;

    public AIPanelController ai;

    //public StudyController study;

    //public TimerSettingssController timer;

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
        if (!active){
            if (PlayerPrefs.GetInt("studied", 0) == 0){
                //study.SetPanelActive(true);
                ai.SetActive(true);
                PlayerPrefs.SetInt("studied", 1);
            }
        }
        
        SwitchLanguageOptions();
    }

    void SwitchLanguageOptions(){
        if (PlayerPrefs.GetString("language", "ukr") == "eng") {
             SwitchLngColor(engLanguageOptions, chosenColor);

             SwitchLngColor(ukrLanguageOptions, normalColor);
             SwitchLngColor(polLanguageOptions, normalColor);
        }
        else if(PlayerPrefs.GetString("language", "ukr") == "pol") {
             SwitchLngColor(polLanguageOptions, chosenColor);

             SwitchLngColor(ukrLanguageOptions, normalColor);
             SwitchLngColor(engLanguageOptions, normalColor);
         }
         else {
            SwitchLngColor(ukrLanguageOptions, chosenColor);

            SwitchLngColor(polLanguageOptions, normalColor);
            SwitchLngColor(engLanguageOptions, normalColor);
        }

        MenuLanguageController.Translate();
        //timer.SwitchTimer();
    }

    void SwitchLngColor(List<Image> options, Color32 color){
        foreach(var option in options){
               option.GetComponent<Image>().color = color;
        }
    }

    public void ChoseUkr(){
        PlayerPrefs.SetString("language", "ukr");

        SwitchLanguageOptions();
    }

    public void ChoseEng(){
        PlayerPrefs.SetString("language", "eng");

        SwitchLanguageOptions();
    }

    public void ChosePolish(){
        PlayerPrefs.SetString("language", "pol");

        SwitchLanguageOptions();
    }
}
