using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    
    public Slider slider; 
    public GameObject player;
    private float MaxFood;
    private float CurrentFood;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentFood = player.GetComponent<PlayerStatus>().CurrentFood;
        MaxFood = player.GetComponent<PlayerStatus>().MaxFood;

        float BarValue = CurrentFood / MaxFood;
        slider.value = BarValue;
    }
}
