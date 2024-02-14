using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformerCraft : MonoBehaviour
{
    public Transform _assetSpawnPoint;
    public GameObject _assetPrefab;
    public List<Transform> _emptyTransforms = new List<Transform>();
    public float _spawnRate;
    public List<GameObject> _craftedAssets = new List<GameObject>();
    public GameObject _parent;
    public int _needProduct;

    public Transform _takeAssetPoint;


    private float _timer;
    public int _assetAmount;
    private int _emptySpawnPoint;

    private void Start()
    {
        _needProduct = 0;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_needProduct > 0)
        {
            if (_craftedAssets.Count < 24)
            {
                if (_timer > _spawnRate)
                {
                    if (_craftedAssets.Count == _assetAmount)
                    {
                        GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                        product.gameObject.transform.DOJump(_emptyTransforms[_craftedAssets.Count].position, 3, 1, 0.5f);
                        product.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.1f);
                        _craftedAssets.Add(product);
                        product.transform.parent = _parent.transform;
                        _assetAmount++;
                        _needProduct--;

                        _timer = 0;
                    }
                    else
                    {
                        for (int i = 0; i < _craftedAssets.Count; i++)
                        {
                            if (_craftedAssets[i] == null)
                            {
                                GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                                _craftedAssets[i] = product;
                                _emptySpawnPoint = i;

                                product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                                product.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.1f);
                                product.transform.parent = _parent.transform;

                                _assetAmount++;
                                _needProduct--;

                                break;
                            }
                            else if (_craftedAssets[i].transform.parent != _parent.transform)
                            {
                                GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                                _craftedAssets[i] = product;
                                _emptySpawnPoint = i;

                                product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                                product.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.1f);
                                product.transform.parent = _parent.transform;

                                _assetAmount++;
                                _needProduct--;

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
                if (_timer > _spawnRate)
                {
                    for (int i = 0; i < _craftedAssets.Count; i++)
                    {
                        if (_craftedAssets[i] == null)
                        {
                            GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                            _craftedAssets[i] = product;
                            _emptySpawnPoint = i;

                            product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                            product.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.1f);
                            product.transform.parent = _parent.transform;

                            _assetAmount++;
                            _needProduct--;

                            break;
                        }
                        else if (_craftedAssets[i].transform.parent != _parent.transform)
                        {
                            GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                            _craftedAssets[i] = product;
                            _emptySpawnPoint = i;

                            product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                            product.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.1f);
                            product.transform.parent = _parent.transform;

                            _assetAmount++;
                            _needProduct--;

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
