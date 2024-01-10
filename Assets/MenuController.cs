using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : BaseController
{
    public GameObject savedGamesPanel;

    public GameObject newGamePanel;

    public GameObject categoryPanel, categoryForQuickGame;

    public GameObject settingsPanel;

    void Start(){
        SetSavedGamesPanelVisibility(false);
        SetNewGamePanelVisibility(false);
    }

    public void SetSavedGamesPanelVisibility(bool visible){
        savedGamesPanel.SetActive(visible);
    }

    public void SetNewGamePanelVisibility(bool visible){
        newGamePanel.SetActive(visible);
    }

    public void SetCategoryPanelVisibility(bool visible){
        categoryPanel.SetActive(visible);
    }

    public void SetCategoryForQuickGamePanelVisibility(bool visible){
        categoryForQuickGame.SetActive(visible);
    }

    public void SetSettingsVisibility(bool visible){
        settingsPanel.SetActive(visible);
    }

    public void OpenGame(int id){
        PlayerPrefs.SetInt("CurrentLevel", id);
        OpenSceneAsync(1);
    }

    public void Rate(){
        Application.OpenURL("https://vertexstudio.herokuapp.com/");
    }
}
