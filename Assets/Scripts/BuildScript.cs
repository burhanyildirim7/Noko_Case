using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScript : MonoBehaviour
{
    [Header("Olusan Urunlerin Dizilecegi Noktalar")]
    public List<Transform> _emptyTransforms = new List<Transform>();
    [Header("Kontrol Amacli Burayi Elleme")]
    public List<GameObject> _craftedAssets = new List<GameObject>();
    [Header("Spawn Olacak Urun Parent")]
    public GameObject _parent;


    public PlayerStackController _playerStackController;
    public Rigidbody _playerRigidbody;

    private float _timer;
    public int _assetAmount;
    private int _emptySpawnPoint;

    private GameObject _product;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
            {
                if (_playerStackController._transformedAssetsInBag.Count > 0)
                {
                    _timer += Time.deltaTime;

                    if (_craftedAssets.Count < 108)
                    {
                        if (_timer > 0.05f)
                        {
                            if (_craftedAssets.Count == _assetAmount)
                            {
                                _product = _playerStackController._transformedAssetsInBag[_playerStackController._transformedAssetsInBag.Count - 1].gameObject;
                                _playerStackController.TransformedAssetDraw(_emptyTransforms[_craftedAssets.Count]);
                                _craftedAssets.Add(_product);
                                _product.transform.parent = _parent.transform;
                                _assetAmount++;

                                _timer = 0;
                            }
                            else
                            {
                                for (int i = 0; i < _craftedAssets.Count; i++)
                                {
                                    if (_craftedAssets[i] == null)
                                    {
                                        _product = _playerStackController._transformedAssetsInBag[_playerStackController._transformedAssetsInBag.Count - 1].gameObject;
                                        _craftedAssets[i] = _product;
                                        _emptySpawnPoint = i;

                                        _playerStackController.TransformedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                        _product.transform.parent = _parent.transform;
                                        _assetAmount++;

                                        break;
                                    }
                                    else if (_craftedAssets[i].transform.parent != _parent.transform)
                                    {
                                        _product = _playerStackController._transformedAssetsInBag[_playerStackController._transformedAssetsInBag.Count - 1].gameObject;
                                        _craftedAssets[i] = _product;
                                        _emptySpawnPoint = i;

                                        _playerStackController.TransformedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                        _product.transform.parent = _parent.transform;
                                        _assetAmount++;

                                        break;
                                    }
                                    else
                                    {

                                    }
                                }

                                _timer = 0;

                            }
                        }
                    }
                    else
                    {
                        if (_timer > 0.05f)
                        {
                            for (int i = 0; i < _craftedAssets.Count; i++)
                            {
                                if (_craftedAssets[i] == null)
                                {
                                    _product = _playerStackController._transformedAssetsInBag[_playerStackController._transformedAssetsInBag.Count - 1].gameObject;
                                    _craftedAssets[i] = _product;
                                    _emptySpawnPoint = i;

                                    _playerStackController.TransformedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                    _product.transform.parent = _parent.transform;
                                    _assetAmount++;

                                    break;
                                }
                                else if (_craftedAssets[i].transform.parent != _parent.transform)
                                {
                                    _product = _playerStackController._transformedAssetsInBag[_playerStackController._transformedAssetsInBag.Count - 1].gameObject;
                                    _craftedAssets[i] = _product;
                                    _emptySpawnPoint = i;

                                    _playerStackController.TransformedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                    _product.transform.parent = _parent.transform;
                                    _assetAmount++;

                                    break;
                                }
                                else
                                {

                                }
                            }
                            _timer = 0;
                        }
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
    }
}
