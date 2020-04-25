using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Created by Jessie K
//Last edited 4/20/20 by Jessie K




public class LevelControl : MonoBehaviour
{
    static int playerHealth = 3; //Sets player's health

    private void OnTriggerEnter(Collider other)
    {
        // If the player hits the collider, then he gets brought to next scene -JAK
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Forest");
        }
    }


    void die()
    // when player dies, it loads the main menu
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {

        if (playerHealth <= 0)
        // when health reaches zero, player dies, and it reloads the game
        {
            die();
        }
    }
}
