using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int actualRoomId;

    [SerializeField] private Color lightColor;

    private Light[] lights;
    [SerializeField] private List<Light> actualRoomLights;

    private void Start()
    {
        lights = GameObject.FindObjectsOfType<Light>();
    }

    private void Update()
    {
        Debug.Log(lights.Length);
        Debug.Log(actualRoomLights.Count);
    }

    public void ChangeLightColor(Color color)
    {
        lightColor = color;
        RefreshLights();
    }

    public void RefreshLights()
    {
        foreach (var light in lights)
        {
            if (light.gameObject.GetComponent<RoomIllumination>().id == actualRoomId)
            {
                actualRoomLights.Add(light);
            }
        }

        if (actualRoomLights.Count > 0)
        {
            foreach (Light light in actualRoomLights)
            {
                light.color = lightColor;
            }
        }
    }

    public void ClearLights()
    {
        actualRoomLights.Clear();
    }
}
