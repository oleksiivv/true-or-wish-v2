using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MenuLanguageController : MonoBehaviour
{
    public static List<TextTranslatable> texts = new List<TextTranslatable>();

    void Start(){
        texts = FindObjectsOfType<TextTranslatable>().ToList();
    }

    public static void Translate(){
        texts = FindObjectsOfType<TextTranslatable>().ToList();
        
        Debug.Log(texts.Count);
        string language = PlayerPrefs.GetString("language", "ukr");

        foreach(var text in texts){
            text.Translate(language);
        }
    }
}
