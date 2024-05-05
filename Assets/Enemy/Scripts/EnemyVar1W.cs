using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyVar1W : MonoBehaviour
{
    public float distanceToDeath = 0f;
    public List<Transform> patrolPoint;
    private NavMeshAgent _navMeshAgent;
    private int i;

    public GameObject player;
    private bool _isPlayerNoticed;
    public float viewAngle;

    void Start()
    {
        InitComponentLinks();
        EnemyMoveForPointRandom();
    }

    void Update()
    {
        PlayerContactCheckUpdate();
        ControlRaycastEnemyUpdate();
        ChaseUpdate();
        PatrolUpdate();
    }
    void PlayerContactCheckUpdate()
    {
        var direction = player.transform.position - transform.position;
        if (direction.x <= distanceToDeath && direction.y <= distanceToDeath && direction.z <= distanceToDeath)
        {
            Debug.Log("Сцена смерти");
            //заглушка
            //SceneManager.LoadScene("Game_End_Scene");
        }
    }

    void ControlRaycastEnemyUpdate()
    {
        _isPlayerNoticed = false;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) <= viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {

                if (hit.collider.gameObject == player.gameObject)
                    _isPlayerNoticed = true;
            }
        }
    }

    void ChaseUpdate()
    {
        if (_isPlayerNoticed)
            _navMeshAgent.destination = player.transform.position;
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
