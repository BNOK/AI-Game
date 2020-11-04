using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // obstacle parametres
    public GameObject obstacle;
    private Vector2 startPos = new Vector2(0,-100);
    private GameObject[] obstList;
    private int index=0;
    

    //scrolling speed 
    public float speed = 20;

    //spawn rate parametres
    public int spawnRate= 3;
    private float timer=0;
   

    //spawn parametres
    private float yPos;
    private float xPos = 60;
    public float yMin=-20;
    public float yMax=20;
    // Start is called before the first frame update
    void Start()
    {
        obstList = new GameObject[5];
        
        for (int i =0; i<5; i++)
        {
            obstList[i] = Instantiate(obstacle, startPos, Quaternion.identity);
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if ( timer>= spawnRate)
        {
            yPos = Random.Range(yMin, yMax);
            obstList[index].transform.position = new Vector2(xPos, yPos);
            index++;
            timer = 0;
        }
        

        if ( index == 5)
        {
            index = 0;
        }

        
    }
}
