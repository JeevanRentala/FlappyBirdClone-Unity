using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 2f;

    private float timer;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0;
        }
    }

    void SpawnPipe()
    {
        //float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}
