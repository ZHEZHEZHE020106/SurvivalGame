using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter : MonoBehaviour
{
    // Start is called before the first frame update

    public string Name;
    public bool PlayerInRange = false;
    public string GetName()
    {
        return Name;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerInRange && Input.GetKeyDown(KeyCode.E)) 
        { 
            //pickup into player's inventory
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInRange = false;
        }
    }
}
