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

    public void TakeDamage(float damage)
    {
        
    }
}
