using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIOpen : MonoBehaviour
{
    [SerializeField] private GameObject _aiCharacter;


    void Start()
    {
        _aiCharacter.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _aiCharacter.SetActive(true);
        }
        else
        {

        }
    }

}
