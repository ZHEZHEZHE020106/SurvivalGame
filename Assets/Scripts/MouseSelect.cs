using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            if (selectionTransform.GetComponent<InteractableCreatures>())
            {
                if (Vector3.Distance(selectionTransform.position,Player.transform.position) < Player.GetComponent<PlayerAttack>().AttackRange && Input.GetMouseButtonDown(0))
                {
                    selectionTransform.GetComponent<EnemyStatus>().Health -= Player.GetComponent<PlayerAttack>().AttackDamage;
                }

            }
        }
    }
}
