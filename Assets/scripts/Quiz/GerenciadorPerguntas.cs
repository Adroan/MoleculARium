using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorPerguntas : MonoBehaviour
{


    private int valorMax;

    public List<GameObject> molecula_prefabs;
    public GameObject verificarRespostaContrucao;
    private Questions questions;
    private string respostaAtual;
    private int numeroPerguntas = 8;
    private int idAtual;
    private int pontuacao;

    void Start()
    {
        pontuacao = 0;

        questions = JsonLoader.LoadFile();
        questions.jogoIniciado = true;

        valorMax = numeroPerguntas;
        print(numeroPerguntas);

        // GerarNumerosAleatorios();

        Debug.Log("transporte per: " + transporte.idCarta);
        GameObject.Find("BTN_IniciarMolecula").transform.localScale = new Vector3(0, 0, 0);
        atualizarTela(transporte.idCarta);

    }

    public void atualizarTela(int id)
    {
        this.gameObject.transform.Find("TXT_PerguntaAtual").GetComponent<Text>().text = transporte.idCarta + "/" + valorMax;
        idAtual = id;
        Perguntas perguntas = questions.perguntas[id];
        this.gameObject.transform.Find("txt_Titulo").GetComponent<Text>().text = perguntas.titulo;
        this.gameObject.transform.Find("PL_CaixaTexto").GetChild(0).GetComponent<Text>().text = perguntas.pergunta;
        if (perguntas.respondida)
        {
            this.gameObject.transform.Find("BTN_Verificar").transform.localScale = new Vector3(0, 0, 0);

        }
        else
        {
            this.gameObject.transform.Find("BTN_Verificar").transform.localScale = new Vector3(1, 1, 1);
        }
        if (id > 5)
        {
            GameObject.Find("BTN_IniciarMolecula").transform.localScale = new Vector3(1, 1, 1);
            atualizarPL_CaixaTexto();
        }
        else
        {
            Camera.main.GetComponent<MobilemaxCamera>().target = Instantiate(molecula_prefabs[id]).transform;
        }

        this.gameObject.transform.Find("BTN_Verificar").GetComponent<Verificar>().resetar();
        mostrarRespostas(perguntas);
        ativar1scroll(id);

    }

    private void ativar1scroll(int id)
    {
        GameObject pl_caixatexto = transform.Find("PL_CaixaTexto").gameObject;

        if (id == 5 || id == 6 || id == 8)
        {

            pl_caixatexto.GetComponent<ScrollRect>().vertical= true;
        }
        else
        {
            pl_caixatexto.GetComponent<ScrollRect>().vertical = false;
        }
    }

    private void atualizarPL_CaixaTexto()
    {
        GameObject pl_caixatexto = transform.Find("PL_CaixaTexto").gameObject;
        pl_caixatexto.transform.localPosition = new Vector3(0, 0, 0);
        pl_caixatexto.GetComponent<RectTransform>().sizeDelta = new Vector2(667, 616);

    }

    private void mostrarRespostas(Perguntas perguntas)
    {

        for (int i = 65; i <= 69; i++)
        {
            char n = (char)i;
            this.gameObject.transform.Find("BTN_Resposta" + n.ToString()).transform.localScale = new Vector3(0, 0, 0);
            this.gameObject.transform.Find("BTN_Resposta" + n.ToString()).GetComponent<Image>().color = new Vector4(255, 255, 255, 0.44f);
        }
        if (perguntas.respostas.Count > 0)
        {
            for (int i = 65; i < 65 + perguntas.respostas.Count; i++)
            {
                char n = (char)i;
                this.gameObject.transform.Find("BTN_Resposta" + n.ToString()).transform.localScale = new Vector3(1, 1, 1);
                this.gameObject.transform.Find("BTN_Resposta" + n.ToString()).GetChild(0).GetComponent<Text>().text = perguntas.respostas[i - 65];
                foreach (string respostaCerta in perguntas.respostaCerta)
                {
                    if (perguntas.respondida && perguntas.respostas[i - 65].Equals(respostaCerta))
                    {
                        Debug.Log("respondida");
                        this.gameObject.transform.Find("BTN_Resposta" + n.ToString()).GetComponent<Image>().color = new Vector4(60, 179, 113, 0.44f);
                    }
                }
            }
        }
    }

    public void respostaSelecionada(Button bt)
    {

        GameObject PLpai = bt.transform.parent.gameObject;
        for (int i = 65; i <= 69; i++)
        {
            char n = (char)i;
            PLpai.transform.Find("BTN_Resposta" + n.ToString()).GetComponent<Image>().color = new Vector4(255, 255, 255, 0.44f);
        }
        respostaAtual = bt.transform.GetChild(0).GetComponent<Text>().text;
        bt.GetComponent<Image>().color = new Vector4(0, 100, 255, 0.44f);

    }

    public bool verificarResposta()
    {
        if (idAtual < 6)
        {
            bool acertou = false;
            foreach (string resposta in questions.perguntas[idAtual].respostaCerta)
            {
                if (resposta == respostaAtual)
                {
                    acertou = true;
                }
            }
            if (acertou)
            {
                if (!questions.perguntas[idAtual].respondida)
                {
                    questions.perguntas[idAtual].respondida = true;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {

            if (verificarRespostaContrucao.GetComponent<verificarRespostaConstrucao>().verificar(questions.perguntas[idAtual].respostaCerta))
            {
                if (!questions.perguntas[idAtual].respondida)
                {
                    questions.perguntas[idAtual].respondida = true;

                }
                return true;
            }
            return false;
        }
    }

    public void avancar()
    {
        if (!verificarTermino())
        {
            JsonLoader.toJson(questions);
            SceneManager.LoadScene("ARScene");
        }
        else
        {
            finalizarJogo();
        }
    }

    private bool verificarTermino()
    {
        int acertos = 0;
        foreach (Perguntas pergunta in questions.perguntas)
        {
            if (pergunta.respondida)
            {
                acertos++;
            }
        }
        if (acertos == numeroPerguntas +1)
        {
            return true;
        }
        return false;
    }

    private void finalizarJogo()
    {
        GameObject telaFinal = this.gameObject.transform.parent.Find("PL_GameOver").gameObject;
        foreach(Perguntas perguntas in questions.perguntas){
            if(perguntas.respondida){
                pontuacao++;
            }
        }
        telaFinal.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        telaFinal.transform.Find("TXT_Pontuacao").GetComponent<Text>().text = pontuacao.ToString();
    }




    /*void GerarNumerosAleatorios()
    {
        do
        {
            int indice = UnityEngine.Random.Range(0, numeros.Count);
            int numeroSorteado = numeros[indice];
            perguntasFeitas.Add(numeroSorteado);
            numeros.Remove(numeros[indice]);
        } while (numeros.Count > 0);
        /*List<int> fase1 = new List<int>();
        List<int> fase2 = new List<int>();
        List<int> fase3 = new List<int>();
        for (int i = 3; i > 0; i--)
        {
            switch (i)
            {
                case 3:
                    for (int j = 0; j < 3; j++)
                    {
                        fase1.Add(numeros[0]);
                        numeros.Remove(numeros[0]);
                    }
                    break;
                case 2:
                    for (int j = 0; j < 3; j++)
                    {
                        fase2.Add(numeros[0]);
                        numeros.Remove(numeros[0]);
                    }
                    break;
                case 1:
                    for (int j = 0; j < 3; j++)
                    {
                        fase3.Add(numeros[0]);
                        numeros.Remove(numeros[0]);
                    }
                    break;
            }
        }
        gerarPerguntasFeitas(fase1);
        gerarPerguntasFeitas(fase2);
        gerarPerguntasFeitas(fase3);

    }

    private void gerarPerguntasFeitas(List<int> fase)
    {
        int indice = UnityEngine.Random.Range(0, fase.Count);
        int numeroSorteado = fase[indice];
        perguntasFeitas.Add(numeroSorteado);
        numeros.Remove(fase[indice]);
    }*/
}
