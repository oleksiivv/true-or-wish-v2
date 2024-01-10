using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameInteraction : InterstitialVideo
{
    public GameObject chooseOption;

    public Text chosenOption;
    public Text category;

    public Text question;

    public QuestionsDisplay questionsManager;
    public WishesDisplay wishesManager;

    public ParticleSystem showEffect;

    public Animator chooseOptionPanel;

    public GameObject loadingPanel;

    public CurrentPlayerController currentPlayerController;

    public AdmobController admob;

    public static int showAddCnt=0;

    public bool isSimpleGame = false;

    void Start(){
        int levelId = PlayerPrefs.GetInt("CurrentLevel");

        string gameName = PlayerPrefs.GetString("SavedLevel#"+levelId.ToString());
        string players = PlayerPrefs.GetString("PlayersInSavedLevel#"+levelId.ToString());

        string categoryName = isSimpleGame 
            ? PlayerPrefs.GetString("CategoryInQuickLevel")
            : PlayerPrefs.GetString("CategoryInSavedLevel#"+levelId.ToString());

        List<string> playersList = new List<string>(players.Split(','));

        category.text=gameName + " - категорія " + categoryName.ToString();

        if(isSimpleGame){
            category.text = "Категорія " + categoryName.ToString();
        }

        questionsManager.Init(CategoryController.FromString(categoryName));
        wishesManager.Init(CategoryController.FromString(categoryName));

        currentPlayerController.Init(playersList, levelId);

        this.InitUnityAds();
        this.LoadAd();
    }

    public void nextPlayer(){
        question.text="";
        chooseOption.SetActive(true);

        chooseOptionPanel.SetBool("close",false);
        chooseOptionPanel.SetBool("open",true);

        currentPlayerController.HandleNext();

        if(showAddCnt%2==0){
            if(! admob.showIntersitionalAd()){
                this.ShowAd();
            }
        }
        showAddCnt++;
    }

    public void chooseTruth(){
        chosenOption.text="Правда";
        Invoke(nameof(displayQuestion),0.5f);

        chooseOptionPanel.SetBool("open",false);
        chooseOptionPanel.SetBool("close",true);

        showEffect.Play();
    }

    public void chooseWish(){
        chosenOption.text="Дія";
        Invoke(nameof(displayWish),0.5f);

        chooseOptionPanel.SetBool("open",false);
        chooseOptionPanel.SetBool("close",true);

        showEffect.Play();
    }


    public void displayQuestion(){
        question.gameObject.SetActive(true);
        question.text=questionsManager.getRandom();
    }

    public void displayWish(){
        question.gameObject.SetActive(true);
        question.text=wishesManager.getRandom();
    }

    public void openScene(int id){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }
}