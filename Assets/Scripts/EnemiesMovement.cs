using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesMovement : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform Player;
    public bool PlayerInRange = false;
    public Collider EnemyCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   if (Vector3.Distance(Enemy., Player.transform.position)
        if (PlayerInRange)
        {
            Enemy.SetDestination(Player.position);
        }
    }

    private void OnTriggerEnter(Collider EnemyCollider)
    {
        if (EnemyCollider.CompareTag("Player"))
        {
            PlayerInRange = true;
            
        }
    }
}
