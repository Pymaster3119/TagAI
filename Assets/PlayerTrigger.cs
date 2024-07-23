using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public InstanceManager manager;
    public GameObject otherPlayer;
    public bool tagged = false;
    private void Update()
    {
        print((transform.position - otherPlayer.transform.position).magnitude);
        if (!tagged&&(transform.position - otherPlayer.transform.position).magnitude < 1.1f)
        {
            manager.playerTagged();
            tagged = true;
        }
        else if ((transform.position - otherPlayer.transform.position).magnitude > 1.1f)
        {
            tagged = false;
        }
        transform.localPosition = Vector3.zero;
    }
}
