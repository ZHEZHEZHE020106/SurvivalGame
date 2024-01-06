using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager Instance { get; set; }
    public AudioSource BGM;
    public AudioSource CraftItemSound;
    public AudioSource AttackSound;
    public float Volume = 0.50f;
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
