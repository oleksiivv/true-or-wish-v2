using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentPlayerController : MonoBehaviour
{
    private List<string> players;

    private int currentIndex = 0;

    public Text currentPlayerText;

    private int levelId;

    public bool isSimpleGame = false;

    public void Init(List<string> players1, int levelId1)
    {
        if (isSimpleGame){
            currentPlayerText.text = "";
            return;
        }

        players = players1;

        levelId = levelId1;

        currentIndex = PlayerPrefs.GetInt("CurrentpPlayerInGame#"+levelId.ToString(), 0);

        currentPlayerText.text = true//PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Зараз: "+players[currentIndex].Split(':')[0]// + "'s turn"
            : /*"Черга "+*/players[currentIndex].Split(':')[0];
    }

    public void HandleNext(){
        if (isSimpleGame){
            currentPlayerText.text = "";
            return;
        }

        currentIndex++;

        if (currentIndex>=players.Count){
            currentIndex=0;
        }

        PlayerPrefs.SetInt("CurrentpPlayerInGame#"+levelId.ToString(), currentIndex);

        currentPlayerText.text = true//PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Зараз: "+players[currentIndex].Split(':')[0]// + "'s turn"
            : /*"Черга "+*/players[currentIndex].Split(':')[0];

    }

    public string GetCurrent(){
        if (isSimpleGame){
            return "";
        }

        if (currentIndex>=players.Count){
            currentIndex=0;
        }

        return players[currentIndex];
    }
}
