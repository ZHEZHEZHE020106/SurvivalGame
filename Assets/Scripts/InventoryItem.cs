using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public bool Comsumable;
    public GameObject ChosenItem;
    public float HealthEffect;
    public float EnergyEffect;
    public float FoodEffect;
    public void RemoveItemFromInventory()
    {
        if (Comsumable)
        {
            ChosenItem  = gameObject;
            Consuming(HealthEffect, EnergyEffect, FoodEffect);
            DestroyImmediate(ChosenItem);
            //InventorySystem.Instance.RemoveItemFromInventory(ChosenItem);
        }


    }

    private void Consuming(float HealthEffect, float EnergyEffect, float FoodEffect)
    {
        PlayerStatus.Instance.CurrentHealth += HealthEffect;
        PlayerStatus.Instance.CurrentEnergy += EnergyEffect;
        PlayerStatus.Instance.CurrentFood += FoodEffect;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
