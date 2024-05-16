using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    public GameObject savedGamesPanel;

    public GameObject newGamePanel;

    public GameObject categoryPanel, categoryForQuickGame;

    public GameObject settingsPanel;

    public GameObject internetConnectionError;

    void Start(){
        SetSavedGamesPanelVisibility(false);
        SetNewGamePanelVisibility(false);
    }

    public void SetSavedGamesPanelVisibility(bool visible){
        savedGamesPanel.SetActive(visible);
        MenuLanguageController.Translate();
    }

    public void SetNewGamePanelVisibility(bool visible){
        newGamePanel.SetActive(visible);
        MenuLanguageController.Translate();
    }

    public void SetCategoryPanelVisibility(bool visible){
        categoryPanel.SetActive(visible);
        MenuLanguageController.Translate();
    }

    public void SetCategoryForQuickGamePanelVisibility(bool visible){
        categoryForQuickGame.SetActive(visible);
        MenuLanguageController.Translate();
    }

    public void SetSettingsVisibility(bool visible){
        settingsPanel.SetActive(visible);
        MenuLanguageController.Translate();
    }

    public void OpenGame(int id){
        PlayerPrefs.SetInt("CurrentLevel", id);
        OpenSceneAsync(1);
    }

    public bool CheckInternetConnection()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetConnectionError.SetActive(true);

            return false;
        }
        else{
            internetConnectionError.SetActive(false);

            return true;
        }
    }

    public void RetryInternetConnection()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetConnectionError.SetActive(true);
        }
        else{
            internetConnectionError.SetActive(false);
        }
    }

    public void Rate(){
        Application.OpenURL("https://vertexstudio.herokuapp.com/");
    }
}
