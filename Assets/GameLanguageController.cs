using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLanguageController : MonoBehaviour
{
    public Text playersText;

    public Text settingsText;

    public Text settingsTitleText;

    public Text settingsCategoryText;

    public Text menuText;

    public Dropdown categoryDropdown;

    public Text musicText;

    public Text doneText;

    public Text whoIsWinnerText;

    public Text loadingText;

    public Text skipText;

    void Awake(){
        //PlayerPrefs.SetString("language", "ukr");

        playersText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Players" : "Гравці";

        settingsText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Settings" : "Налаштування";

        settingsTitleText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Settings" : "Налаштування";

        settingsCategoryText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Category" : "Категорія";

        menuText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Menu" : "Меню";

        musicText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Music" : "Мелодія";

        doneText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Next" : "Наступний";

        whoIsWinnerText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Who guessed this movie?" : "Хто вгадав цей фільм?";

        loadingText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "loading..." : "Завантаження...";

        skipText.text = PlayerPrefs.GetString("language", "eng") == "eng" ? "Skip" : "Пропустити";

        categoryDropdown.ClearOptions();

        var mostPopularOption = new Dropdown.OptionData();
        var everythingOption = new Dropdown.OptionData();

        if (PlayerPrefs.GetString("language", "eng") == "eng"){
            mostPopularOption.text = "Most popular";
            everythingOption.text = "Everything";
        } else {
            mostPopularOption.text = "Найпопулярніше";
            everythingOption.text = "Все";
        }

        categoryDropdown.options.Add(mostPopularOption);
        categoryDropdown.options.Add(everythingOption);
    }
}
