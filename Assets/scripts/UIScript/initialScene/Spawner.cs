using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject carbono;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    public Vector2 carbonoSizeMinMax;
    Vector2 screenHalfSizeWorldUnits;
    public float SpawnAngleMax;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime) {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Dificulty.getDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnAngle = Random.Range(-SpawnAngleMax, SpawnAngleMax);

            float spawnSize = Random.Range(carbonoSizeMinMax.x, carbonoSizeMinMax.y);
            Vector2 spanwPosicion = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y+spawnSize);
            GameObject newblock = (GameObject)Instantiate(carbono, spanwPosicion, Quaternion.Euler(Vector3.forward*spawnAngle));
            newblock.transform.localScale = Vector2.one * spawnSize;
            
        }
    }


}
