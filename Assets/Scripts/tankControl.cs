using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    // конфигурация управления
    [Range(0, 100)] [SerializeField] float speed = 5f;
    float H;
    float V;
    [Range(0, 1)] [SerializeField] float step = 0.5f;
    Rigidbody2D shipRb;
    [SerializeField] bool DirectionX;
    [SerializeField] bool DirectionY;
    [SerializeField] Vector2 Direction;


    //конфигурация стрельбы
    [SerializeField] GameObject _bullet;
    [SerializeField] Transform _gunPOs;
    [Range(0,10)][SerializeField]float bullSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        shipRb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, 0);
        DirectionX = true;
        Direction = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");
        if (Input.GetAxis("Vertical")!=0)
        {
            ForwardVertical();
        }else
        ForwardHorizontal();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject bullet = Instantiate(_bullet, new Vector2(_gunPOs.position.x, _gunPOs.position.y), transform.rotation);
           Destroy(bullet, 10f);
            if (Direction == Vector2.up)
            {
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, bullSpeed), ForceMode2D.Impulse);
            }
            else if (Direction == Vector2.down)
            {
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -bullSpeed), ForceMode2D.Impulse);
            }
            else if (Direction == Vector2.left)
            {
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bullSpeed, 0f), ForceMode2D.Impulse);
            }
            else if (Direction == Vector2.right)
            {
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bullSpeed, 0f), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name + " : e");
    }

    private void ForwardHorizontal()
    {
        if (H !=0)
        {
            float h = 0f;
            if (H > 0)
            {
                h = transform.position.x + step;
                DirectionY = true;
                if (DirectionY)
                {
                    transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                    Direction = Vector2.right;
                }
            }
            if (H < 0)
            {
                h = transform.position.x - step;
                DirectionY = false;
                if (!DirectionY)
                {
                    transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                    Direction = Vector2.left;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(h, transform.position.y, 0f), Time.deltaTime * speed);
        }
    }

    private void ForwardVertical()
    {
        if (V != 0)
        {
            float v = 0f;
            if (V > 0)
            {
                v = transform.position.y + step;
                DirectionX = true;
                if (DirectionX)
                {
                    transform.rotation = Quaternion.AngleAxis(360, Vector3.forward);
                    Direction = Vector2.up;
                }
            }
            if (V < 0)
            {
                v = transform.position.y - step;
                DirectionX = false;
                if (!DirectionX)
                {
                    transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
                    Direction = Vector2.down;
                }
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, v, 0f), Time.deltaTime * speed);
        }
    }
}
