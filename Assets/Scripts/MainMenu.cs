using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script created by Jessie Klimala
// Last edited on 4/20/20

public class MainMenu : MonoBehaviour

{
    public void playGame()
    // This allows us to load the scene when clicking the play button
    {
        SceneManager.LoadScene("Town");
    }

    public void quitGame()
    // This allows us to quit the game after hitting the quit button
    {
        Debug.Log("Quit");
        Application.Quit();
    }









}
