using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroiLig : MonoBehaviour
{
    private bool temCarbono = false;

    public GameObject hidrogenio;
    

    public void destruirLig(GameObject carbonoDaVez)
    {
            Debug.Log(carbonoDaVez.name);
            GameObject acerto = carbonoDaVez;
            if (acerto.GetComponent<Atomo>().getSimb() == 'C')
            {
                for (int i = 0; i < acerto.GetComponent<Atomo>().getAllAtomos().Count; i++)
                {
                    if (acerto.GetComponent<Atomo>().getAtomoById(i).getSimb() == 'C'&& acerto.GetComponent<Atomo>().getAtomoPai() != null)
                    {
                        temCarbono = true;
                        GameObject CarbonoNovaMol = acerto.GetComponent<Atomo>().getAtomoById(i).gameObject;
                        GameObject hidro = hidrogenio.GetComponent<HidrogenioCreator>().InstanciarHidrogenio();
                        CarbonoNovaMol.GetComponent<Atomo>().addAtomo(hidro.GetComponent<Atomo>());
                        hidro.transform.SetParent(CarbonoNovaMol.transform);
                        hidro.GetComponent<Atomo>().addAtomo(CarbonoNovaMol.GetComponent<Atomo>());
                        Destroy(CarbonoNovaMol.transform.Find("Ligacao(Clone)").gameObject);

                        GameObject molecula = new GameObject(name: "Molecula" + GameObject.Find("AtomoControler").GetComponent<AtomController>().getNumMolecula());
                        CarbonoNovaMol.transform.SetParent(molecula.transform);
                        molecula.transform.position = new Vector3(molecula.transform.position.x + 5, molecula.transform.position.y + 1, molecula.transform.position.z + 1);

                        corrigirAtomo(acerto.GetComponent<Atomo>().getAtomoPai().gameObject,acerto);
                        Destroy(acerto.gameObject);
                        CarbonoNovaMol.GetComponent<Atomo>().recriarLig();
                    }else if(acerto.GetComponent<Atomo>().getAtomoById(i).getSimb() == 'C'&& acerto.GetComponent<Atomo>().getAtomoPai() == null){
                        temCarbono = true;
                        GameObject CarbonoIni = acerto.GetComponent<Atomo>().getAtomoById(i).gameObject;
                        GameObject hidro = hidrogenio.GetComponent<HidrogenioCreator>().InstanciarHidrogenio();
                        CarbonoIni.GetComponent<Atomo>().addAtomo(hidro.GetComponent<Atomo>());
                        hidro.transform.SetParent(CarbonoIni.transform);
                        hidro.GetComponent<Atomo>().addAtomo(CarbonoIni.GetComponent<Atomo>());
                        Destroy(CarbonoIni.transform.Find("Ligacao(Clone)").gameObject);
                        Destroy(acerto.gameObject);
                        CarbonoIni.GetComponent<Atomo>().recriarLig();
                    }
                }
                if (!temCarbono && acerto.GetComponent<Atomo>().getAtomoPai() == null)
                {
                    Destroy(acerto.transform.parent.gameObject);
                    Camera.main.GetComponent<MobilemaxCamera>().target =GameObject.Find("AtomController").transform;
                    Destroy(acerto);
                }else if(!temCarbono && acerto.GetComponent<Atomo>().getAtomoPai() != null){
                    corrigirAtomo(acerto.GetComponent<Atomo>().getAtomoPai().gameObject,acerto);
                    Destroy(acerto);
                }

            }
        
    }

    private void corrigirAtomo(GameObject carbonoPai, GameObject Carbono)
    {
        GameObject hidro = hidrogenio.GetComponent<HidrogenioCreator>().InstanciarHidrogenio();
        hidro.transform.SetParent(carbonoPai.transform);
        hidro.GetComponent<Atomo>().addAtomo(carbonoPai.GetComponent<Atomo>());
        carbonoPai.GetComponent<Atomo>().substituirAtomo(Carbono.GetComponent<Atomo>(), hidro.GetComponent<Atomo>());
        carbonoPai.GetComponent<Atomo>().recriarLig();
    }
}
