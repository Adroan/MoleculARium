using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class idCarta : MonoBehaviour
{
    public int id;
    public string cenaAlvo;
  
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == cenaAlvo){
            recuperaID();
            Destroy(this.gameObject);
        }
    }

    public void salvarId(){
        transporte.idCarta = id;
        Debug.Log("transporte sal: "+transporte.idCarta);
        DontDestroyOnLoad(this.gameObject);
    }

    public int recuperaID(){
        id = transporte.idCarta;
       Debug.Log("transporte rec: "+transporte.idCarta);
        return id;
    }
}
