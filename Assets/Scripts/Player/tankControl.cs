using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankControl : MonoBehaviour
{
    // конфигурация управления
    [Range(0, 100)] [SerializeField] float _playerSpeed = 5f; //PlayersSpeed
    float H; //horizontal forward
    float V; //vertical forward
    [Range(0, 1)] [SerializeField] float step = 0.5f; //Player move step 
    Rigidbody2D shipRb; //Player RiggidBody

    [SerializeField] Vector2 Direction;//Current direction player


    //конфигурация стрельбы
    [SerializeField] GameObject _bullet; 
    [SerializeField] Transform[] _gunPOs;
    [Range(0,10)][SerializeField]float bullSpeed = 1f;

    //анимация и эфекты
    [SerializeField] GameObject tracks;
    [SerializeField] SpriteRenderer myBody; //Сhassis Sprite
    [SerializeField] SpriteRenderer[] myGun; //gun Sprites



    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<SpriteRenderer>();
        _gunPOs = GetGuns(); 

        for (int i = 0; i < _gunPOs.Length; i++)
        {
            myGun = _gunPOs[i].GetComponents<SpriteRenderer>();
        }
        shipRb = GetComponent<Rigidbody2D>();
        transform.Rotate(0, 0, 0);
        Direction = Vector2.up;
    }

    private Transform[] GetGuns()
    {
        GameObject[] guns = GameObject.FindGameObjectsWithTag("PlayerGun");
        Transform[] gunTransform = new Transform[guns.Length];
        for (int i = 0; i < guns.Length; i++)
        {
            gunTransform[i] = guns[i].transform;
        }
        return gunTransform;
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        if (Input.GetAxis("Vertical")!=0)
            ForwardVertical();
        else
            ForwardHorizontal();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _gunPOs.Length; i++)
            {
                GameObject bullet = Instantiate(_bullet, new Vector2(_gunPOs[i].position.x, _gunPOs[i].position.y), transform.rotation);
                Destroy(bullet, 10f);

                bullet.tag = "PlayerBull";

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

                //Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), this.GetComponent<Collider2D>()); 
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
                transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                Direction = Vector2.right;
               
            }
            if (H < 0)
            {
                h = transform.position.x - step;
                transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
                Direction = Vector2.left;
            }

            transform.position = Vector3.Lerp(transform.position, new Vector3(h, transform.position.y, 0f), Time.deltaTime * _playerSpeed);
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
                transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
                Direction = Vector2.up;
            }
            if (V < 0)
            {
                v = transform.position.y - step;
                transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
                Direction = Vector2.down;
            }
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, v, 0f), Time.deltaTime * _playerSpeed);
        }
    }
}
