using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private string TagPlayer;
    [SerializeField] private float SpeedCam;


    private void Awake()
    {
        if (PlayerTransform == null)
        {
            if (TagPlayer == "")
            {
                TagPlayer = "Player";
            }

            PlayerTransform = GameObject.FindGameObjectWithTag(TagPlayer).transform;
        }


        transform.position = new Vector3()
        {
            x = PlayerTransform.position.x,
            y = PlayerTransform.position.y,
            z = PlayerTransform.position.z - 10,
        };
    }

    private void Update()
    {
        if (PlayerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = PlayerTransform.position.x,
                y = PlayerTransform.position.y,
                z = PlayerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, SpeedCam * Time.deltaTime);

            transform.position = pos;
        }
    }

}
