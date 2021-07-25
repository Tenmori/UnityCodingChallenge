using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask clickable;

    // player
    private NavMeshAgent playerAgent;
    // determine active animations for player
    private Animator animator;
    // if player is current mobile
    private int isRunningHash;

    private int health =100;
    private int money = 0;
    private int[] inventory = new int[3];

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");

        inventory[0] = 0;
        inventory[1] = 0;
        inventory[2] = 0;

    }

    void Update()
    {
        updateMovement();
    }

    void updateMovement()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (Input.GetMouseButtonDown(0) && !StoreInventoryPanel.isPaused)
        {
            Ray playerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(playerRay, out hitInfo, 100, clickable))
            {
                animator.SetBool(isRunningHash, true);
                playerAgent.SetDestination(hitInfo.point);
            }
        }

        if (!playerAgent.pathPending)
        {
            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance)
            {
                if (!playerAgent.hasPath || playerAgent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetBool(isRunningHash, false);
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Money")
        {
            Destroy(col.gameObject);
            money++;
        }
    }

    public int[] getInventory()
    {
        return inventory;
    }

    public int getMoney()
    {
        return money;
    }

    public void addInventory(int id, int count)
    {
        inventory[id] += count;
    }

    public void setMoney(int m)
    {
        money = m;
    }
}
