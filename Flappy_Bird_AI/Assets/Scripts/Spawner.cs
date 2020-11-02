using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;

    private int pipePoolSize = 5;
    private float spawnRate = 2.5f;
    private float pipeMin = -2.0f;
    private float pipeMax = 2.0f;

    public GameObject[] pipeList;
    public int currentIndex=0;

    private float xPos = 10.0f;
    private Vector2 initPos = new Vector2(-15,-25);

    public float timer=0 ;

    private void Start()
    {
        pipeList = new GameObject[pipePoolSize];

        for (int i = 0; i < pipePoolSize; i++)
        {
            pipeList[i] = (GameObject)Instantiate(pipePrefab, initPos, Quaternion.identity);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if ( timer >= spawnRate)
        {
            timer = 0f;

            float yPos = Random.Range(pipeMin, pipeMax);
            pipeList[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;
            if (currentIndex >= pipePoolSize)
            {
                currentIndex = 0;
            }
        }
    }
}
