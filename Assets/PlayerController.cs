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
        bool ableToJump = Physics2D.Raycast(transform.position - new Vector3(-1.4f, 0), Vector2.down, distance: 1.6f, layerMask: mask).transform != null || Physics2D.Raycast(transform.position - new Vector3(1.4f, 0), Vector2.down, distance: 1.6f, layerMask: mask).transform != null;
        if (jumpPressed && ableToJump)
        {
            forceVector.y = jumpForce;
        }

        rb.AddForce(forceVector);
    }
}
