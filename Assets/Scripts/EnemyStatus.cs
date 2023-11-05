using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    public float Health = 100;
    public float Damage = 5;
    public float AttackDelay = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<PlayerStatus>().TakeDamage(Damage);
        }
    }

    public IEnumerator Delay(float AttackDelay)
    {

        yield return new WaitForSeconds(AttackDelay);
    }
}
