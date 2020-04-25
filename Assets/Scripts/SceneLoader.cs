using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " entered collision area");
        SceneManager.LoadScene(2);
    }
    
}
