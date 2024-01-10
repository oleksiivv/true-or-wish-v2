using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersPanelController : MonoBehaviour
{
    public GameObject panel;

    public Text playerNameAndScorePrephab;

    void Start(){
        int levelId = PlayerPrefs.GetInt("CurrentLevel");
        string players = PlayerPrefs.GetString("PlayersInSavedLevel#"+levelId.ToString());
        List<string> playersList = new List<string>(players.Split(','));

        inAdminMode=false;
        foreach(var player in playersList){
            if(player.ToUpper().Contains("ES02JV")){
                inAdminMode=true;
            }
        }

        UpdatePlayersView(playersList);

        SetPlayersPanelActive(false);
    }

    public void SetPlayersPanelActive(bool active){
        panel.SetActive(active);
    }

    private bool inAdminMode=false;

    public List<Text> playersText;

    public GameObject playersCanvas;

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
