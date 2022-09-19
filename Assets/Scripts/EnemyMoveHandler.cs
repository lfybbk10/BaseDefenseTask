using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMoveHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private bool _isMovingToPlayer;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_isMovingToPlayer)
        {
            _animator.SetBool("Running",true);
            _animator.SetBool("Walking",false);
            
            GameObject player = GameObject.FindWithTag("Player");
            _navMeshAgent.SetDestination(player.transform.position);
            
            Vector3 dir = player.transform.position - transform.position;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1); 
        }
        else
        {
            _animator.SetBool("Running",false);
            _animator.SetBool("Walking",true);
            
            if (_navMeshAgent.velocity.magnitude <= Mathf.Epsilon)
            {
                Vector3 randomPoint = GetRandomPoint();
                _navMeshAgent.SetDestination(randomPoint);
            
                Vector3 dir = randomPoint - transform.position;
                dir.y = 0;
                Quaternion rot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1); 
            }
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 30, 1);
        return hit.position;
    }


    public void ActivateMovingToPlayer()
    {
        _isMovingToPlayer = true;
    }
    
    public void DeActivateMovingToPlayer()
    {
        _isMovingToPlayer = false;
    }
    
    
}
