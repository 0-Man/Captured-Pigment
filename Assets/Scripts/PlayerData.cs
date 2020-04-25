using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = 3;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            playerHealth -= 1;
    }

}
