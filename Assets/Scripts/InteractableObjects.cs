using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter : MonoBehaviour
{
    // Start is called before the first frame update

    public string ItemName;
    public bool PlayerInRange = false;

    
    public string GetName()
    {
        return ItemName;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // press"E" to pick up item 
        if(PlayerInRange && Input.GetKeyDown(KeyCode.E) && !InventorySystem.Instance.IsFull() )
        {
            //item into player's inventory
            InventorySystem.Instance.AddToInventory(ItemName);
            Destroy(gameObject);
        }
    }

    //Player can only collect  the item if they in a certain range
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
