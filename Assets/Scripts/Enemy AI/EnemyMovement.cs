using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    //Camera playerCam;
    private Renderer renderer;

    
    private bool spotPlayer;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        //playerCam = GetComponent<Camera>();
        spotPlayer = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spotPlayer) { nav.SetDestination(player.position); }
    }

    
    public void sightedEnemy()
    {
        spotPlayer = true;
    }
}
