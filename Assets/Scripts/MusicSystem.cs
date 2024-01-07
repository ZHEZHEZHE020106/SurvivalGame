using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager Instance { get; set; }

    //BGM
    public AudioSource BGM;

    //Sound Effects
    public AudioSource CraftItemSound;
    public AudioSource AttackSound;

    //BGM volume
    public float Volume = 0.50f;

    //Setting
    public Slider VolumeSlider;
    public void Awake()
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

    
    public void PlayCraftItemSound()
    {
        CraftItemSound.Play();
    }

    public void PlayAttackSound()
    {
        AttackSound.Play();
    }

    public void ChangeVolume(float volume)
    {
        BGM.volume = volume;
        
    }
}
