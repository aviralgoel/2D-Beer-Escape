using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject gamePanel;
    public float speed = 2.5f;
    public float accel = 2f;
    float acc = 0f;
    private bool isGameWon = false;

  

    // Update is called once per frame
    void Update()
    {   if(isGameWon)
        {
            return;
        }
        if(Input.GetAxis("Horizontal")>0)
        {
            acc += accel;
            rb.velocity = new Vector2(speed + acc*Time.deltaTime, 0f);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            acc += accel;
            rb.velocity = new Vector2(-(speed+acc*Time.deltaTime), 0f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            acc += accel;
            rb.velocity = new Vector2(0f, -(acc * Time.deltaTime+speed));
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            acc += accel;
            rb.velocity = new Vector2(0f, speed+acc * Time.deltaTime);
        }
        if(Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = new Vector2(0f, 0f);
            acc = 0;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(0f, 0f);
            acc = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            gamePanel.SetActive(true);
            isGameWon = true;
            Debug.Log("Level Completed");
        }
        else
        {
            Debug.Log("Not Door");
        }
    }
}
