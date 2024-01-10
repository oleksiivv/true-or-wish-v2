using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject panel;

    public void SetPanelActive(bool active){
        panel.SetActive(active);
    }
}
