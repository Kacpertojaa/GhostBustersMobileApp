using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float directionChangeInterval = 1f;
    public int HP = 100;
    public GameObject minBoundsObject; // GameObject reprezentuj¹cy dolny lewy róg obszaru
    public GameObject maxBoundsObject; // GameObject reprezentuj¹cy górny prawy róg obszaru

    public GameObject dieEfect;
    private Rigidbody2D rb;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = directionChangeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeDirection();
            timer = directionChangeInterval;
        }
    }
    void LateUpdate()
    {
        // SprawdŸ, czy duch jest w granicach obszaru
        Vector2 position = transform.position;
        Vector2 minBounds = minBoundsObject.transform.position;
        Vector2 maxBounds = maxBoundsObject.transform.position;
        position.x = Mathf.Clamp(position.x, minBounds.x, maxBounds.x);
        position.y = Mathf.Clamp(position.y, minBounds.y, maxBounds.y);
        transform.position = position;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(dieEfect, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
    void ChangeDirection()
    {
        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        Vector2 direction = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        rb.velocity = direction * moveSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle + 180, Vector3.forward);
    }
}
