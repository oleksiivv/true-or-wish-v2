using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryController : MonoBehaviour
{
    public static categories currentCategory=categories.all;

    public static string ToString(categories category){
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
    }

    public static categories FromString(string category){
        if(category == "Для дітей") {
            return categories.child;
        } else if(category == "18+"){
            return categories.adult;
        } else if(category == "Цікаве"){
            return categories.interesting;
        } else {
            return categories.all;
        }
    }
}

public enum categories{
    child,adult,interesting,all
}
