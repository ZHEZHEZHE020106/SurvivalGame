using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesMovement : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    public bool PlayerInRange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange)
        {
            Enemy.SetDestination(Player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
            
        }
    }
}
