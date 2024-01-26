using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRespowner : MonoBehaviour
{
    public GameObject exitDoorPrefab; // Prefab drzwi wyjœciowych

    void Start()
    {
        // Wywo³aj metodê "RespawnExitDoor" po 10 sekundach
        Invoke("RespawnExitDoor", 10f);
    }

    void RespawnExitDoor()
    {
        // Wy³¹cz obecny sprite
        gameObject.SetActive(false);

        // Stwórz nowy obiekt drzwi wyjœciowych
        Instantiate(exitDoorPrefab, transform.position, Quaternion.identity);
    }
}
