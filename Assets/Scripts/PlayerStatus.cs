using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float MaxHealth = 100;
    public float CurrentHealth;
    public float MinHealth = 0;

    public float MaxEnergy = 100;
    public float CurrentEnergy;
    public float MinEnergy = 0;

    public float MaxFood = 2000;
    public float CurrentFood;
    public float MinFood = 0;

    public static PlayerStatus Instance { get; set; }

    public void SetHealth(float Health)
    {
        CurrentHealth = Health;
    }

    public void SetEnergy(float Energy)
    {
        CurrentEnergy = Energy;
    }

    public void SetFood(float Food)
    {
        CurrentFood = Food;
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

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
    }
    void Start()
    {
        CurrentHealth = MaxHealth;
        CurrentEnergy = MaxEnergy;
        CurrentFood = MaxFood;
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = player.GetComponent<PlayerMovement>().isWalking;
        bool isRunning = player.GetComponent<PlayerMovement>().isRunning;
        

        if (isRunning)
        {
            CurrentEnergy -= 20 * Time.deltaTime;
            CurrentFood -= 4 * Time.deltaTime;
        }
        else if (isWalking)
        {
            CurrentEnergy += 10 * Time.deltaTime;
            CurrentFood -= 2 * Time.deltaTime;
        }
        else
        {
            CurrentFood -= 1 * Time.deltaTime;
            CurrentEnergy += 10 * Time.deltaTime;
        }

        if (CurrentEnergy > MaxEnergy)
        {
            CurrentEnergy = MaxEnergy;
        }else if (CurrentEnergy < MinEnergy)
        {
            CurrentEnergy = MinEnergy;
        }

        if (CurrentFood > MaxFood)
        {
            CurrentFood = MaxFood;
        }else if (CurrentFood < MinFood)
        {
            CurrentFood = MinFood;
        }


        if (Input.GetKeyDown(KeyCode.H))
        {
            CurrentHealth -= 20;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CurrentEnergy -= 20;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentFood -= 20;
        }
    }

    
}
