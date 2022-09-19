using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneTrigger : MonoBehaviour
{
    public event Action PlayerEnteredEnemyZone;
    public event Action PlayerExitEnemyZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerEnteredEnemyZone?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerExitEnemyZone?.Invoke();
        }
    }
}
