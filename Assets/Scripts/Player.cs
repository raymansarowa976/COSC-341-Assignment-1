using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private float verticalInput;
    private float speed;
    private Rigidbody rigidBodyComponent;
    private bool isGrounded;
    private int coinsCount = 7;
    // Start is called before the first frame update
    
    public GameObject OurTextMesh;
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //check if space key is pressed down
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    //FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, verticalInput);
        rigidBodyComponent.velocity.Normalize();
        transform.Translate(rigidBodyComponent.velocity * speed * Time.deltaTime);
        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (jumpKeyWasPressed)
        {
            rigidBodyComponent.AddForce(Vector3.up * 12, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            Text.score++;
            coinsCount--;
            
        }
        if(other.gameObject.layer == 7)
        {
            Destroy(gameObject);
            EditorApplication.ExitPlaymode();
        }
        if(other.gameObject.layer == 8)
        {
            Destroy(gameObject);
            EditorApplication.ExitPlaymode();
        }
        if(coinsCount == 00){
            EditorApplication.ExitPlaymode();
        }
    }
}
