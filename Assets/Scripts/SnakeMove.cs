using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SnakeMove : MonoBehaviour
{
    private NavMeshAgent snake;

    public GameObject player;

    void Start()
    {
        snake = GetComponent<NavMeshAgent>();
        
    }

    void Update()
    {
        Vector3 target = player.transform.position;

        snake.SetDestination(target);
    }
}
