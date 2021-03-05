using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidrogenioCreator : MonoBehaviour
{
    public GameObject Hidrogenio;
    private GameObject HidrogenioDavez;
    public GameObject InstanciarHidrogenio()
    {
        HidrogenioDavez = Instantiate(Hidrogenio);
        return HidrogenioDavez;
    }
}
