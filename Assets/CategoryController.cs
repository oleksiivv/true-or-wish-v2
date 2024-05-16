using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryController : MonoBehaviour
{
    public static categories currentCategory=categories.all;

    public static string ToString(categories category){
        var lng = PlayerPrefs.GetString("language", "ukr");

        if (lng == "ukr") {
            switch(category) {
                case categories.child:
                return "Для дітей";
                break;
                case categories.adult:
                return "18+";
                break;
                case categories.interesting:
                return "Цікаве";
                break;
                default:
                return "Все";
                break;
            }
        } else { //if (lng == "eng") 
            switch(category) {
                case categories.child:
                return "For kids";
                break;
                case categories.adult:
                return "18+";
                break;
                case categories.interesting:
                return "Interesting";
                break;
                default:
                return "All";
                break;
            }
        }
    }

    public static categories FromString(string category){
        if(category == "Для дітей" || category == "For kids") {
            return categories.child;
        } else if(category == "18+"){
            return categories.adult;
        } else if(category == "Цікаве" || category == "Interesting"){
            return categories.interesting;
        } else {
            return categories.all;
        }
    }
}

public enum categories{
    child,adult,interesting,all
}
