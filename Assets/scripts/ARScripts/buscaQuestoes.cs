using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buscaQuestoes : MonoBehaviour
{
    public List<Sprite> cartas;
    void Start()
    {
        carregarProximaCarta();
    }

    private void carregarProximaCarta()
    {
        Questions questions = JsonLoader.LoadFile();
        bool respondida = true;
        int indice = 0;
        do{
            respondida = questions.perguntas[indice].respondida;
            if(!respondida){
                atualizarPL_Carta(indice);
                break;
            }
            indice++;
        }while(respondida || indice <= questions.perguntas.Count-1 );
    }

    private void atualizarPL_Carta(int indice)
    {
        proximaPergunta.idPergunta = indice;
        this.gameObject.transform.Find("IMG_Cartas").GetComponent<Image>().sprite = cartas[indice];
        this.gameObject.transform.Find("TXT_IDCarta").GetComponent<Text>().text = "ID: "+indice;

    }
}
