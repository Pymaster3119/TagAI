using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InstanceManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != transform.parent && collision.transform.name.Contains("Player"))
        {
            manager.playerTagged();
        }
    }

    private void Update()
    {
        transform.localPosition = Vector3.zero;
    }
}
