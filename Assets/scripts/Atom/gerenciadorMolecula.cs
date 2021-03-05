using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerenciadorMolecula : MonoBehaviour
{
    private GameObject molecula;
    private int numMol;
    private bool isCiclo;
    private List<GameObject> qntCarbono = new List<GameObject>();
    private List<GameObject> qntHidr= new List<GameObject>();

    void Update(){
        if(Input.GetKeyDown(KeyCode.M)){
            nomeMol();
        }
    }

   
    void nomeMol(){
        numMol = 0;
        print("Molecula"+numMol);
        molecula =GameObject.Find("Molecula"+numMol);
        while(molecula!=null){
            qntCarbono.Add(molecula.transform.GetChild(0).gameObject);
            isCiclo = false;
            contarAtomos(qntCarbono[0]);
            print("Nome da molécula: C"+qntCarbono.Count+"H"+qntHidr.Count + "Ciclo = "+isCiclo);
            qntCarbono.Clear();
            qntHidr.Clear();
            numMol +=1;
            molecula = GameObject.Find("Molecula"+numMol);
        }

        
    }

    private void contarAtomos(GameObject carbono)
    {   
        for(int i = 0; i < carbono.GetComponent<Atomo>().getAllAtomos().Count; i++){
            if(carbono.GetComponent<Atomo>().getAtomoById(i).getSimb() == 'C'&& carbono.GetComponent<Atomo>().getAtomoById(i).gameObject!=qntCarbono[0]){
                qntCarbono.Add(carbono);
                contarAtomos(carbono.GetComponent<Atomo>().getAtomoById(i).gameObject);
            }else if(carbono.GetComponent<Atomo>().getAtomoById(i).getSimb() == 'H'){
                qntHidr.Add(carbono.GetComponent<Atomo>().getAtomoById(i).gameObject);
            }else if(carbono.GetComponent<Atomo>().getAtomoById(i).gameObject==qntCarbono[0]){
                isCiclo = true;
            }
        }
    }
}
