using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Question> questions;

    public QuestionsFillController questionsFillController;

    public static int current=0;

    private Question currentQuestion;

    public Text question;

    public Text optionOne, optionTwo;

    public CurrentPlayerController currentPlayerController;

    public Text playerNameAndScorePrephab;

    private bool inAdminMode=false;

    public List<Text> playersText;

    public GameObject playersCanvas;

    public GameObject winPanel;

    public Text winText;

    //public AdmobController admob;

    public bool isSimpleGame=false;

    void Start(){
        int levelId = PlayerPrefs.GetInt("CurrentLevel");

        string gameName = PlayerPrefs.GetString("SavedLevel#"+levelId.ToString());
        string players = PlayerPrefs.GetString("PlayersInSavedLevel#"+levelId.ToString());

        string category = isSimpleGame 
            ? PlayerPrefs.GetString("CategoryInQuickLevel")
            : PlayerPrefs.GetString("CategoryInSavedLevel#"+levelId.ToString());

        List<string> playersList = new List<string>(players.Split(','));

        inAdminMode=false;
        foreach(var player in playersList){
            if(player.ToUpper().Contains("ES02JV")){
                inAdminMode=true;
            }
        }

        UpdatePlayersView(playersList);

        currentPlayerController.Init(playersList, levelId);
        
        questions = questionsFillController.Questions(category);

        winPanel.SetActive(false);

        currentQuestion = questions[current];
        
        current++;
        if(current>=questions.Count){
            current=0;
        }

        UpdateUI();
    }

    public void Next()
    {
        winPanel.SetActive(false);

        currentQuestion = questions[current];
        
        current++;
        if(current>=questions.Count){
            current=0;
        }

        UpdateUI();
        currentPlayerController.HandleNext();

        //admob.showIntersitionalAd();
    }

    private void UpdateUI(){
        question.text = currentQuestion.question;

        optionOne.text = currentQuestion.option_1;
        optionTwo.text = currentQuestion.option_2;
    }

    public void OnChoose(int option){
        winText.text = "Гравцеь " + currentPlayerController.GetCurrent().Split(':')[0] + " у питанні \""+currentQuestion.question+"\" вибрав варіант " + option.ToString();
        winPanel.SetActive(true);
    }

    public void UpdatePlayersView(List<string> playersList){
        for(int i=0; i<playersText.Count; i++){
            Destroy(playersText[i].gameObject);
        }

        playersText.Clear();

        foreach(var item in playersList){
            string name = item;

            var text = Instantiate(playerNameAndScorePrephab, playerNameAndScorePrephab.transform.position, playerNameAndScorePrephab.transform.rotation) as Text;

            text.name = "Player#"+name;
            text.text = name;
            text.transform.parent = playersCanvas.transform;

            text.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(120, 20);
            //btn.transform.position = new Vector3(savedLevelButtonPrephab.transform.position.x, savedLevelButtonPrephab.transform.position.y - 130*(i+1), savedLevelButtonPrephab.transform.position.z);

            text.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            playersText.Add(text);

            //playersScore.Add(name, score);
        }
    }
}
