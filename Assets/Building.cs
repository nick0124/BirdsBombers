using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _buildingParts;
    [SerializeField] private Rigidbody _pig;
    [SerializeField] private float _partsExplosionImpulse = 10;
    [SerializeField] private float _timeToDestroy = 5;
    [SerializeField] private GameObject _exposionCenter;

    private bool _isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        _pig.isKinematic = true;
        foreach (var buildingPart in _buildingParts)
        {
            buildingPart.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isDestroyed == false && other.gameObject.tag == "Explosion")
        {
            Explode();
            ThrowPig();
            //Destroy(gameObject, _timeToDestroy);
        }
    }

    private void Explode()
    {
        _isDestroyed = true;
        foreach (var buildingPart in _buildingParts)
        {
            buildingPart.transform.LookAt(_exposionCenter.transform.position);
            buildingPart.isKinematic = false;
            var randomizedForce = Random.Range(_partsExplosionImpulse, _partsExplosionImpulse + 2);
            buildingPart.AddForce(buildingPart.transform.rotation * Vector3.back * randomizedForce, ForceMode.Impulse);
        }
    }

    private void ThrowPig()
    {
        _pig.isKinematic = false;
        _pig.AddForce(Vector3.up * _partsExplosionImpulse*3, ForceMode.Impulse);
    }
}
