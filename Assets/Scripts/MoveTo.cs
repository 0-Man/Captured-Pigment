using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
    //scripted 4/20
    //mp
{
    private NavMeshAgent navMesh;

    public GameObject player;
 
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        //Below we get the posiiton of the game object witht he tag "player" 
        player = GameObject.FindGameObjectWithTag("Player");
    }

     

    void Update()
    {
        //Set the nav agent to go to the destination previously declared in the start function
        //navMesh.SetDestination(player.position);

    }

}
