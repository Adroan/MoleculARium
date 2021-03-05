using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class CreateAtom : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.Find("AtomController").GetComponent<AtomController>().iniciarMolecula();
        GameObject.Find("BTN_DestruirMolecula").transform.localScale = new Vector3(1,1,1);
        this.transform.localScale = new Vector3(0,0,0);

    }
}
