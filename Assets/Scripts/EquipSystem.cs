using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipSystem : MonoBehaviour
{
    public static EquipSystem Instance { get; set; }

    // -- UI -- //
    public GameObject EquipSlots;
    public GameObject WeaponSlot;
    public GameObject HelmetSlot;
    public GameObject ArmorSlot;
    public GameObject BootSlot;
    public GameObject GloveSlot;
    public List<GameObject> EquipSlotsList = new List<GameObject>();
    public List<string> itemList = new List<string>();


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


    private void Start()
    {
        PopulateSlotList();
    }

    private void PopulateSlotList()
    {
        foreach (Transform child in EquipSlots.transform)
        {
            if (child.CompareTag("QuickSlot"))
            {
                EquipSlotsList.Add(child.gameObject);
            }
        }
    }

    public void EquippingWeapon(GameObject itemToEquip)
    {
        if (WeaponSlot.transform.childCount != 0)
        {
            string name = WeaponSlot.transform.GetChild(0).name;

            string string1 = "(Clone)";
            string result = name.Replace(string1, "");
            InventorySystem.Instance.AddToInventory(result);
            Destroy(WeaponSlot.transform.GetChild(0).gameObject);
            
        }
        
        itemToEquip.transform.SetParent(WeaponSlot.transform,false);
        
    }

    public void EquippingHelmet(GameObject itemToEquip)
    {
        if (HelmetSlot.transform.childCount != 0)
        {
            string HoldingItem = HelmetSlot.transform.GetChild(0).name;
            string string1 = "(Clone)";
            string result = name.Replace(string1, "");
            DestroyImmediate(HelmetSlot.transform.GetChild(0));

            itemToEquip.transform.SetParent(HelmetSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);
            InventorySystem.Instance.AddToInventory(result);

        }
        else
        {

            itemToEquip.transform.SetParent(HelmetSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);

        }
        InventorySystem.Instance.Calculate();
    }

    public void EquippingArmor(GameObject itemToEquip)
    {
        if (ArmorSlot.transform.childCount != 0)
        {
            string HoldingItem = ArmorSlot.transform.GetChild(0).name;
            string string1 = "(Clone)";
            string result = name.Replace(string1, "");
            DestroyImmediate(ArmorSlot.transform.GetChild(0));

            itemToEquip.transform.SetParent(ArmorSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);
            InventorySystem.Instance.AddToInventory(result);

        }
        else
        {

            itemToEquip.transform.SetParent(ArmorSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);

        }
        InventorySystem.Instance.Calculate();
    }

    public void EquippingBoot(GameObject itemToEquip)
    {
        if (BootSlot.transform.childCount != 0)
        {
            string HoldingItem = BootSlot.transform.GetChild(0).name;
            string string1 = "(Clone)";
            string result = name.Replace(string1, "");
            DestroyImmediate(BootSlot.transform.GetChild(0));

            itemToEquip.transform.SetParent(BootSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);
            InventorySystem.Instance.AddToInventory(result);

        }
        else
        {

            itemToEquip.transform.SetParent(BootSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);

        }
        InventorySystem.Instance.Calculate();
    }

    public void EquippingGlove(GameObject itemToEquip)
    {
        if (GloveSlot.transform.childCount != 0)
        {
            string HoldingItem = GloveSlot.transform.GetChild(0).name;
            string string1 = "(Clone)";
            string result = name.Replace(string1, "");
            DestroyImmediate(GloveSlot.transform.GetChild(0));

            itemToEquip.transform.SetParent(GloveSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);
            InventorySystem.Instance.AddToInventory(result);

        }
        else
        {

            itemToEquip.transform.SetParent(GloveSlot.transform);
            InventorySystem.Instance.RemoveItem(itemToEquip.name, 1);

        }
        InventorySystem.Instance.Calculate();
    }
}
