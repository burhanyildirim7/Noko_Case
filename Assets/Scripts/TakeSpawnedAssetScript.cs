using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeSpawnedAssetScript : MonoBehaviour
{
    public PlayerStackController _playerStackController;
    public AIStackController _aiStackController;
    public SpawnerCraft _spawnerCraft;
    public Rigidbody _playerRigidbody;

    private float _timer;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
            {
                if (_spawnerCraft._craftedAssets.Count > 0 && _spawnerCraft._assetAmount > 0)
                {
                    _timer += Time.deltaTime;

                    if (_timer > 0.05f)
                    {
                        _playerStackController.TakeSpawnedAsset(_spawnerCraft._craftedAssets[_spawnerCraft._assetAmount - 1]);
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
        }
        else
        {

        }

        if (other.gameObject.tag == "AICharacter")
        {

            if (_spawnerCraft._craftedAssets.Count > 0 && _spawnerCraft._assetAmount > 0)
            {
                _timer += Time.deltaTime;

                if (_timer > 0.05f)
                {
                    _aiStackController.TakeSpawnedAsset(_spawnerCraft._craftedAssets[_spawnerCraft._assetAmount - 1]);
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
}
