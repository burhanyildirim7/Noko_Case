using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;

    [SerializeField] private Animator _animator;

    [SerializeField] private SpawnedAssetControl _spawnedAssetControl;
    [SerializeField] private AIStackController _aiStackController;


    private NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator.SetBool("Idle", false);
        _animator.SetBool("Run", true);
    }

    void Update()
    {
        if (_spawnedAssetControl._assetAmount < 60)
        {
            if (_aiStackController._spawnedAssetsInBag.Count > 0)
            {
                if (_aiStackController._spawnedAssetsInBag.Count == 0)
                {
                    _agent.destination = _point1.position;
                }
                else
                {
                    _agent.destination = _point2.position;
                }
            }
            else
            {
                _agent.destination = _point1.position;
            }
        }
        else
        {
            _agent.destination = _point3.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            _animator.SetBool("Run", false);
            _animator.SetBool("Idle", true);
        }
        else
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            _animator.SetBool("Idle", false);
            _animator.SetBool("Run", true);
        }
        else
        {

        }
    }
}
