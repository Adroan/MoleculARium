using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyMolecula : MonoBehaviour
{
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        this.transform.localScale = new Vector3(0,0,0);
    }

    void TaskOnClick()
    {
        GameObject.Find("AtomController").GetComponent<AtomController>().destruirMolecula();
        GameObject.Find("BTN_IniciarMolecula").transform.localScale = new Vector3(1,1,1);
        this.transform.localScale = new Vector3(0,0,0);

    }
}
