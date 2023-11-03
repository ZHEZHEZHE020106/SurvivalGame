using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{

    public float Health = 100;
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
}
