using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnedAssetControl : MonoBehaviour
{
    [Header("Olusan Urunlerin Dizilecegi Noktalar")]
    public List<Transform> _emptyTransforms = new List<Transform>();
    [Header("Ýcerisindeki Spawn Script")]
    [SerializeField] private TransformerCraft _transformerCraft;
    [Header("Kontrol Amacli Burayi Elleme")]
    public List<GameObject> _craftedAssets = new List<GameObject>();
    [Header("Spawn Olacak Urun Parent")]
    public GameObject _parent;


    public PlayerStackController _playerStackController;
    public Rigidbody _playerRigidbody;

    private float _timer;
    private float _sendTimer;
    public int _assetAmount;
    private int _emptySpawnPoint;

    private GameObject _product;

    private void Update()
    {
        if (_transformerCraft._assetAmount < 24 && _craftedAssets.Count > 0)
        {
            _sendTimer += Time.deltaTime;

            if (_sendTimer > 0.1f)
            {
                StartCoroutine(SendAssetTimer());
                _sendTimer = 0;
            }
            else
            {

            }
        }
        else
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (_playerRigidbody.velocity.x == 0 || _playerRigidbody.velocity.z == 0)
            {
                if (_playerStackController._spawnedAssetsInBag.Count > 0)
                {
                    _timer += Time.deltaTime;

                    if (_craftedAssets.Count < 60)
                    {
                        if (_timer > 0.05f)
                        {
                            if (_craftedAssets.Count == _assetAmount)
                            {
                                _product = _playerStackController._spawnedAssetsInBag[_playerStackController._spawnedAssetsInBag.Count - 1].gameObject;
                                _playerStackController.SpawnedAssetDraw(_emptyTransforms[_craftedAssets.Count]);
                                //_transformerCraft._needProduct++;
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
                                        _product = _playerStackController._spawnedAssetsInBag[_playerStackController._spawnedAssetsInBag.Count - 1].gameObject;
                                        _craftedAssets[i] = _product;
                                        _emptySpawnPoint = i;

                                        _playerStackController.SpawnedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                        //_transformerCraft._needProduct++;
                                        _product.transform.parent = _parent.transform;
                                        _assetAmount++;

                                        break;
                                    }
                                    else if (_craftedAssets[i].transform.parent != _parent.transform)
                                    {
                                        _product = _playerStackController._spawnedAssetsInBag[_playerStackController._spawnedAssetsInBag.Count - 1].gameObject;
                                        _craftedAssets[i] = _product;
                                        _emptySpawnPoint = i;

                                        _playerStackController.SpawnedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                        //_transformerCraft._needProduct++;
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
                                    _product = _playerStackController._spawnedAssetsInBag[_playerStackController._spawnedAssetsInBag.Count - 1].gameObject;
                                    _craftedAssets[i] = _product;
                                    _emptySpawnPoint = i;

                                    _playerStackController.SpawnedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                    //_transformerCraft._needProduct++;
                                    _product.transform.parent = _parent.transform;
                                    _assetAmount++;

                                    break;
                                }
                                else if (_craftedAssets[i].transform.parent != _parent.transform)
                                {
                                    _product = _playerStackController._spawnedAssetsInBag[_playerStackController._spawnedAssetsInBag.Count - 1].gameObject;
                                    _craftedAssets[i] = _product;
                                    _emptySpawnPoint = i;

                                    _playerStackController.SpawnedAssetDraw(_emptyTransforms[_emptySpawnPoint]);
                                    //_transformerCraft._needProduct++;
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


    IEnumerator SendAssetTimer()
    {
        if (_craftedAssets.Count > 0)
        {
            //int sira = _spawnedAssetsInBag.Count - 1;
            //_spawnedAssetControl.UpdateProduct(_spawnedAssetsInBag[_spawnedAssetsInBag.Count - 1].gameObject);
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.parent = null;
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.DOJump(_transformerCraft._takeAssetPoint.position, 3, 1, 0.5f);
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _craftedAssets.RemoveAt(_craftedAssets.Count - 1);
            _assetAmount--;
            yield return new WaitForSeconds(0.5f);
            _transformerCraft._needProduct++;
            //_sendTimer = 0;
            //_objectsInBag.RemoveAt(_objectsInBag.Count - 1);

        }
        else
        {

        }

        //SendAssets();
    }

    private void SendAssets()
    {
        if (_craftedAssets.Count > 0)
        {
            //int sira = _spawnedAssetsInBag.Count - 1;
            //_spawnedAssetControl.UpdateProduct(_spawnedAssetsInBag[_spawnedAssetsInBag.Count - 1].gameObject);
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.parent = null;
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.DOJump(_transformerCraft._takeAssetPoint.position, 3, 1, 0.5f);
            _craftedAssets[_craftedAssets.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _craftedAssets.RemoveAt(_craftedAssets.Count - 1);
            _transformerCraft._needProduct++;
            //_objectsInBag.RemoveAt(_objectsInBag.Count - 1);
            _assetAmount--;
        }
        else
        {

        }
    }
}

