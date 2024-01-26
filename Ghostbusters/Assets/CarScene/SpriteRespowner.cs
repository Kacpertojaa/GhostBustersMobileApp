using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRespowner : MonoBehaviour
{
    public GameObject exitDoorPrefab; // Prefab drzwi wyj�ciowych

    void Start()
    {
        // Wywo�aj metod� "RespawnExitDoor" po 10 sekundach
        Invoke("RespawnExitDoor", 10f);
    }

    void RespawnExitDoor()
    {
        // Wy��cz obecny sprite
        gameObject.SetActive(false);

        // Stw�rz nowy obiekt drzwi wyj�ciowych
        Instantiate(exitDoorPrefab, transform.position, Quaternion.identity);
    }
}
