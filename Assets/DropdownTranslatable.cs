using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTranslatable : TextTranslatable
{
    public List<string> ukrOptions;
    public List<string> engOptions;

    private Dropdown dropdown;

    void Awake(){
        dropdown=GetComponent<Dropdown>();
    }

    public override void Translate(string language = "ukr"){
        dropdown.ClearOptions();

        if(language == "ukr"){
            dropdown.AddOptions(ukrOptions);
        } else if(language == "eng"){
            dropdown.AddOptions(engOptions);
        }
    }
}
