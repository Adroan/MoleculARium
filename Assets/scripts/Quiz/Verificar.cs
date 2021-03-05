using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Verificar : MonoBehaviour
{
    public Sprite[] cores;
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = cores[0];
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        acertou(GameObject.Find("PL_Pergunta").GetComponent<GerenciadorPerguntas>().verificarResposta());

    }

    private void acertou(bool resultado)
    {
        if (resultado)
        {
            this.gameObject.GetComponent<Image>().sprite = cores[1];
        }
        else
        {
            this.gameObject.GetComponent<Image>().sprite = cores[2];
        }

    }
    public void resetar()
    {
        this.gameObject.GetComponent<Image>().sprite = cores[0];
    }
}
