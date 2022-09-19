using System;
using DG.Tweening;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    private float _amountDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        print("trigger "+other.gameObject.name);
        if (other.gameObject.IsInLayerMask(enemyMask))
        {
            print("hit");
            other.GetComponent<Enemy>().TakeDamage(_amountDamage);
            Release();
        }
    }

    public void Fire(Vector3 destination)
    {
        transform.DOMove(destination, 1).OnComplete((() => Release()));
    }
    

    private void Release()
    {
        PoolManager.ReleaseObject(gameObject);
        print("release");
    }
}
