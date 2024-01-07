using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    public static DayNightSystem instance { get; set; }


    public Light DirectLight;

    // 1 day in the game is 4 minutes
    public float DayDuration = 240.0f; 
    public int CurrentHour;
    float CurrentTimeOfDay = 1.0f;
    public int DaySurvived = 0;
    public List<SkyBoxTimeMapping> TimeMappings;


    
   

    
    void Update()
    {
        CurrentTimeOfDay += Time.deltaTime / DayDuration;
        CurrentTimeOfDay %= 1;
        //for change different sky boxes at different time
        CurrentHour = Mathf.FloorToInt(CurrentTimeOfDay * 24);
        DirectLight.transform.rotation = Quaternion.Euler(new Vector3((CurrentTimeOfDay * 360) - 90, 170, 0));

        UpdateSkybox();

        if (CurrentHour == 0.0f)
        {
            DaySurvived++;
        }
    }

    private void UpdateSkybox()
    {

        Material currentSkybox = null;
        foreach (SkyBoxTimeMapping mapping in TimeMappings)
        {

            if(CurrentHour == mapping.hour)
            {
                currentSkybox = mapping.skyboxMaterial;
                break;
            }
        }

        if(currentSkybox != null)
        {
            RenderSettings.skybox = currentSkybox;
        }
    }
}
[System.Serializable]
public class SkyBoxTimeMapping
{
    public string phaseName;
    public int hour;
    public Material skyboxMaterial;
}