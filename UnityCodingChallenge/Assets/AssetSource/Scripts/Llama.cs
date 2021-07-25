using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Llama : MonoBehaviour
{
    [Range(1, 5)] public float walkRadius;
    [Range(50, 100)] public float speed;
    public GameObject moneyPrefab;
    public LayerMask clickable;


    private NavMeshAgent llamaAgent;
    private int health;
    private int age;
    // 1: Grass, 2: Flower, 3: Shrubs
    private int dietType;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range(50, 100);
        age = Random.Range(0, 20);
        dietType = Random.Range(1, 3);
        llamaAgent = GetComponent<NavMeshAgent>();

        llamaAgent.speed = speed;
        llamaAgent.SetDestination(Wander());
    }

    // Update is called once per frame
    void Update()
    {
        if (llamaAgent != null && llamaAgent.remainingDistance <= llamaAgent.stoppingDistance)
        {
            llamaAgent.SetDestination(Wander());
        }
    }

    public Vector3 Wander() 
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;

        randomPosition += transform.position;

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    void DropMoney()
    {   
        int money = Random.Range(1, 5);

        for (int i = 1; i < money + 1; i++)
        {
            Instantiate(moneyPrefab, transform.position + new Vector3 (Random.Range(1, 3), 0.3f, Random.Range(1,3)),
            Quaternion.identity);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            DropMoney();
            Destroy(gameObject);
        }
    }
}
