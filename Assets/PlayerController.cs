using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int force, jumpForce;
    public LayerMask mask;

    public GameObject indicator;

    public float horizontalAxis;
    public bool jumpPressed;

    float jumpCooldown = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //To Be Removed
        horizontalAxis = Input.GetAxis("Horizontal");
        jumpPressed = Input.GetKey(KeyCode.Space);
        //
        Vector2 forceVector = new Vector2(horizontalAxis * force, 0);
        bool ableToJump = Physics2D.Raycast(transform.position - new Vector3(-1.4f, 0), Vector2.down, distance: 1f, layerMask: mask).transform != null || Physics2D.Raycast(transform.position - new Vector3(1.4f, 0), Vector2.down, distance: 1f, layerMask: mask).transform != null;
        bool notTopped = Physics2D.Raycast(transform.position, Vector2.up, distance: 1f, layerMask: mask).transform == null;
        if (jumpPressed && ableToJump && notTopped)
        {
            forceVector.y = jumpForce;
            jumpCooldown = 0;
        }
        else if (jumpCooldown <= 1 && notTopped)
        {
            forceVector.y = jumpForce;
        }
        else if (!ableToJump && jumpCooldown >= 1)
        {
            forceVector.y = -jumpForce;
        }    

        transform.Translate(forceVector);
        jumpCooldown += 0.05f;
    }
}
