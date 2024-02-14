using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCraft : MonoBehaviour
{
    [Header("Urunlerin Spawn Olacagi Nokta")]
    public Transform _assetSpawnPoint;
    [Header("Spawn Olacak Urun Prefabi")]
    public GameObject _assetPrefab;
    [Header("Olusan Urunlerin Dizilecegi Noktalar")]
    public List<Transform> _emptyTransforms = new List<Transform>();
    [Header("Urunlerin Olusma Hizi")]
    public float _spawnRate;
    [Header("Spawn Olacak Urun Parent")]
    public GameObject _parent;
    [Header("Kontrol Amacli Burayi Elleme")]
    public List<GameObject> _craftedAssets = new List<GameObject>();


    private float _timer;
    public int _assetAmount;
    private int _emptySpawnPoint;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_craftedAssets.Count < 60)
        {
            if (_timer > _spawnRate)
            {
                if (_craftedAssets.Count == _assetAmount)
                {
                    GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                    product.gameObject.transform.DOJump(_emptyTransforms[_craftedAssets.Count].position, 3, 1, 0.5f);
                    product.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                    _craftedAssets.Add(product);
                    product.transform.parent = _parent.transform;
                    _assetAmount++;

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
                            product.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                            product.transform.parent = _parent.transform;

                            _assetAmount++;

                            break;
                        }
                        else if (_craftedAssets[i].transform.parent != _parent.transform)
                        {
                            GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                            _craftedAssets[i] = product;
                            _emptySpawnPoint = i;

                            product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                            product.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                            product.transform.parent = _parent.transform;

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
                        product.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                        product.transform.parent = _parent.transform;

                        _assetAmount++;

                        break;
                    }
                    else if (_craftedAssets[i].transform.parent != _parent.transform)
                    {
                        GameObject product = Instantiate(_assetPrefab, _assetSpawnPoint.position, Quaternion.identity);
                        _craftedAssets[i] = product;
                        _emptySpawnPoint = i;

                        product.gameObject.transform.DOJump(_emptyTransforms[_emptySpawnPoint].position, 3, 1, 0.5f);
                        product.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
                        product.transform.parent = _parent.transform;

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
}



