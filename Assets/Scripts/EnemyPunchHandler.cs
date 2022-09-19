using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPunchHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private Timer _punchTimer;
    [SerializeField] private float _punchRadius;

    private void Start()
    {
        _punchTimer = new Timer(GetPunchAnimDuration());
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _punchRadius,_playerMask);
        if (colliders.Length > 0)
        {
            if(_punchTimer.UpdateCounter(Time.deltaTime))
                _animator.SetTrigger("Punching");
        }
    }

    private float GetPunchAnimDuration()
    {
        AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
        float length = 0;
        foreach (AnimationClip clip in clips)
        {
            if (clip.name == "Punching")
                length = clip.length;
        }

        return length;
    }
}
