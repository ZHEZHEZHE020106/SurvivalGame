using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public GameObject InventoryUI;
    public GameObject InventoryInfoUI;
    public bool InventoryOpen;
    public List<GameObject> Slots = new List<GameObject>();
    public List<string> Items = new List<string>();
    public GameObject ItemPicked;
    public GameObject SlotToStore;

    public GameObject trashAlertUI;

    Button YesBTN, NoBTN;
    public static InventorySystem Instance { get; set; }



    void Start()
    {
        AddSlots();
        InventoryOpen = false;

    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    

    public void AddSlots()
    {
        foreach(Transform child in InventoryUI.transform) 
        {
            if (child.CompareTag("InventorySlot"))
            {
                Slots.Add(child.gameObject);
            }
        
        }
    }

    //Add the item picked up into inventory
    public void AddToInventory(string ItemName)
    {
        if (!IsFull())
        {
            //Choose Slot
            SlotToStore = FindEmptySlot();
            ItemPicked =  Instantiate(Resources.Load<GameObject>(ItemName), SlotToStore.transform.position, SlotToStore.transform.rotation);
            ItemPicked.transform.SetParent(SlotToStore.transform);

            Items.Add(ItemName);    
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
        //Calculate();
        //CraftingSystem.instance.RefreshItems();
    }

    //Find a empty slot to allocate
    private GameObject FindEmptySlot()
    {
        foreach (GameObject slot in Slots)
        {
            if (slot.transform.childCount == 0)
            {
                return slot;
            }
        }
        return new GameObject();
    }

    //Check is every slot has a child
    public bool IsFull()
    {
        int count = 0;
        foreach (GameObject slot in Slots)
        {
            if (slot.transform.childCount > 0)
            {
                count++;
            }
        }

        if (count == 24)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        //Open/Close Inventory
        if(Input.GetKeyDown(KeyCode.Tab) && !InventoryOpen)
        {
            InventoryUI.SetActive(true);
            InventoryOpen = true;
            //Unlock cursor on inventory UI
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && InventoryOpen)
        {
            InventoryUI.SetActive(false);
            InventoryOpen = false;
            //Lock cursor when we close inventory
            Cursor.lockState = CursorLockMode.Locked;
        }


    }

    public void RemoveItem(string name, int amount)
    {
        int count = amount;

        for(var i = Slots.Count - 1; i >= 0; i--)
        {
            if (Slots[i].transform.childCount > 0)
            {
                if (Slots[i].transform.GetChild(0).name == name + "(Clone)" && count !=0)
                {
                    Destroy(Slots[i].transform.GetChild(0).gameObject);
                    count -= 1;
                }

            }


        }
        Calculate();
        CraftingSystem.instance.RefreshItems();
    }

    public void Calculate()
    {
        Items.Clear();

        foreach(GameObject slot in Slots)
        {
            if (slot.transform.childCount > 0)
            {
                string name = slot.transform.GetChild(0).name;
          
                string string1 = "(Clone)";
                string result = name.Replace(string1, "");
                Items.Add(result);
            }
        }
    }

    public int CountNumOfItem(string name)
    {
        int count = 0;
        foreach(string item in  Items)
        {
            if(item == name) count++;
        }
        return count;
    }

}
