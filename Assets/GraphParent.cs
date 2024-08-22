using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphParent : MonoBehaviour
{
    public GraphPlotter playerrewardsplotter;
    public GraphPlotter timewithplayer2plotter;
    public static List<float> playerrewards;
    public static List<float> timewithplayer2;
    // Start is called before the first frame update
    void Start()
    {
        playerrewards = new List<float>();
        timewithplayer2 = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        playerrewardsplotter.values = playerrewards.ToArray();
        timewithplayer2plotter.values = timewithplayer2.ToArray();
    }
}
