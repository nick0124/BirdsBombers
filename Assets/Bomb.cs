using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _explosionPrefab;

    public float testVal = 1f;
    private Vector3 _minAngle;
    private Vector3 _maxAngle;

    // Start is called before the first frame update
    void Start()
    {
        _minAngle = transform.eulerAngles;
        _maxAngle = new Vector3(_minAngle.x, _minAngle.y, 60);
    }

    // Update is called once per frame
    void Update()
    {
        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.rotation * Vector3.left * _speed;
        transform.position += transform.rotation * Vector3.left * _speed * Time.deltaTime;

        if (testVal >= 0) testVal += 0.5f * Time.deltaTime;

        transform.localEulerAngles = Vector3.Lerp(_minAngle, _maxAngle, testVal);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
