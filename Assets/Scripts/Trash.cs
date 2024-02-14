using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{

    [SerializeField] private Transform _trahsDestroyer;

    [SerializeField] private PlayerStackController _playerStackController;
    [SerializeField] private Rigidbody _playerRigidbody;

    private float _timer;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
            {

                if (_playerStackController._objectsInBag.Count > 0)
                {
                    _timer += Time.deltaTime;

                    if (_timer > 0.05f)
                    {
                        if (_playerStackController._spawnedAssetsInBag.Count > 0)
                        {
                            _playerStackController.SpawnedAssetDraw(_trahsDestroyer);
                            _timer = 0;
                        }
                        else if (_playerStackController._transformedAssetsInBag.Count > 0)
                        {
                            _playerStackController.TransformedAssetDraw(_trahsDestroyer);
                            _timer = 0;
                        }
                        else
                        {

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else
            {

            }
        }
        else
        {

        }
    }
}
