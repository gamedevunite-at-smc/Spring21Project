using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    [SerializeField] private float speed = 10.0f;
    
    private new Rigidbody2D rigidbody;

    private BulletSystem bulletSystem;

    // Start is called before the first frame update
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidbody.position += Vector2.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidbody.position += Vector2.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody.position += Vector2.up * speed * Time.deltaTime;
            //rigidbod.AddForce(new Vector2(0,2), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody.position += Vector2.down * speed * Time.deltaTime;
        }
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletSystem.StartShooting();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            bulletSystem.StopShooting();
        }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();   
    }
}
