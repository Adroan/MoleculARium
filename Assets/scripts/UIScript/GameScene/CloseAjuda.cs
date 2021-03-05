using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseAjuda : MonoBehaviour
{
    private Transform trnsformOrg;
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        GameObject panel = GameObject.Find("PL_Ajuda");
        panel.transform.localScale = new Vector3(0,0,0);
        panel.transform.position = new Vector3(0,0,0);
        
    }
}
