using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FecharJanelaSair : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
       this.gameObject.transform.parent.localScale = new Vector3(0,0,0);
       this.gameObject.transform.parent.localPosition = new Vector3(10000,10000,0);


    }
}
