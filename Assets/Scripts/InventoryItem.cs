using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private GameObject itemInfoUI;
    private TextMeshProUGUI itemInfoUI_itemName;
    private TextMeshProUGUI itemInfoUI_itemFunctionality;
    public string thisName, thisFunctionality;

    public bool Comsumable;
    public bool Equippable;
    public bool isWeapon;
    public bool isHelmet;
    public bool isArmor;
    public bool isBoot;
    public bool isGlove;
    private GameObject ChosenItem;

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

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemInfoUI.SetActive(true);
        itemInfoUI_itemName.text = thisName;
        itemInfoUI_itemFunctionality.text = thisFunctionality;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfoUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ChosenItem = gameObject;
        if (Comsumable)
        {
            
            Consuming(HealthEffect, EnergyEffect, FoodEffect);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if(Comsumable && ChosenItem == gameObject)
            {
                DestroyImmediate(gameObject);
                InventorySystem.Instance.Calculate();
                CraftingSystem.instance.RefreshItems();
            }
            else if(Equippable && ChosenItem == gameObject)
            {
                if (isWeapon)
                {
                    EquipSystem.Instance.EquippingWeapon(ChosenItem);
                    
                    InventorySystem.Instance.Calculate();
                }
                else if(isHelmet)
                {
                    EquipSystem.Instance.EquippingHelmet(ChosenItem);
                }
                else if (isArmor)
                {
                    EquipSystem.Instance.EquippingArmor(ChosenItem);
                }
                else if (isBoot)
                {
                    EquipSystem.Instance.EquippingBoot(ChosenItem);
                }
                else if (isGlove)
                {
                    EquipSystem.Instance.EquippingGlove(ChosenItem);
                }
            }
        }
        else if(eventData.button == PointerEventData.InputButton.Middle)
        {
            if(ChosenItem == gameObject)
            {
                InventorySystem.Instance.trashAlertUI.SetActive(true);
            }
             
        }
    }

    private void Consuming(float HealthEffect, float EnergyEffect, float FoodEffect)
    {
        itemInfoUI.SetActive(false);
        HealthEffectCalculation(HealthEffect);
        EnergyEffectCalculation(EnergyEffect);
        FoodEffectCalculation(FoodEffect);
    }

    private static void HealthEffectCalculation(float HealthEffect)
    {
        float CurrentHealth = PlayerStatus.Instance.CurrentHealth;
        float MaxHealth = PlayerStatus.Instance.MaxHealth;

        if(HealthEffect != 0)
        {
            if((CurrentHealth + HealthEffect) > MaxHealth)
            {
                PlayerStatus.Instance.SetHealth(MaxHealth);
            }
            else
            {
                PlayerStatus.Instance.SetHealth(CurrentHealth +  HealthEffect);
            }
        }
    }

    private static void EnergyEffectCalculation(float EnergyEffect)
    {
        float CurrentEnergy = PlayerStatus.Instance.CurrentEnergy;
        float MaxEnergy = PlayerStatus.Instance.MaxEnergy;

        if (EnergyEffect != 0)
        {
            if ((CurrentEnergy + EnergyEffect) > MaxEnergy)
            {
                PlayerStatus.Instance.SetEnergy(MaxEnergy);
            }
            else
            {
                PlayerStatus.Instance.SetHealth(CurrentEnergy + EnergyEffect);
            }
        }
    }

    private static void FoodEffectCalculation(float FoodEffect)
    {
        float CurrentFood = PlayerStatus.Instance.CurrentFood;
        float MaxFood = PlayerStatus.Instance.MaxFood;

        if (FoodEffect != 0)
        {
            if ((CurrentFood + FoodEffect) > MaxFood)
            {
                PlayerStatus.Instance.SetFood(MaxFood);
            }
            else
            {
                PlayerStatus.Instance.SetFood(CurrentFood + FoodEffect);
            }
        }
    }

    void Start()
    {
        itemInfoUI = InventorySystem.Instance.InventoryInfoUI;
        itemInfoUI_itemName = itemInfoUI.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemInfoUI_itemFunctionality = itemInfoUI.transform.Find("Functionality").GetComponent <TextMeshProUGUI>();

        Button YesBTN = InventorySystem.Instance.trashAlertUI.transform.Find("Yes").GetComponent<Button>();
        YesBTN.onClick.AddListener(delegate { DeleteItem(); });

        Button NoBTN = InventorySystem.Instance.trashAlertUI.transform.Find("No").GetComponent<Button>();
        NoBTN.onClick.AddListener(delegate { CancelDeletion(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CancelDeletion()
    {
        InventorySystem.Instance.trashAlertUI.SetActive(false);
    }

    private void DeleteItem()
    {

        DestroyImmediate(ChosenItem);
        InventorySystem.Instance.Calculate();
        CraftingSystem.instance.RefreshItems();
        InventorySystem.Instance.trashAlertUI.SetActive(false);
    }



}
