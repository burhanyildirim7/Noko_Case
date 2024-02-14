using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject _player;

    Vector3 _distance;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _distance = transform.position - _player.transform.position;
    }


    void FixedUpdate()
    {

        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + _distance.y, _player.transform.position.z + _distance.z);

    }
}
