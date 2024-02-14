using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStackController : MonoBehaviour
{
    [Header("Objelerin Yerlesecegi Transform Listesi")]
    [SerializeField] private List<Transform> _emptySpawnedTransforms = new List<Transform>();
    [SerializeField] private List<Transform> _emptyTransformedTransforms = new List<Transform>();
    [Header("Cantada Bulunan Objelerin Tamami")]
    public List<GameObject> _objectsInBag = new List<GameObject>();
    [Header("Cantada Bulunan Saman Objeleri")]
    public List<GameObject> _spawnedAssetsInBag = new List<GameObject>();
    public List<GameObject> _transformedAssetsInBag = new List<GameObject>();

    //[SerializeField] private SpawnedAssetControl _spawnedAssetControl;

    private int _objectsAmountInBag;

    void Start()
    {
        _objectsAmountInBag = 0;
    }

    public void TakeSpawnedAsset(GameObject asset)
    {
        if (_objectsInBag.Count < _emptySpawnedTransforms.Count && _transformedAssetsInBag.Count == 0)
        {
            int number = _objectsAmountInBag;
            asset.gameObject.transform.parent = _emptySpawnedTransforms[number].transform;
            _objectsInBag.Add(asset.gameObject);
            _spawnedAssetsInBag.Add(asset.gameObject);
            asset.gameObject.tag = "ReadySpawnedAsset";

            asset.gameObject.transform.DOLocalJump(Vector3.zero, 1, 1, 0.5f);
            asset.gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _objectsAmountInBag++;

            Debug.Log("Girdi");

            if (GameObject.FindGameObjectWithTag("Spawner") != null)
            {
                SpawnerCraft _spawnerCraft = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerCraft>();

                if (_spawnerCraft._assetAmount > 0)
                {
                    _spawnerCraft._assetAmount--;
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

    public void TakeTransformedAsset(GameObject asset)
    {
        if (_objectsInBag.Count < _emptyTransformedTransforms.Count && _spawnedAssetsInBag.Count == 0)
        {
            int number = _objectsAmountInBag;
            asset.gameObject.transform.parent = _emptyTransformedTransforms[number].transform;
            _objectsInBag.Add(asset.gameObject);
            _transformedAssetsInBag.Add(asset.gameObject);
            asset.gameObject.tag = "ReadyTransformedAsset";

            asset.gameObject.transform.DOLocalJump(Vector3.zero, 1, 1, 0.5f);
            asset.gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            _objectsAmountInBag++;

            if (GameObject.FindGameObjectWithTag("Transformer") != null)
            {
                TransformerCraft _transformerCraft = GameObject.FindGameObjectWithTag("Transformer").GetComponent<TransformerCraft>();

                if (_transformerCraft._assetAmount > 0)
                {
                    _transformerCraft._assetAmount--;
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

    public void SpawnedAssetDraw(Transform transform)
    {
        if (_spawnedAssetsInBag.Count > 0)
        {
            _spawnedAssetsInBag[_spawnedAssetsInBag.Count - 1].gameObject.transform.parent = null;
            _spawnedAssetsInBag[_spawnedAssetsInBag.Count - 1].gameObject.transform.DOJump(transform.position, 3, 1, 0.5f);
            _spawnedAssetsInBag[_spawnedAssetsInBag.Count - 1].gameObject.transform.DOLocalRotate(Vector3.zero, 0.5f);
            _spawnedAssetsInBag.RemoveAt(_spawnedAssetsInBag.Count - 1);
            _objectsInBag.RemoveAt(_objectsInBag.Count - 1);
            _objectsAmountInBag--;
        }
        else
        {

        }
    }

    public void TransformedAssetDraw(Transform transform)
    {
        if (_transformedAssetsInBag.Count > 0)
        {
            _transformedAssetsInBag[_transformedAssetsInBag.Count - 1].gameObject.transform.parent = null;
            _transformedAssetsInBag[_transformedAssetsInBag.Count - 1].gameObject.transform.DOJump(transform.position, 3, 1, 0.5f);
            _transformedAssetsInBag[_transformedAssetsInBag.Count - 1].gameObject.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.5f);
            _transformedAssetsInBag.RemoveAt(_transformedAssetsInBag.Count - 1);
            _objectsInBag.RemoveAt(_objectsInBag.Count - 1);
            _objectsAmountInBag--;
        }
        else
        {

        }
    }
}
