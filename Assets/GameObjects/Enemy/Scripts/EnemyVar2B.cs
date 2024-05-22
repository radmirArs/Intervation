using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyVar2B : MonoBehaviour
{
    public List<Transform> patrolPoint;
    private NavMeshAgent _navMeshAgent;
    private int i;

    public GameObject player;
    public PickUpObject PickUp;
    private bool _isPlayerNoticed;
    public float viewAngle;
    public float viewDistance = 10f;

    [SerializeField] GameObject End_Scene;

    [SerializeField] GameObject Screamer;

    void Start()
    {
        InitComponentLinks();
        EnemyMoveForPointRandom();
    }

    void Update()
    {
        ControlRaycastEnemyUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }

    void ControlRaycastEnemyUpdate()
    {
        _isPlayerNoticed = false;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) <= viewAngle && direction.magnitude <= viewDistance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {

                    Debug.DrawLine(transform.position + Vector3.up, hit.point, Color.green);
                    _isPlayerNoticed = true;

                }
            }
        }

    }

    void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (PickUp.Is_alive == true)
            {
                PickUp.Is_alive = false;
                Death();
            }
            
        }

    }

    void Death()
    {
        Screamer.SetActive(true);
        Invoke("Set_End_Screen", 2);
    }
    void Set_End_Screen()
    {
        Screamer.SetActive(false);
        End_Scene.SetActive(true);
    }

    void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
                EnemyMoveForPointRandom();
        }
    }

    void EnemyMoveForPointRandom()
    {
        i = Random.Range(0, patrolPoint.Count);
        _navMeshAgent.destination = patrolPoint[i].position;
    }

    void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
