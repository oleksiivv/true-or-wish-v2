using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLanguageController : MonoBehaviour
{
    public Text titleText, titleTextBackground;

    public Text newGameText, newGameNumberofPlayers;

    public Text continueGameText, savedGamesText;

    public Text settingsText;

    public Text rateText;

    public Text languageText;

    public Text musicText;

    public Text startNewGameText;

    public Text newGameNameText;

    public Text startGameText;

    public Text loadingText;

    public Text settingsTitle;

    public Text chooseLanguageText, confirmChoosenLanguageText;

    public Text studyText, studyTitle, studyOk;

    public void Start(){
        PlayerPrefs.SetString("language", "ukr");

        //titleText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Movie\nMania" : "Кіно\nМанія";
        //titleTextBackground.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Movie\nMania" : "Кіно\nМанія";

        newGameText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "New game" : "Нова гра";

        continueGameText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Continue" : "Продовжити";
        savedGamesText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Saved games" : "Збережені ігри";

        settingsText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Settings" : "Налаштування";
        settingsTitle.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Settings" : "Налаштування";

        rateText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Rate" : "Вподобати";

        languageText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Language" : "Мова";

        musicText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Music" : "Мелодія";

        startNewGameText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Start\nNew game" : "Почати\nНову гру";

        newGameNameText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Game name" : "Назва гри";

        startGameText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Start" : "Почати";

        loadingText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "loading..." : "Завантаження...";

        chooseLanguageText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Choose language" : "Обери мову";
        confirmChoosenLanguageText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Confirm" : "Підтвердити";


        studyText.text = PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Explain a movie to other players, and the one who will guess the movie receives game point. The player with most game points will win the game. Each player will have a turn to explain a movie or series." 
            : "Поясніть фільм іншим гравцям, і той, хто вгадає фільм, отримує ігровий бал. Гравець, який вгадає найбільше фільмів, виграє гру. Всі гравці пояснюють по черзі.";
        
        studyTitle.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "How to play?" : "Як грати?";
        studyOk.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Ok" : "Зрозуміло";

        newGameNumberofPlayers.text = PlayerPrefs.GetString("language", "eng") == "eng" 
            ? "Number of players: <b>3</b>"
            : "Кількість гравців: <b>3</b>";
    }
}
