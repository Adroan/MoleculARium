using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abrirSobre : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.Find("PL_Sobre").transform.localScale = new Vector3(1,1,1);
        GameObject.Find("PL_Sobre").transform.localPosition = new Vector3(0,0,0);

    }
}
