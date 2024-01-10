using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class QuestionsFillController : MonoBehaviour
{
    public List<Question> Questions(string category="interesting"){
        List<Question> questions = new List<Question>();

        Debug.Log(category);

        if(!(category=="child" || category == "adult" || category=="interesting")){
            Debug.Log("invalid category");
        }

        switch(category){
            case "child":
            questions.AddRange(LoadChildFromJson());
            break;
            case "adult":
            questions.AddRange(LoadAdultCrazyFromJson());
            break;
            case "adult_crazy":
            questions.AddRange(LoadAdultCrazyFromJson());
            break;
            case "interesting":
            default:
            questions.AddRange(LoadInteresstingFromJson());
            break;
        }

        return this.Shuffle(questions);
    }

    public Question[] LoadAdultsFromJson()
    {
        TextAsset theList = (TextAsset)Resources.Load("adult", typeof (TextAsset));
        string json = theList.text;
        Debug.Log(json);

        QuestionsList questions = JsonUtility.FromJson<QuestionsList>(json)!;

        return questions.data;
    }

    public Question[] LoadChildFromJson()
    {
        TextAsset theList = (TextAsset)Resources.Load("child", typeof (TextAsset));
        string json = theList.text;
        //Debug.Log(json);

        QuestionsList questions = JsonUtility.FromJson<QuestionsList>(json)!;

        return questions.data;
    }

    public Question[] LoadInteresstingFromJson()
    {
        TextAsset theList = (TextAsset)Resources.Load("interesting", typeof (TextAsset));
        string json = theList.text;
        //Debug.Log(json);

        QuestionsList questions = JsonUtility.FromJson<QuestionsList>(json)!;

        return questions.data;
    }

    public Question[] LoadAdultCrazyFromJson()
    {
        TextAsset theList = (TextAsset)Resources.Load("adult_crazy", typeof (TextAsset));
        string json = theList.text;
        //Debug.Log(json);

        QuestionsList questions = JsonUtility.FromJson<QuestionsList>(json)!;

        return questions.data;
    }

    public List<Question> Shuffle(List<Question> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            var temp = _list[i];
            int randomIndex = Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }

        return _list;
    }
}
