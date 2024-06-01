using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    private Player player;
    private Color color;
    private float intensity = 0.5f;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource= GetComponentInParent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if(GetComponent<Button>())
        {
            color = gameObject.GetComponent<Image>().color;
        }

        if (GetComponent<Slider>())
        {
            intensity = gameObject.GetComponent<Slider>().value;
        }
    }

    public void ChangeColor()
    {
        player.ChangeLightColor(color);
        Debug.Log("Color seleccionado:" + color.ToString());
        audioSource.Play();
    }

    public void ChangeIntensity()
    {
        intensity= gameObject.GetComponent<Slider>().value;
        player.ChangeLightIntensity(intensity);
        Debug.Log("Intensidad seleccionada:" + intensity.ToString());
    }
}
