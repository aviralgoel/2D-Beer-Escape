using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        min = transform.position.x;
        max = transform.position.x + 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time*speed, max - min) + min, transform.position.y, transform.position.z);
    }
}
