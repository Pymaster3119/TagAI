using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int force, jumpForce;
    public LayerMask mask;

    public GameObject indicator;

    public int horizontalAxis;
    public bool jumpPressed;

    float jumpCooldown = 2;

    public InstanceManager manager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //To Be Removed
        horizontalAxis = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        jumpPressed = Input.GetKey(KeyCode.Space);
        //
        Vector2 forceVector = Vector2.zero;
        bool ableToJump = Raycast(Vector2.down);
        bool notTopped = !Raycast(Vector2.up);
        bool ableToStrafe = !Raycast(new Vector2(horizontalAxis, 0));

        print(ableToJump + "   " + notTopped + "   " + ableToStrafe);
        if (ableToStrafe)
        {
            forceVector.x = horizontalAxis;
        }    
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

    bool Raycast(Vector2 direction)
    {
        int indexx = Mathf.RoundToInt(transform.position.x + direction.x) + 50;
        int indexy = Mathf.RoundToInt(transform.position.y + direction.y) + 50;
        print(indexx + "    " + indexy);
        try
        {
            return !manager.collisionMatrix[indexx, indexy];
        }
        catch
        {
            return true;
        }
        
    }
}
