using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int DMG = 20;
    public float speed = 19.0f;
    public Rigidbody2D rb;
    public GameObject impackEfect;
    // Update is called once per frame
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        Ghost enamy = collision.GetComponent<Ghost>();
        if (enamy != null) 
        {
            enamy.TakeDamage(DMG);
        }
        Instantiate(impackEfect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
