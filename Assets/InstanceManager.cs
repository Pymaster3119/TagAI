using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceManager : MonoBehaviour
{
    public bool playerOneTagged;
    bool alreadyTagged;
    public RenderTexture cameraTexture;
    public Camera aiCamera;
    public PlayerController player1, player2;
    public TileGenerator tileGenerator;

    public int maxTime;
    public float timer;

    public TextMesh timerMesh;

    public int index;
    public float timeWithPlayer2;

    public bool[,] collisionMatrix; 

    private void Awake()
    {
        collisionMatrix = new bool[100, 100];
        cameraTexture = new RenderTexture(200, 200, 32);
        aiCamera.targetTexture = cameraTexture;
    }

    public void Start()
    {
        player1.indicator.SetActive(playerOneTagged);
        player2.indicator.SetActive(!playerOneTagged);
    }
    public void playerTagged()
    {
        if (!alreadyTagged)
        {
            playerOneTagged = !playerOneTagged;
        }
        alreadyTagged = !alreadyTagged;
        player1.indicator.SetActive(playerOneTagged);
        player2.indicator.SetActive(!playerOneTagged);
    }

    private void OnDestroy()
    {
        Destroy(cameraTexture);
    }

    public void StartScene()
    {
        tileGenerator.createMap();
        player1.transform.localPosition = new Vector3(-15, 0, 0);
        player2.transform.localPosition = new Vector3(15, 0, 0);
        playerOneTagged = false;
        alreadyTagged = false;
        player1.indicator.SetActive(playerOneTagged);
        player2.indicator.SetActive(!playerOneTagged);
        timer = 0;
    }

    private void FixedUpdate()
    {
        timer += 0.02f;
        timerMesh.text = Mathf.FloorToInt(timer / 60) + ":" + Mathf.FloorToInt(timer % 60);
        timeWithPlayer2 += !playerOneTagged ? 0.02f : 0.0f;
        if (timer >= maxTime)
        {
            print("End timer!");
            timer = 0;
            timeWithPlayer2 = 0;
            StartScene();

        }
    }
}
