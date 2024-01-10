using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameObject loadingPanel;

    public void OpenSceneAsync(int id){
        loadingPanel.SetActive(true);
        Application.LoadLevelAsync(id);
    }
}
