using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [Range(-1, 1)] [SerializeField] float Xspeed;
    [Range(-1, 1)] [SerializeField] float Yspeed;

    [SerializeField] private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,10f);        
    }
    private void FixedUpdate()
    {
               
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);//Git Test
            Destroy(collision.gameObject);
        }
        
    }
}
