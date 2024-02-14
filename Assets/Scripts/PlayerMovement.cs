using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Animator _animator;

    [HideInInspector] public float _velocityX;
    [HideInInspector] public float _velocityZ;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;

        _rigidbody.velocity = new Vector3(_floatingJoystick.Horizontal * _speed, _rigidbody.velocity.y, _floatingJoystick.Vertical * _speed);

        if (_floatingJoystick.Horizontal != 0 || _floatingJoystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        else
        {

        }

        _velocityX = _rigidbody.velocity.x;
        _velocityZ = _rigidbody.velocity.z;

        if (_rigidbody.velocity.x != 0 || _rigidbody.velocity.z != 0)
        {
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
        }

    }
}
