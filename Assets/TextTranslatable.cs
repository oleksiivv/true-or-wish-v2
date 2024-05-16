using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTranslatable : MonoBehaviour
{
    public string ukr;
    public string eng;

    private Text text;

    void Awake(){
        text=GetComponent<Text>();
    }

    public virtual void Translate(string language = "ukr"){
        if(language == "ukr"){
            text.text = ukr;
        } else if(language == "eng"){
            text.text = eng;
        }
    }
}
