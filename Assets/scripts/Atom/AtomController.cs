using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomController : MonoBehaviour
{

    public GameObject Carbono;
    public GameObject HidrogenioCreator;

    public GameObject Molecula;

    private int numMolecula = 0;


    public void iniciarMolecula()
    {
        Molecula = new GameObject(name: "Molecula" + numMolecula);
        List<Atomo> hidros = new List<Atomo>();
        GameObject hidro;
        Camera.main.GetComponent<MobilemaxCamera>().target = Molecula.transform;

        GameObject carb = Instantiate(Carbono, transform.position, Quaternion.Euler(transform.eulerAngles));
        for (int i = 0; i < 4; i++)
        {
            hidro = HidrogenioCreator.GetComponent<HidrogenioCreator>().InstanciarHidrogenio();
            hidros.Add(hidro.GetComponent<Atomo>());
        }


        carb.GetComponent<Atomo>().setAllAtomos(hidros);

        for (int i = 0; i < 4; i++)
        {
            carb.GetComponent<Atomo>().getAtomoById(i).addAtomo(carb.GetComponent<Atomo>());
            carb.GetComponent<Atomo>().getAtomoById(i).transform.SetParent(carb.transform);
        }
        carb.transform.SetParent(Molecula.transform);
        numMolecula += 1;
    }

    public int getNumMolecula()
    {
        return numMolecula;
    }
    public void addNumMolecula()
    {
        this.numMolecula += 1;
    }

    public void destruirMolecula(){
        Camera.main.GetComponent<MobilemaxCamera>().target = this.transform;
        Destroy(GameObject.Find("Molecula"+(numMolecula-1)));
    }
}
