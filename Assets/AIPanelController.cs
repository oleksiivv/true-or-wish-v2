using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPanelController : MonoBehaviour
{
    public GameObject panel;

    public void SetActive(bool active)
    {
        panel.SetActive(active);
    }
}
