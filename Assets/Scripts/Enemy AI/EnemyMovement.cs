using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent nav;
    //Camera playerCam;

    
    private bool spotPlayer;

    public float damageAmount = 10f;
    public float damageTime = 0.5f; //How often you want to damage to be done to the player
                                    //change to 0.25f for every quarter second/0.5f for half
    [SerializeField]
    private float currentDamageTime;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        //if (hit.gameObject.layer == 11)
        {
            currentDamageTime += Time.deltaTime;
            if (currentDamageTime > damageTime)
            {
                PlayerUI.instance.TakeDamage(damageAmount);
                currentDamageTime = 0.0f;
                //Debug.Log("enemy hit");
            }
        }
    }
}
