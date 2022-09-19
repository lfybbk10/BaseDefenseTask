using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZoneTrigger : MonoBehaviour
{
    public bool IsPlayerInZone;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsPlayerInZone = false;
        }
    }
}
