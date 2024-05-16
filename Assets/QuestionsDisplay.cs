using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class QuestionsDisplay : MonoBehaviour
{
    public List<string> questionsChild = new List<string>();
    public List<string> questionsAdult = new List<string>();
    public List<string> questionsInteresting = new List<string>();

    public List<string> questions = new List<string>();
    public List<string> usedQuestions=new List<string>();

    public GameInteraction game;

    public void Init(categories category){
        game=GetComponent<GameInteraction>();
        string categoryName = game.isSimpleGame 
            ? PlayerPrefs.GetString("CategoryInQuickLevel")
            : PlayerPrefs.GetString("CategoryInSavedLevel#"+game.levelId.ToString());

        questionsChild.Clear();
        questionsAdult.Clear();
        questionsInteresting.Clear();

        questionsChild = LoadChildFromJson();
        questionsAdult = LoadAdultsFromJson();
        questionsInteresting = LoadInterestingFromJson();

        loadAdditinalQuestions(categories.child,questionsChild);
        loadAdditinalQuestions(categories.adult,questionsAdult);
        loadAdditinalQuestions(categories.interesting,questionsInteresting);
        
        setQuestions(category);
        loadAdditinalQuestions(categories.all, questions);
    }


    private void saveChild()
    {
        string jsonString = JsonUtility.ToJson(new SerializableList(){data=questionsChild});

        Debug.Log(jsonString);

        File.WriteAllText("child.json", jsonString);
    }

    private void saveAdult()
    {
        string jsonString = JsonUtility.ToJson(new SerializableList(){data=questionsAdult});

        File.WriteAllText("adult.json", jsonString);
    }

    private void saveInteresting()
    {
        string jsonString = JsonUtility.ToJson(new SerializableList(){data=questionsInteresting});

        File.WriteAllText("interesting.json", jsonString);
    }


    public void setQuestions(categories ctg){
        questions.Clear();
        Debug.Log(ctg);
        Debug.Log(categories.interesting);
        Debug.Log(categories.child);
        Debug.Log(categories.adult);
        switch(ctg){
            case categories.child:
                foreach(var child in questionsChild){
                    if(child.Length > 2)questions.Add(child);
                }
            break;

            case categories.adult:
                foreach(var child in questionsAdult){
                    if(child.Length > 2)questions.Add(child);
                }
            break;

            case categories.interesting:
                foreach(var child in questionsInteresting){
                    if(child.Length > 2)questions.Add(child);
                }
            break;

            default:
            break;
        }
    }
    
    public string getRandom(){
        if(questions.Count==0){
            return getRandom();
        }

        else{
            string randomQuestion=questions[Random.Range(0,questions.Count)];
            if(usedQuestions.Contains(randomQuestion) && usedQuestions.Count*2<questions.Count){
               return getRandom(); 
            }
            else{
                return randomQuestion;
            }
        }
    }

    public IEnumerator getAllQuestions(categories ctg, List<string> list){
        list.Clear();
        string url="https://unity-questions-game.herokuapp.com/questions.php";
        switch(ctg){
            case categories.child:
            url="https://unity-questions-game.herokuapp.com/questions-childs.php";
            break;

            case categories.adult:
            url="https://unity-questions-game.herokuapp.com/questions-adults.php";
            break;

            case categories.interesting:
            url="https://unity-questions-game.herokuapp.com/questions-interesting.php";
            break;

        }
        using(UnityWebRequest www = UnityWebRequest.Get(url)){
            yield return www.Send();

            if(www.isNetworkError || www.isHttpError){
                Debug.Log(www.error);
            }
            else{

                string result=www.downloadHandler.text;
                string[] res = result.Split('~');

                foreach(var str in res){
                    string[] splittedStr = str.Split('/');

                    list.Add(splittedStr[0]);
                }
                //Debug.Log(www.downloadHandler.text);
                //Debug.Log(www.downloadHandler.data);
                
            }
        }   
    }

    void loadAdditinalQuestions(categories ctg,List<string> list){
        int n=0;

// Debug.Log("additional quesston:");
// Debug.Log(((int)ctg).ToString());

        while(PlayerPrefs.GetString(((int)ctg).ToString()+"_Q_additional_"+n.ToString(),"null")!="null"){
            string que=PlayerPrefs.GetString(((int)ctg).ToString()+"_Q_additional_"+n.ToString());

            //Debug.Log(que);
            list.Add(que);
            n++;
        }

    }

    public List<string> LoadAdultsFromJson()
    {
        TextAsset theList;
        
        var language = PlayerPrefs.GetString("language", "ukr");
        if(language == "ukr") {
            theList = (TextAsset)Resources.Load("adult", typeof (TextAsset));
        }else{
            theList = (TextAsset)Resources.Load("eng/adult", typeof (TextAsset));
        }

        string json = theList.text;
            
        JSONObject obj = JsonUtility.FromJson<JSONObject>(json)!;

        Debug.Log(json);

        return obj.data;
    }

    public List<string> LoadChildFromJson()
    {
        TextAsset theList;

        var language = PlayerPrefs.GetString("language", "ukr");
        if(language == "ukr") {
            theList = (TextAsset)Resources.Load("child", typeof (TextAsset));
        }else{
            theList = (TextAsset)Resources.Load("eng/child", typeof (TextAsset));
        }

        Debug.Log(theList);

        string json = theList.text;
            
        JSONObject obj = JsonUtility.FromJson<JSONObject>(json)!;

        

        return obj.data;
    }

    public List<string> LoadInterestingFromJson()
    {
        TextAsset theList;

        var language = PlayerPrefs.GetString("language", "ukr");
        if(language == "ukr") {
            theList = (TextAsset)Resources.Load("interesting", typeof (TextAsset));
        }else{
            theList = (TextAsset)Resources.Load("eng/interesting", typeof (TextAsset));
        }

        string json = theList.text;
        
        JSONObject obj = JsonUtility.FromJson<JSONObject>(json)!;

        Debug.Log(json);

        return obj.data;
    }
}
