using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rollAngle;
    [SerializeField] private Transform[] _planes;
    public float testVal = 0.5f;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.rotation * Vector3.left * _speed;

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= Vector3.up * Time.deltaTime * _rotationSpeed;
            if(testVal >= 0) testVal -= 1 * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * _rotationSpeed;
            if(testVal <= 1) testVal += 1 * Time.deltaTime;
            
        }else{
            if(testVal < 0.5) testVal += 1 * Time.deltaTime;
            if(testVal > 0.5) testVal -= 1 * Time.deltaTime;

        }

        foreach (var plane in _planes)
        {
            plane.localEulerAngles = Vector3.Lerp(Vector3.left * 25,Vector3.left * -25,testVal);
        }
        //_plane.localEulerAngles = Vector3.Lerp(Vector3.left * 25,Vector3.left * -25,testVal);
    }
}
