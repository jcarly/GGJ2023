using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    public List<GameObject> objects;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    public float spawnScoreFactor = 100f;


    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + (timeBetweenSpawn / (spawnScoreFactor * ScoreManager.score + 1 ));
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(objects[Random.Range(0, objects.Count)], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
