using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private Transform _bombSpawnPoint;
    [SerializeField] private GameObject _bombPrfab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(_bombPrfab,_bombSpawnPoint.position, _bombSpawnPoint.rotation);
        }
    }
}
