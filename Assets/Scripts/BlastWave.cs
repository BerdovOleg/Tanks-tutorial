using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CircleCollider2D collider2D;
    [Range(0,1)][SerializeField]float propagationSpeedf = 0.05f;

    private void Awake()
    {
        if (this.collider2D == null)
        {
            this.collider2D = GetComponent<CircleCollider2D>();
        } 
    }
    private void Start()
    {
        Destroy(gameObject, 0.4f);
    }
    private void Update()
    {
        
        this.collider2D.radius += propagationSpeedf;
    }
}
