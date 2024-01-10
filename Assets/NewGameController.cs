using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameController : MonoBehaviour
{
    public List<string> gameNames;

    public List<string> userNames;

    public InputField gameNameInput;

    public InputField playerNameInputPrephab;

    public Slider numberOfPlayersSlider;
    
    public GameObject canvas;

    public List<Vector3> buttonPositions;

    public List<InputField> playerNames;

    private List<string> playerNamesValues;

    public Text numberOfPlayersLabel;

    public MenuController menu;

    private categories category = categories.all;

    public GameObject newGamePanel, categoryPanel;

    void Start(){
        playerNamesValues = new List<string>();

        NumberOfPlayersChange();
        gameNameInput.text = gameNames[Random.Range(0, gameNames.Count)];

        numberOfPlayersLabel.text = PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Number of players: <b>"+playerNames.Count.ToString()+"</b>"
            : "Кількість гравців: <b>"+playerNames.Count.ToString()+"</b>";
    }

    public void StartNewGame(){
        playerNamesValues.Clear();
        for(int i=0; i<playerNames.Count; i++){
            playerNamesValues.Add(playerNames[i].text);
        }

        int newLevelId = PlayerPrefs.GetInt("SavedLevelsNumber", -1) + 1;
        PlayerPrefs.SetInt("SavedLevelsNumber", newLevelId);

        PlayerPrefs.SetString("SavedLevel#"+newLevelId.ToString(), gameNameInput.text);

        var players = new Dictionary<string, int>();
        foreach(var name in playerNamesValues){
            players.Add(name, 0);
        }

        var preparedNames = new List<string>();
        foreach(var item in players){
            preparedNames.Add(item.Key);
        }
 
        PlayerPrefs.SetString("PlayersInSavedLevel#"+newLevelId.ToString(), string.Join(",", preparedNames));

        PlayerPrefs.SetString("CategoryInSavedLevel#"+newLevelId.ToString(), CategoryController.ToString(category));

        Debug.Log(PlayerPrefs.GetString("PlayersInSavedLevel#"+newLevelId.ToString()));

        menu.OpenGame(newLevelId);
    }

    public void NumberOfPlayersChange()
	{
        playerNamesValues.Clear();
        for(int i=0; i<playerNames.Count; i++){
            playerNamesValues.Add(playerNames[i].text);

            Destroy(playerNames[i].gameObject);
        }

        playerNames.Clear();

		for (int i=0; i<numberOfPlayersSlider.value; i++){
            var input = Instantiate(playerNameInputPrephab, playerNameInputPrephab.transform.position, playerNameInputPrephab.transform.rotation) as InputField;

            input.name = "Name#"+i.ToString();
            input.transform.parent = canvas.transform;
            //btn.transform.position = new Vector3(savedLevelButtonPrephab.transform.position.x, savedLevelButtonPrephab.transform.position.y - 130*(i+1), savedLevelButtonPrephab.transform.position.z);
            input.transform.GetChild(1).GetComponent<Text>().text = "Player#"+i.ToString();
            input.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);

            playerNames.Add(input);

            if (i<playerNamesValues.Count) {
                input.text = playerNamesValues[i];
            } else {
                input.text = "Гравець №"+(i+1).ToString();
            }
        }

        numberOfPlayersLabel.text = PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Number of players: <b>"+playerNames.Count.ToString()+"</b>"
            : "Кількість гравців: <b>"+playerNames.Count.ToString()+"</b>";
	}

    public void chooseCategoryChild(){
        category = categories.child;

        newGamePanel.SetActive(true);
        categoryPanel.SetActive(false);
    }

    public void chooseCategoryAdult(){
        category = categories.adult;

        newGamePanel.SetActive(true);
        categoryPanel.SetActive(false);
    }

    public void chooseCategoryInteresting(){
        category = categories.interesting;

        newGamePanel.SetActive(true);
        categoryPanel.SetActive(false);
    }

    public void chooseCategoryAll(){
        category = categories.all;

        newGamePanel.SetActive(true);
        categoryPanel.SetActive(false);
    }

    //

    public void chooseCategoryChildQuick(){
        category = categories.child;
        
        PlayerPrefs.SetString("CategoryInQuickLevel", CategoryController.ToString(category));
        menu.OpenSceneAsync(3);
    }

    public void chooseCategoryAdultQuick(){
        category = categories.adult;

        PlayerPrefs.SetString("CategoryInQuickLevel", CategoryController.ToString(category));
        menu.OpenSceneAsync(3);
    }

    public void chooseCategoryInterestingQuick(){
        category = categories.interesting;

        PlayerPrefs.SetString("CategoryInQuickLevel", CategoryController.ToString(category));
        menu.OpenSceneAsync(3);
    }

    public void chooseCategoryAllQuick(){
        category = categories.all;

        PlayerPrefs.SetString("CategoryInQuickLevel", CategoryController.ToString(category));
        menu.OpenSceneAsync(3);
    }
}
