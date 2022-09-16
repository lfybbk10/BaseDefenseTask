using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MoveCharacterController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    
    private CharacterController _characterController;
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        float correctHeight = _characterController.center.y + _characterController.skinWidth;
        _characterController.center = new Vector3(0, correctHeight, 0);
    }

    private void Update()
    {
        if (_joystick.Direction != Vector2.zero)
        {
            _animator.SetBool("Running",true);
            Vector3 joystickDir = new Vector3(_joystick.Direction.x,0,_joystick.Direction.y);
            _characterController.SimpleMove(joystickDir*_speed);
            
            if(_animator.GetCurrentAnimatorStateInfo(0).IsName("RifleRun"))
                return;
            
            transform.DOLookAt(new Vector3(joystickDir.x + transform.position.x,0,joystickDir.z+transform.position.z), 0.1f,AxisConstraint.Y);
        }
        else
        {
            _animator.SetBool("Running",false);
        }
    }
}
