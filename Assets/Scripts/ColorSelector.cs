using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSelector : MonoBehaviour
{
    private Player player;
    private Color color;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        color = gameObject.GetComponent<Image>().color;
    }

    public void ChangeColor()
    {
        player.ChangeLightColor(color);
    }
}
