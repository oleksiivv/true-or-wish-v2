using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    public GameObject panel;

    public GameObject soundOn, soundOff;

    public AudioSource source;

    public List<AudioClip> clips;

    public bool isMainScene=false;

    //public HttpClient client;

    void Start(){
        ChooseClip();

        SwitchMusic();

        //Debug.Log("category: "+PlayerPrefs.GetInt("category", 0).ToString());

        if (PlayerPrefs.GetInt("category", -1) == -1) {
            PlayerPrefs.SetInt("category", 1);
        }
    }

    private void ChooseClip(){
        source.clip = clips[Random.Range(0, clips.Count)];
    }

    private void SwitchMusic(){
        source.enabled = (PlayerPrefs.GetInt("!music", 0) == 0);
        
        if(!isMainScene){
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }

        if (source.enabled){
            source.Play();

            if(!isMainScene){
                soundOn.SetActive(true);
                soundOff.SetActive(false);
            }
        }

        //Debug.Log(PlayerPrefs.GetInt("!music", 0));
    }

    public void SetPanelActive(bool active){
        panel.SetActive(active);
        MenuLanguageController.Translate();
    }

    public void MusicOn(){
        PlayerPrefs.SetInt("!music", 0);

        SwitchMusic();
    }

    public void MusicOff(){
        PlayerPrefs.SetInt("!music", 1);

        SwitchMusic();
    }

    public string GetCurrentCategory(){
        //Debug.Log(categoryDropdown.options[categoryDropdown.value].text.ToLower().Contains("popular") ? "popular": "all");
        return PlayerPrefs.GetInt("category", 0) == 0 ? "popular": "all";
    }
}
