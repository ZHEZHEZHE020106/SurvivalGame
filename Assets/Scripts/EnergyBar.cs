using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject player;
    private float MaxEnergy;
    private float CurrentEnergy;
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentEnergy = player.GetComponent<PlayerStatus>().CurrentEnergy;
        MaxEnergy = player.GetComponent<PlayerStatus>().MaxEnergy;

        float BarValue = CurrentEnergy / MaxEnergy;
        slider.value = BarValue;
    }
}
