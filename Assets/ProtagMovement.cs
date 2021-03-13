using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagMovement : MonoBehaviour {
    private float speed = 10.0f;
    Rigidbody2D rigidbod;

    // Start is called before the first frame update
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbod.position += Vector2.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbod.position += Vector2.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbod.AddForce(new Vector2(0,2), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbod.position += Vector2.down * speed * Time.deltaTime;
        }
        
    }
    private void Awake()
    {
        rigidbod = GetComponent<Rigidbody2D>();   
    }
}
