using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTransformedAssetScript : MonoBehaviour
{
    public PlayerStackController _playerStackController;
    public AIStackController _aiStackController;
    public TransformerCraft _transformerCraft;
    public Rigidbody _playerRigidbody;

    private float _timer;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
            {
                if (_transformerCraft._craftedAssets.Count > 0 && _transformerCraft._assetAmount > 0)
                {
                    _timer += Time.deltaTime;

                    if (_timer > 0.05f)
                    {
                        _playerStackController.TakeTransformedAsset(_transformerCraft._craftedAssets[_transformerCraft._assetAmount - 1]);
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

            if (_transformerCraft._craftedAssets.Count > 0 && _transformerCraft._assetAmount > 0)
            {
                _timer += Time.deltaTime;

                if (_timer > 0.05f)
                {
                    _aiStackController.TakeTransformedAsset(_transformerCraft._craftedAssets[_transformerCraft._assetAmount - 1]);
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
