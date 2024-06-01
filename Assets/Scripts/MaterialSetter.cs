using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    [SerializeField] Material[] mats;
    private Material[] temp;
    private Player player;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>().materials;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag) && !collision.gameObject.GetComponent<MaterialSetter>())

        {
            Debug.Log("Se entró en colisión con objeto de la misma clase");
            temp = collision.gameObject.GetComponent<MeshRenderer>().materials;

            if (collision.gameObject.CompareTag("Suelo"))
            {
                if(player.actualRoomId <= 3)
                {
                    temp[player.actualRoomId] = mats[0];
                }
            }
            if (collision.gameObject.CompareTag("Pared"))
            {
                foreach (var wall in GameObject.FindObjectsOfType<Wall>()) 
                {
                    if (wall.GetComponent<Wall>().id == player.actualRoomId)
                    {
                        wall.GetComponent<MeshRenderer>().materials = mats;
                    }
                }
            }
            else
            {
                temp[0] = mats[0];
            }

            audioSource.Play();
            collision.gameObject.GetComponent<MeshRenderer>().materials = temp;
        }
    }
}
