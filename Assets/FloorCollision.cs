using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour
{
    public InstanceManager manager;
    public SpriteRenderer renderer;
    void Start()
    {
        int leftbound = Mathf.RoundToInt(transform.position.x - (renderer.size.x / 2 + 0.5f));
        int rightbound = Mathf.RoundToInt(leftbound + renderer.size.x - 1);

        int upbound = Mathf.RoundToInt(transform.position.x - (renderer.size.x / 2 + 0.5f));
        int downbound = Mathf.RoundToInt(upbound + renderer.size.x - 1);

        for (int x = leftbound + 50; x <= rightbound + 50; x++)
        {
            if (x >= 0 && x <= 100)
            {
                for (int y = downbound + 50; y <= upbound + 50; y++)
                {
                    if (y >= 0 && y <= 100)
                    {
                        manager.collisionMatrix[x, y] = true;
                    }
                }
            }
        }
    }
}
