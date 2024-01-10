using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public GameController gameController;

    private List<string> players;

    public Text timerText;

    private int levelId;

    public int time=60;

    private int resetTime;

    public CurrentPlayerController currentPlayerController;

    public GameObject startPanel;

    public Text startPanelName, startPanelText;

    void Awake(){
        resetTime = time;
    }

    public void Init(List<string> players1, int levelId1, bool moveToNextPlayer=true){
        levelId = levelId1;
        players = players1;

        time=resetTime;

        timerText.gameObject.SetActive(false);

        if (moveToNextPlayer) {
            startPanel.SetActive(true);
            startPanelName.text = (PlayerPrefs.GetString("language", "eng") == "eng" ? "Next player:\n" : "Зараз черга гравця:\n") + currentPlayerController.GetCurrent().Split(':')[0];
            startPanelText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Tap to start" : "Натисни щоб почати";
        }
    }

    public void StartTimer(){
        startPanel.SetActive(false);
        if(PlayerPrefs.GetInt("timer", 0) == 1) {
            timerText.gameObject.SetActive(true);
            StartCoroutine(Timer());
            Invoke(nameof(ResetTimer), time+2);
        }
    }

    IEnumerator Timer(){
        while(time>=0){
            timerText.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1);
        }
    }

    public void StopTimer(){
        StopAllCoroutines();
        CancelInvoke(nameof(ResetTimer));
    }

    public void ResetTimer(){
        CancelInvoke(nameof(ResetTimer));
        time=resetTime;
        StopAllCoroutines();
        //gameController.LoadNextMovie(players, levelId, false, PlayerPrefs.GetInt("timer", 0) == 1);
    }
}
