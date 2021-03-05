using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriarCiclo : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject carbonoDavez;
    private GameObject CarbonoIni;
    private GameObject CarbonoFim;




    public void mostrarMenu(GameObject carbono)
    {
        GameObject menu = GameObject.Find("PL_MenuCarbono");
        menu.transform.localScale = new Vector3(1, 1, 1);
        menu.transform.localPosition = new Vector3(-100, 0, 0);


        this.carbonoDavez = carbono;
    }

    public void clicou()
    {
        print("CarbonoIni");
        CarbonoIni = carbonoDavez;

    }

    public void soltou()
    {

        CarbonoFim = carbonoDavez;
        print("CarbonoFim");
        interligar();

    }

    void interligar()
    {
        if (CarbonoFim != CarbonoIni)
        {
            CarbonoIni.GetComponent<Atomo>().substituirAtomo(CarbonoIni.GetComponent<Atomo>().getAtomoById(0), CarbonoFim.GetComponent<Atomo>());
            Destroy(CarbonoIni.transform.GetChild(0).gameObject);
            CarbonoFim.GetComponent<Atomo>().substituirAtomo(CarbonoFim.GetComponent<Atomo>().getAtomoById(CarbonoFim.GetComponent<Atomo>().getAllAtomos().Count - 1), CarbonoIni.GetComponent<Atomo>());
            print(CarbonoFim.GetComponent<Atomo>().getAllAtomos().Count - 1);
            Destroy(CarbonoFim.transform.GetChild(CarbonoFim.transform.childCount - 1).gameObject);
            CarbonoIni.GetComponent<Atomo>().recriarLig();
        }
        CarbonoIni = null;
        CarbonoFim = null;
    }

    public GameObject getCarbonoDaVez(){
        return carbonoDavez;
    }
}
