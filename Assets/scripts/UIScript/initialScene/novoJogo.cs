using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class novoJogo : MonoBehaviour
{

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        JsonLoader.backup();
        SceneManager.LoadScene("ARScene");
    }

}
