using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMover : MonoBehaviour
{
    private float moveSpeed =5.0f;
    private Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        
    }
}
