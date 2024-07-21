using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody rb;
    private float leftBound = 7f;
    private float rightBound = 16f;
    private Vector3 direction = Vector3.right;
    

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
       
       
    }
    private void FixedUpdate()
    {
        Vector3 movement = direction * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
        if(rb.position.x < leftBound || rb.position.x > rightBound)
        {
            direction = -direction;
        }
    }
    
}
