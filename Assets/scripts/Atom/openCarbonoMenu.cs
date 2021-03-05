using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openCarbonoMenu : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private GameObject carbonoDavez;
  


    void Update()
    {
        if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began))
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    GameObject.Find("CriarCiclo").GetComponent<CriarCiclo>().mostrarMenu(hit.transform.gameObject);
                    Debug.Log("mandou pro mostrar menu"+hit.transform.gameObject.name);
                    
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == this.gameObject)
                {
                    GameObject.Find("CriarCiclo").GetComponent<CriarCiclo>().mostrarMenu(hit.transform.gameObject);
                    
                }
            }
        }
    }
    
}
