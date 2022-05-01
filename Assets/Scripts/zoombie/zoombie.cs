using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoombie : MonoBehaviour
{
    public static zoombie instance;

    public float speed;

    private void Awake()
    {
        _makeInstance();
    }

    void _makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (birdController.instance != null)
        {
            if (birdController.instance.flag == 1)
            {
                Destroy(GetComponent<zoombie>());
            }
        }
        move();
    }

    void move()
    {
        Vector3 temp = transform.position;

        temp.x -= speed * 4 * Time.deltaTime;
        temp.y -= speed * 2 / 3 * Time.deltaTime;

        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "distroy")
        {
            Destroy(gameObject);
        }
    }

}

