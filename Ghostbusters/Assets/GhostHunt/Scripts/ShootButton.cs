using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    public bool isShooting = false;

    // Metoda wywo³ywana, gdy przycisk jest naciskany
    public void OnPointerDown(PointerEventData eventData)
    {
        isShooting = true;
    }

    // Metoda wywo³ywana, gdy przycisk jest zwalniany
    public void OnPointerUp(PointerEventData eventData)
    {
        isShooting = false;
    }
}
