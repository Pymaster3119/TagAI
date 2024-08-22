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

    private void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 forceVector = Vector2.zero;
        bool ableToJump = Raycast(Vector2.down);
        bool notTopped = !Raycast(Vector2.up);
        bool ableToStrafe = !Raycast(new Vector2(horizontalAxis, 0));
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

        print("force vector" + forceVector);
        transform.Translate(forceVector);
        jumpCooldown += 0.05f;
    }

    bool Raycast(Vector2 direction)
    {
        Vector3 pos = transform.localPosition;
        int indexx = Mathf.RoundToInt(pos.x + direction.x) + 50;
        int indexy = Mathf.RoundToInt(pos.y + direction.y) + 50;
        try
        {
            return Mathf.Abs(indexx - 50) == 50 ||manager.collisionMatrix[indexx, indexy];
        }
        catch
        {
            return true;
        }
        
    }
}
