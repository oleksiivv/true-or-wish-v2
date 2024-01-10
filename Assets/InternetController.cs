using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InternetController : MonoBehaviour
{
    public GameObject internetError;
    // Start is called before the first frame update
    void Start()
    {
        /*if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            internetError.SetActive(true);
        }
        else{
            internetError.SetActive(false);
        }*/
    }

    public void Retry(){
        Application.LoadLevelAsync(Application.loadedLevel);
    }
}
