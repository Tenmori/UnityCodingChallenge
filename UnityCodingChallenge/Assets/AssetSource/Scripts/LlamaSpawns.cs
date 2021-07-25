using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlamaSpawns : MonoBehaviour
{
    private float nextSpawnTime;
    private float maxLlamaCount = 10;

    public GameObject llamaPrefab;
    private float spawnDelay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(llamaPrefab, new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(llamaPrefab, new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(llamaPrefab, new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(llamaPrefab, new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10)), Quaternion.identity);
        Instantiate(llamaPrefab, new Vector3(Random.Range(0, 10), 1, Random.Range(0, 10)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(llamaPrefab, transform.position, transform.rotation);
        spawnDelay = Random.Range(3, 7);
    }

    private bool ShouldSpawn()
    {
        int llamaCount = GameObject.FindGameObjectsWithTag("Llama").Length;
        return Time.time >= nextSpawnTime && maxLlamaCount > llamaCount;
    }
}
