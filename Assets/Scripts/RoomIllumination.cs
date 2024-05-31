using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIllumination : MonoBehaviour
{
    public int id;
    public float defaultIntensity;
    private Light lightRef;
    [SerializeField] private GameObject lamp;

    private void Start()
    {
        lightRef = GetComponent<Light>();
        defaultIntensity = lightRef.intensity;
    }

    private void Update()
    {
        if (lightRef != null && lamp != null)
        {
            if (lightRef.intensity > 0)
            {
                lamp.SetActive(true);
            }
            else
            {
                lamp.SetActive(false);
            }
        }
    }
}
