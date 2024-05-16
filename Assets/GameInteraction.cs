using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.iOS;

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

    public int levelId;

    public GameObject internetError;

    public GameObject rateBox;

    private string currentCategoryName;

    public void Check()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetError.SetActive(true);
        }
        else{
            internetError.SetActive(false);
        }
    }

    void Start(){
        levelId = PlayerPrefs.GetInt("CurrentLevel");

        string gameName = PlayerPrefs.GetString("SavedLevel#"+levelId.ToString());
        string players = PlayerPrefs.GetString("PlayersInSavedLevel#"+levelId.ToString());

        string categoryName = isSimpleGame 
            ? PlayerPrefs.GetString("CategoryInQuickLevel")
            : PlayerPrefs.GetString("CategoryInSavedLevel#"+levelId.ToString());

        currentCategoryName = categoryName;

        List<string> playersList = new List<string>(players.Split(','));

        category.text=categoryName.ToString();//gameName + " - " + categoryName.ToString();

        if(isSimpleGame){
            category.text = categoryName.ToString();
        }

        questionsManager.Init(CategoryController.FromString(categoryName));
        wishesManager.Init(CategoryController.FromString(categoryName));

        currentPlayerController.Init(playersList, levelId);

        this.InitUnityAds();
        this.LoadAd();

        MenuLanguageController.Translate();

        Check();
    }

    public int round=0;

    public void nextPlayer(){
        question.text="";
        chooseOption.SetActive(true);

        chooseOptionPanel.SetBool("close",false);
        chooseOptionPanel.SetBool("open",true);

        currentPlayerController.HandleNext();

        if(showAddCnt%2==1){
            if(! admob.showIntersitionalAd()){
                this.ShowAd();
            }
        }
        showAddCnt++;

        Check();

        round++;

        if (round % 3 == 0 && PlayerPrefs.GetInt("IsReviewed", 0) == 0)
        {
            Debug.Log("Asking for review");
            var showedReviewPrompt = Device.RequestStoreReview();

            if(showedReviewPrompt)
            {
                PlayerPrefs.SetInt("IsReviewed", 1);
            }else
            {
                rateBox.SetActive(true);
                MenuLanguageController.Translate();
            }
        }
    }

    public void Rate()
    {
        Application.OpenURL("https://apps.apple.com/ua/app/tod-truth-or-dare/id1669586398");
        PlayerPrefs.SetInt("IsReviewed", 1);

        rateBox.SetActive(false);
    }

    public void RateLater()
    {
        rateBox.SetActive(false);
    }

    public void DontRate()
    {
        PlayerPrefs.SetInt("IsReviewed", 1);
        rateBox.SetActive(false);
    }

    public void chooseTruth(){
        if (PlayerPrefs.GetString("language", "ukr") == "ukr") {
            chosenOption.text="Правда";
        } else if (PlayerPrefs.GetString("language", "ukr") == "pol") {
            chosenOption.text="Prawda";
        } else {
            chosenOption.text="Truth";
        }

        Invoke(nameof(displayQuestion),0.5f);

        chooseOptionPanel.SetBool("open",false);
        chooseOptionPanel.SetBool("close",true);

        showEffect.Play();
    }

    public void chooseWish(){
        if (PlayerPrefs.GetString("language", "ukr") == "ukr") {
            chosenOption.text="Дія";
        } else if (PlayerPrefs.GetString("language", "ukr") == "pol") {
            chosenOption.text="Odważyć się";
        } else {
            chosenOption.text="Dare";
        }

        Invoke(nameof(displayWish),0.5f);

        chooseOptionPanel.SetBool("open",false);
        chooseOptionPanel.SetBool("close",true);

        showEffect.Play();
    }


    public static int questionIndex = 0;
    public void displayQuestion(){
        question.gameObject.SetActive(true);

        questionIndex++;
        if (PlayerPrefs.GetInt("AI_OFF", 0) == 0 && questionIndex % 2 == 0)
        {
            question.text="";
            questionsManager.getAIQuestion(currentCategoryName, question);
            return;
        }

        question.text=questionsManager.getRandom();
    }

    public static int wishIndex = 0;
    public void displayWish(){
        question.gameObject.SetActive(true);

        wishIndex++;
        if (PlayerPrefs.GetInt("AI_OFF", 0) == 0 && wishIndex % 2 == 0)
        {
            question.text="";
            wishesManager.getAIWish(currentCategoryName, question);
            return;
        }

        question.text=wishesManager.getRandom();
    }

    public void openScene(int id){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }
}