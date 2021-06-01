using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScipt : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Direction = Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Flipx(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Flipx(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Flipx(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Flipx(3);
        }
    }

    private void Flipx(int i)
    {

        if (i == 0)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            Direction = Vector2.up;
        }
        else if (i == 1)
        {
            transform.rotation = Quaternion.AngleAxis(180, Vector3.forward);
            Direction = Vector2.down;
        }
        else if (i == 2)
        {
            transform.rotation = Quaternion.AngleAxis(-90, Vector3.forward);
            Direction = Vector2.right;
        }
        else if (i == 3)
        {
            transform.rotation = Quaternion.AngleAxis(90, Vector3.forward);
            Direction = Vector2.left;
        }
    }   

    void OnGUI()
    {
        
         GUI.Label(new Rect(25, 25, 200, 40), "Direction: " + Direction);
    }
}
