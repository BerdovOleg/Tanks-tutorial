using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [SerializeField] GameObject _Explosion; //анимация взрыва
    [SerializeField] GameObject _BlWave; // ударная волна от взрыва
    //public string tagParrent; //
    [SerializeField] float damage = 5;
    [SerializeField] float bulletSpeed = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "PlayerBull")
        {
            if (collision.tag != "Player" & collision.tag != "Effects")
            {
                GameObject _explosion = Instantiate(_Explosion, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
                //GameObject _blWave = Instantiate(_BlWave, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
                Destroy(_explosion, 0.5f);
                Destroy(gameObject);
                //Destroy(collision.gameObject);
                if (collision.gameObject.GetComponent<HealthControl>())
                {
                    collision.gameObject.GetComponent<HealthControl>().takeDamage(damage);
                }
                
            }
        }
        if (gameObject.tag == "EnemyBull")
        {
            if (collision.tag != "Enemy" & collision.tag != "Effects")
            {
                GameObject _explosion = Instantiate(_Explosion, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
               // GameObject _blWave = Instantiate(_BlWave, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
                Destroy(_explosion, 0.5f);
                Destroy(gameObject);
                //Destroy(collision.gameObject);
                if (collision.gameObject.GetComponent<PlayerHealthControl>())
                {
                    collision.gameObject.GetComponent<PlayerHealthControl>().takeDamage(damage);
                }
                
            }
        }
        //if (collision.tag != "Effects")
        //{
        //    GameObject _explosion = Instantiate(_Explosion, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
        //    GameObject _blWave = Instantiate(_BlWave, new Vector2(collision.transform.position.x, collision.transform.position.y), Quaternion.identity);
        //    Destroy(_explosion, 0.5f);
        //    Destroy(gameObject);
        //    Destroy(collision.gameObject);
        //}
    }
}
