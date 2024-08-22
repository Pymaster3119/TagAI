using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
public class PlayerAgent : Agent
{
    public InstanceManager manager;
    public PlayerController controller;
    public int timestep;
    public TextMesh rewardmesh;

    public override void OnEpisodeBegin()
    {
        rewardmesh.text = "Player reward: 0";
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        RenderTexture.active = manager.cameraTexture;
        Texture2D tempTexture = new Texture2D(manager.cameraTexture.width, manager.cameraTexture.height, TextureFormat.RGB24, false);
        tempTexture.ReadPixels(new Rect(0, 0, manager.cameraTexture.width, manager.cameraTexture.height), 0, 0);
        tempTexture.Apply();

        for (int y = 0; y < manager.cameraTexture.height; y++)
        {
            for (int x = 0; x < manager.cameraTexture.width; x++)
            {
                Color pixelColor = tempTexture.GetPixel(x, y);
                sensor.AddObservation(pixelColor.r);
                sensor.AddObservation(pixelColor.g);
                sensor.AddObservation(pixelColor.b);
            }
        }
        RenderTexture.active = null;
        Destroy(tempTexture);
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;
        discreteActions[0] = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        discreteActions[1] = Input.GetKey(KeyCode.Space)? 1 : 0;
        
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        var discreteActions = actions.DiscreteActions;
        controller.horizontalAxis = discreteActions[0];
        controller.jumpPressed = discreteActions[1] == 0;

        //Small reward if it is tagged that scales towards the end of the round
        if (manager.playerOneTagged == (manager.player1agent==this))
        {
            AddReward(-(int)Math.Pow(2, timestep));
            timestep++;
        }

        //Update display
        rewardmesh.text = "Player reward: " + GetCumulativeReward();
    }
}