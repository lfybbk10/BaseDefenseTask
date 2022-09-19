using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int Count;
    
    private GameObject _activeZone;

    private void Start()
    {
        Count++;
    }

    public void SetActiveZone(GameObject activeZone)
    {
        _activeZone = activeZone;
        
        _activeZone.GetComponent<EnemyZoneTrigger>().PlayerEnteredEnemyZone +=
            GetComponent<EnemyMoveHandler>().ActivateMovingToPlayer;
        
        _activeZone.GetComponent<EnemyZoneTrigger>().PlayerExitEnemyZone +=
            GetComponent<EnemyMoveHandler>().DeActivateMovingToPlayer;
    }

    private void OnDisable()
    {
        _activeZone.GetComponent<EnemyZoneTrigger>().PlayerEnteredEnemyZone -=
            GetComponent<EnemyMoveHandler>().ActivateMovingToPlayer;
        
        _activeZone.GetComponent<EnemyZoneTrigger>().PlayerExitEnemyZone -=
            GetComponent<EnemyMoveHandler>().DeActivateMovingToPlayer;
    }

    public void TakeDamage(float damage)
    {
        
    }
}
