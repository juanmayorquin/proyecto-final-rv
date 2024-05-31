using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomIdentifier : MonoBehaviour
{
    [SerializeField] private int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().actualRoomId = id;
            other.GetComponent<Player>().RefreshLightsPresence();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().actualRoomId = 5;
            other.GetComponent<Player>().ClearLights();
        }
    }
}
