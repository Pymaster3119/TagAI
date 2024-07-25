using UnityEngine;
using System.Collections;

public class InstanceSpawner : MonoBehaviour
{
	public int instanceWidth;
	public int instanceHeight;
    public GameObject instance;

    private void Start()
    {
        for (int i = 0; i < instanceWidth; i++)
        {
            for (int j = 0; j < instanceHeight; j++)
            {
                Instantiate(instance, new Vector3(i * 150, j * 150, 0), transform.rotation);
            }
        }
    }
}

