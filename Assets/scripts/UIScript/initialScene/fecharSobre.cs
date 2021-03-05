using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fecharSobre : MonoBehaviour
{
   
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.Find("PL_Sobre").transform.localScale = new Vector3(0,0,0);
        GameObject.Find("PL_Sobre").transform.localPosition = new Vector3(10000,10000,0);

    }
}
