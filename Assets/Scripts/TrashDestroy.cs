using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpawnedAsset" || other.gameObject.tag == "TransformedAsset" || other.gameObject.tag == "ReadySpawnedAsset" || other.gameObject.tag == "ReadyTransformedAsset")
        {
            Destroy(other.gameObject);
        }
        else
        {

        }
    }
}
