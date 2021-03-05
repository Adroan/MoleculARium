using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnClickNewMol : MonoBehaviour
{
    public GameObject HidrogenioCreator;
    private Ray ray;
    private RaycastHit hit;
    public GameObject Carbono;

    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    criarCarbono();
                }
            }
        }
    }


    void criarCarbono()
    {

        GameObject carb = Instantiate(Carbono, this.gameObject.transform.position, Quaternion.identity);
        List<Atomo> hidros = new List<Atomo>();
        GameObject hidro;
        for (int i = 0; i < 3; i++)
        {
            hidro = HidrogenioCreator.GetComponent<HidrogenioCreator>().InstanciarHidrogenio();
            hidros.Add(hidro.GetComponent<Atomo>());
        }
        carb.GetComponent<Atomo>().setAllAtomos(hidros);
        for (int i = 0; i < 3; i++)
        {
            carb.GetComponent<Atomo>().getAtomoById(i).addAtomo(carb.GetComponent<Atomo>());
            carb.GetComponent<Atomo>().getAtomoById(i).transform.SetParent(carb.transform);
            carb.GetComponent<Atomo>().setAtomoPai(this.gameObject.GetComponent<Atomo>().getAtomoById(0).GetComponent<Atomo>());
        }
        atualizarAnterior(carb.GetComponent<Atomo>());
        carb.transform.SetParent(this.transform.parent.transform.parent);
    }

    void atualizarAnterior(Atomo carbono)
    {
        this.gameObject.GetComponent<Atomo>().getAtomoById(0).GetComponent<Atomo>().substituirAtomo(this.GetComponent<Atomo>(), carbono);
        carbono.getAtomoPai().recriarLig();
        Destroy(this.gameObject);

    }

}
