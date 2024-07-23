using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public int mapSize;
    public int minLength;
    public int maxLength;
    public int numberOfPlatforms;
    public List<GameObject> tiles;


    private void Awake()
    {
        createMap();
    }
    // Update is called once per frame
    public void createMap()
    {
        foreach (GameObject curr in tiles)
            Destroy(curr);
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            GameObject curr = Instantiate(tilePrefab, transform);
            curr.transform.localPosition = new Vector3(Random.Range(-mapSize, mapSize), Random.Range(-mapSize + 10, mapSize - 10));
            curr.GetComponent<SpriteRenderer>().size = new Vector2(Random.Range(minLength, maxLength), 1);
            tiles.Add(curr);
        }
    }
}
