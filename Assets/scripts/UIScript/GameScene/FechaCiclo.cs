using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FechaCiclo : MonoBehaviour
{

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject gerenciadorCiclo = GameObject.Find("gerenciadorCiclo");
        gerenciadorCiclo.GetComponent<CriarCiclo>().soltou();
    }
}
