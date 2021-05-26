using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [Range(-1, 1)] [SerializeField] float Xspeed;
    [Range(-1, 1)] [SerializeField] float Yspeed;

    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        Xspeed = 0.1f;
        Destroy(gameObject,10f);
        direction = Vector2.right;
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = direction * Xspeed;
    }

    // Update is called once per frame
    void Update()
    {
       // GetComponent<Rigidbody2D>().AddForce(new Vector2(Xspeed, Yspeed), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);//Git Test
        }
        
    }
}
