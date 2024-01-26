using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isJumping = false;

    // Metoda wywo�ywana, gdy przycisk jest naciskany
    public void OnPointerDown(PointerEventData eventData)
    {
        isJumping = true;
    }

    // Metoda wywo�ywana, gdy przycisk jest zwalniany
    public void OnPointerUp(PointerEventData eventData)
    {
        isJumping = false;
    }
}
