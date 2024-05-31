using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int actualRoomId;

    [SerializeField] private Color lightColor;
    [SerializeField] private float lightIntensity;

    private Light[] lights;
    [SerializeField] private List<Light> actualRoomLights;

    private void Start()
    {
        lights = GameObject.FindObjectsOfType<Light>();
        lightColor = Color.white;
    }

    private void Update()
    {
        
    }

    public void ChangeLightColor(Color color)
    {
        lightColor = color;
        RefreshLightsColor();
    }

    public void ChangeLightIntensity(float intensity)
    {
        lightIntensity= intensity;
        RefreshLightsIntensity();
    }

    public void RefreshLightsPresence()
    {
        foreach (var light in lights)
        {
            if (light.gameObject.GetComponent<RoomIllumination>().id == actualRoomId)
            {
                actualRoomLights.Add(light);
            }
        }

        Debug.Log("Hay " + actualRoomLights.Count + " luces en la habitación");
    }

    public void RefreshLightsColor()
    {
        if (actualRoomLights.Count > 0)
        {
            foreach (Light light in actualRoomLights)
            {
                light.color = lightColor;
                Debug.Log("Se cambió el color a: " + lightColor);
            }
        }
    }

    public void RefreshLightsIntensity()
    {
        if (actualRoomLights.Count > 0)
        {
            foreach (Light light in actualRoomLights)
            {
                float defaultLightIntensity = light.GetComponent<RoomIllumination>().defaultIntensity;
                light.intensity = defaultLightIntensity * lightIntensity;
                Debug.Log("Se cambió la intensidad a: " + lightIntensity);
            }
        }
    }



    public void ClearLights()
    {
        actualRoomLights.Clear();
        RefreshLightsPresence();
    }
}
