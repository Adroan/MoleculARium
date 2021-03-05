using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciadorTelaInicial : MonoBehaviour
{
    
    public GameObject btnjogar;
    
    public GameObject btncontinuar;
    
    public GameObject btnnovoJogo;

    void Start(){
        verificarContinuar();
    }

    void verificarContinuar()
    {
        try{
        Questions questions = JsonLoader.LoadFile();
        if(questions.jogoIniciado){
            btncontinuar.transform.localScale = new Vector3(1,1,1);
            btnnovoJogo.transform.localScale = new Vector3(1,1,1);
            btnjogar.transform.localScale = new Vector3(0,0,0);
        }else{
            btncontinuar.transform.localScale = new Vector3(0,0,0);
            btnnovoJogo.transform.localScale = new Vector3(0,0,0);
            btnjogar.transform.localScale = new Vector3(1,1,1);
        }
        }catch(Exception){
             btncontinuar.transform.localScale = new Vector3(0,0,0);
            btnnovoJogo.transform.localScale = new Vector3(0,0,0);
            btnjogar.transform.localScale = new Vector3(1,1,1);
        }
    }
}
