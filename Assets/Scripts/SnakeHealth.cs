using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    int health = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            health = health - 1;
    }
    // Update is called once per frame

    void Update()
    {

        if (health >= 0)
            Destroy(GameObject.FindGameObjectWithTag("Snake"));

    }
}

