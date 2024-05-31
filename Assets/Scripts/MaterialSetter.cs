using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialSetter : MonoBehaviour
{
    [SerializeField] Material[] mats;
    private Material[] temp;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        mats = GetComponent<MeshRenderer>().materials;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(gameObject.tag))

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
            else
            {
                temp[0] = mats[0];
            }

            collision.gameObject.GetComponent<MeshRenderer>().materials = temp;
        }
    }
}
