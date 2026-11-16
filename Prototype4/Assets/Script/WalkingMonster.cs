using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class WalkingMonster : MonoBehaviour
{
    GameObject player;

    NavMeshAgent Agent;

    BoxCollider boxCollider;

    [SerializeField] LayerMask groundLayer, playerLayer;

    //patrol
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float range;

    //state change
    [SerializeField] float sightRange, atkRange;
    bool playerInSight, playerInAtkRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player");
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAtkRange = Physics.CheckSphere(transform.position, atkRange, playerLayer);

        if (!playerInSight && !playerInAtkRange) 
        {
            Patrol();   
        }

        else if (playerInSight && playerInAtkRange) 
        {
            Chase();
        }

        else if (!playerInSight && playerInAtkRange)
        {
            Attack();
        }
    }

    void Chase()
    {
        Agent.SetDestination(player.transform.position);
    }

    void Attack()
    {
        Agent.SetDestination(transform.position);
        SceneManager.LoadScene("EndScene");
    }

    void Patrol()
    {
        if (!walkpointSet) SearchForDest();
        if (walkpointSet) Agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 10) walkpointSet = false;
    }

    void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }

    void EnableAtk()
    {
       boxCollider.enabled = true; 
    }

    void DisableAtk()
    {
        boxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
