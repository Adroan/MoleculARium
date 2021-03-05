using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FecharPanelPergunta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.Find("PL_Pergunta").transform.localScale = new Vector3(0,0,0);
        GameObject.Find("BTN_AbrirPanelPergunta").transform.localScale = new Vector3(1,1,1);
        this.gameObject.transform.localScale = new Vector3(0,0,0);
    }
}
