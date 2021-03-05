using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickButtonResopota : MonoBehaviour
{
 void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.Find("PL_Pergunta").GetComponent<GerenciadorPerguntas>().respostaSelecionada(this.GetComponent<Button>());

    }
}
