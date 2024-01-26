using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f; // Pr�dko�� ruchu gracza
    public Joystick joystick; // Tw�j skrypt joysticka
    private Rigidbody2D rb2d;
    private Vector2 lastPosition;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lastPosition = rb2d.position;
    }
    void Update()
    {
        // Pobierz wektor kierunku z joysticka
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical);

        // Normalizuj wektor kierunku, je�li jego d�ugo�� jest wi�ksza ni� 1
        // (to zapobiega szybszemu poruszaniu si� po skosie)
        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        // Oblicz now� pozycj� gracza
        Vector2 newPos = new Vector2(transform.position.x + direction.x * speed * Time.deltaTime,
                                      transform.position.y + direction.y * speed * Time.deltaTime);

        // Przesu� gracza do nowej pozycji
        transform.position = newPos;

        if (IsOutsideArea())
        {
            // Je�li gracz jest poza obszarem, przywr�� jego ostatni� pozycj� w obszarze
            rb2d.position = lastPosition;
        }
        else
        {
            // Je�li gracz jest w obszarze, zaktualizuj jego ostatni� pozycj�
            lastPosition = rb2d.position;
        }
    }

    bool IsOutsideArea()
    {
        // Sprawd�, czy gracz jest poza obszarem
        Collider2D groundCollider = Physics2D.OverlapCircle(rb2d.position, 0.1f, LayerMask.GetMask("ground"));
        if (groundCollider == null)
        {
            // Gracz jest poza obszarem
            return true;
        }
        else
        {
            // Gracz jest w obszarze
            return false;
        }
    }

}
