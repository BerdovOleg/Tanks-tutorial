using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [SerializeField] GameObject _Explosion;

    [SerializeField] GameObject _BlWave;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {            
               GameObject _explosion =  Instantiate(_Explosion,new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
               GameObject _blWave = Instantiate(_BlWave, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
               Destroy(_explosion, 0.5f);
               Destroy(gameObject);
               Destroy(collision.gameObject);
        }
        
    }
}
