using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class verificarRespostaConstrucao : MonoBehaviour
{
    private List<Atomo> atomos = new List<Atomo>();
    private int numCarbono = 0;
    private int numHidro = 0;
    public bool verificar(List<string> resposta)
    {

        Debug.Log(GameObject.Find("Molecula" + (GameObject.Find("AtomController").GetComponent<AtomController>().getNumMolecula() - 1)));
        Debug.Log(GameObject.Find("AtomController").GetComponent<AtomController>().getNumMolecula());
        bool acertou = false;
        string respostaMolecula = leitorMolecula(GameObject.Find("Molecula" + (GameObject.Find("AtomController").GetComponent<AtomController>().getNumMolecula() - 1)));
        foreach (string res in resposta)
        {
            if (res == respostaMolecula)
            {
                acertou = true;
            }
            Debug.Log("resposta: " + res + " =" + acertou);
        }

        if (acertou)
        {
            numCarbono = 0;
            numHidro = 0;
            atomos.Clear();
            return true;
        }
        else
        {
            numCarbono = 0;
            numHidro = 0;
            atomos.Clear();
            return false;
        }
    }

    public string leitorMolecula(GameObject molecula)
    {
        string moleculaAtual = "";
        if (molecula != null)
        {
            if (molecula.transform.childCount > 0)
            {
                navegarEntreAtomos(molecula.transform.GetChild(0).gameObject);
            }
        }
        foreach (Atomo atomo in atomos)
        {
            moleculaAtual += atomo.getSimb();
        }
        Debug.Log("Resposta encontrada: " + moleculaAtual);
        Debug.Log("Formula: C" + numCarbono + "H" + numHidro);
        return moleculaAtual;
    }

    private void navegarEntreAtomos(GameObject carbono)
    {
        atomos.Add(carbono.GetComponent<Atomo>());
        numCarbono++;
        foreach (Atomo atm in carbono.GetComponent<Atomo>().getAllAtomos())
        {
            if (atm.getSimb() == 'C')
            {
                navegarEntreAtomos(atm.gameObject);
            }
            else
            {
                numHidro++;
                atomos.Add(atm);
            }
        }
    }
}
