using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestruirCarbono : MonoBehaviour
{

        void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject carbono = GameObject.Find("CriarCiclo").GetComponent<CriarCiclo>().getCarbonoDaVez();
        GameObject destruir = GameObject.Find("DestruidorLigacoes");
        Debug.Log("Mandou destruir esse "+ carbono.name);
        destruir.GetComponent<DestroiLig>().destruirLig(carbono);
        this.gameObject.transform.parent.transform.localScale = new Vector3(0,0,0);
    }

}
