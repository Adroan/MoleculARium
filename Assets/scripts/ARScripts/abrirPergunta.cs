using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.SceneManagement;
using System;

public class abrirPergunta : MonoBehaviour
{
    public GameObject carta;
    public Material[] materials;


    void Start()
    {
        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < vbs.Length; ++i)
        {

            vbs[i].RegisterOnButtonPressed(OnButtonPressed);

            vbs[i].RegisterOnButtonReleased(OnButtonReleased);
        }
    }


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        Debug.Log("pressed");
        if (carta.GetComponent<idCarta>().id == proximaPergunta.idPergunta)
        {
            this.gameObject.transform.Find("Plane").GetComponent<MeshRenderer>().material = materials[0];
            carta.GetComponent<idCarta>().salvarId();

            SceneManager.LoadScene(carta.GetComponent<idCarta>().cenaAlvo);
        }else{
            this.gameObject.transform.Find("Plane").GetComponent<MeshRenderer>().material = materials[1];
        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

        Debug.Log("nope");

    }

}
