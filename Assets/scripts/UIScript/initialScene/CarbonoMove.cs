using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarbonoMove : MonoBehaviour
{
    public Vector2 speedMinMax;
    float visibleHeigthThreshold;
    // Update is called once per frame

    private void Start()
    {
        visibleHeigthThreshold = -Camera.main.orthographicSize - transform.localScale.y;
    }
    void Update()
    {
        float speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Dificulty.getDifficultyPercent());
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < visibleHeigthThreshold)
        {
            Destroy(gameObject);
        }
    }
}
