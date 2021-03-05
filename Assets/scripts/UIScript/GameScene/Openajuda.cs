using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Openajuda : MonoBehaviour
{
    private Transform trnsformOrg;
    private GameObject panel ;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        panel = GameObject.Find("PL_Ajuda");
        panel.transform.localScale = new Vector3(0,0,0);
        panel.transform.position = new Vector3(0,0,0);
        
    }

    void TaskOnClick()
    {
        print("clicou");
        panel.transform.localScale = new Vector3(1,1,1);
        panel.transform.position = new Vector3(Screen.width/2,Screen.height/2,0);
        
    }
}
