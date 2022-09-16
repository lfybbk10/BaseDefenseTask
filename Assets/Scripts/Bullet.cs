using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    private float _amountDamage;

    private float _maxReleaseTime = 10;
    private Timer _releaseTimer;

    private void Start()
    {
        _releaseTimer = new Timer(_maxReleaseTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger "+other.gameObject.name);
        if (other.gameObject.IsInLayerMask(enemyMask))
        {
            other.GetComponent<Enemy>().TakeDamage(_amountDamage);
            Release();
        }
    }

    private void Update()
    {
        if (_releaseTimer.UpdateCounter(Time.deltaTime))
        {
            Release();
        }
        
    }

    private void Release()
    {
        PoolManager.ReleaseObject(gameObject);
        print("release");
    }
}
