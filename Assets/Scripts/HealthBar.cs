using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    public GameObject player;
    private float MaxHealth;
    private float CurrentHealth;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.GetComponent<PlayerStatus>().CurrentHealth;
        MaxHealth = player.GetComponent<PlayerStatus>().MaxHealth;

        float BarValue = CurrentHealth / MaxHealth;
        slider.value = BarValue;
    }
}
