using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    public InstanceManager manager;
    public SpriteRenderer renderer;
    void Start()
    {
        int leftbound = Mathf.RoundToInt(transform.position.x - (renderer.size.x / 2 + 0.5f) + 1);
        int rightbound = Mathf.RoundToInt(leftbound + renderer.size.x - 1);


        for (int x = leftbound + 50; x <= rightbound + 50; x++)
        {
            try
            { 
                manager.collisionMatrix[x, Mathf.RoundToInt(transform.position.y) + 50] = true;
            }
            catch
            {

            }
        }
    }
}
