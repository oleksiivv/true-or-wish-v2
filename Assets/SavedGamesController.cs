using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SavedGamesController : MonoBehaviour
{
    public Button savedLevelButtonPrephab;

    public List<Button> savedLevels;

    private int SavedLevelsNumber;

    public GameObject canvas;

    public List<Vector3> buttonPositions;

    public MenuController menu;

    void Start(){
        //MockData();
        SavedLevelsNumber = PlayerPrefs.GetInt("SavedLevelsNumber", -1);
        Debug.Log("Saved levels: "+SavedLevelsNumber.ToString());

        for (int i=0; i<=SavedLevelsNumber; i++){
            var btn = Instantiate(savedLevelButtonPrephab, savedLevelButtonPrephab.transform.position, savedLevelButtonPrephab.transform.rotation) as Button;

            btn.name = "Game#"+i.ToString();
            btn.transform.parent = canvas.transform;
            //btn.transform.position = new Vector3(savedLevelButtonPrephab.transform.position.x, savedLevelButtonPrephab.transform.position.y - 130*(i+1), savedLevelButtonPrephab.transform.position.z);
            btn.transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("SavedLevel#"+i.ToString());

            btn.transform.localScale = new Vector3(1.6f, 1.6f, 1.6f);
            savedLevels.Add(btn);
        }

        List<UnityAction> actions = new List<UnityAction>();

        for (int i = 0; i <= SavedLevelsNumber; i++) {
            int index = i;
            actions.Add(new UnityAction(() => OpenSavedGame(index)));
        }

        for (int i=0; i<=SavedLevelsNumber; i++) {
            savedLevels[i].GetComponent<Button>().onClick.AddListener(actions[i]);
        }
    }

    void OpenSavedGame(int i){
        Debug.Log(i);

        menu.OpenGame(i);
    }

    private void MockData(){
        PlayerPrefs.SetInt("SavedLevelsNumber", 9);

        PlayerPrefs.SetString("SavedLevel#0", "Test-1");
        PlayerPrefs.SetString("SavedLevel#1", "Test-2");
        PlayerPrefs.SetString("SavedLevel#2", "Test-3");
        PlayerPrefs.SetString("SavedLevel#3", "Test-4");
        PlayerPrefs.SetString("SavedLevel#4", "Test-5");
        PlayerPrefs.SetString("SavedLevel#5", "Test-6");
        PlayerPrefs.SetString("SavedLevel#6", "Test-7");
        PlayerPrefs.SetString("SavedLevel#7", "Test-8");
        PlayerPrefs.SetString("SavedLevel#8", "Test-9");
    }

    List<UnityAction> GetMockedActions(){
        List<UnityAction> actions = new List<UnityAction>();

        actions.Add(new UnityAction(() => OpenSavedGame(0)));
        actions.Add(new UnityAction(() => OpenSavedGame(1)));
        actions.Add(new UnityAction(() => OpenSavedGame(2)));

        return actions;
    }
}
