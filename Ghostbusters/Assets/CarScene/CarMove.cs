using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speed = 5f; // Prêdkoœæ ruchu gracza
    public Joystick joystick; // Twój skrypt joysticka
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

        // Normalizuj wektor kierunku, jeœli jego d³ugoœæ jest wiêksza ni¿ 1
        // (to zapobiega szybszemu poruszaniu siê po skosie)
        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        // Oblicz now¹ pozycjê gracza
        Vector2 newPos = new Vector2(transform.position.x + direction.x * speed * Time.deltaTime,
                                      transform.position.y + direction.y * speed * Time.deltaTime);

        // Przesuñ gracza do nowej pozycji
        transform.position = newPos;

        if (IsOutsideArea())
        {
            // Jeœli gracz jest poza obszarem, przywróæ jego ostatni¹ pozycjê w obszarze
            rb2d.position = lastPosition;
        }
        else
        {
            // Jeœli gracz jest w obszarze, zaktualizuj jego ostatni¹ pozycjê
            lastPosition = rb2d.position;
        }
    }

    bool IsOutsideArea()
    {
        // SprawdŸ, czy gracz jest poza obszarem
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
