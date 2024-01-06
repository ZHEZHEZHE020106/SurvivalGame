using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{

    public GameObject Player;
    public Camera PlayerCamera;
    public Transform AttackOrigin;
    public float AttackDamage = 10;
    public float AttackRange = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackCalculate();
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayOrigin = PlayerCamera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            
            if (Physics.Raycast(rayOrigin, PlayerCamera.transform.forward, out hit, AttackRange)) 
            {
                var selectionTransform = hit.transform;
                if (selectionTransform.GetComponent<InteractableCreatures>())
                {
                    selectionTransform.GetComponent<EnemyStatus>().Health -= Player.GetComponent<PlayerAttack>().AttackDamage;
                    MusicManager.Instance.PlayAttackSound();

                }

            }

        }

    }

    private void AttackCalculate()
    {
        
        //If player is equipping a weapon
        if (EquipSystem.Instance.WeaponSlot.transform.childCount != 0) 
        {
            string WeaponName = EquipSystem.Instance.WeaponSlot.transform.GetChild(0).name;
            string string1 = "(Clone)";
            string result = WeaponName.Replace(string1, "");
            if (result == "Mushroom")
            {
                AttackDamage = 12;
            }
            else if (result == "Wooden")
            {
                AttackDamage = 14;
            }
            else if (result == "IronSpear")
            {
                AttackDamage = 16;
            }
            else if (result == "IronSword")
            {
                AttackDamage = 20;
            }
        }

    }


}
