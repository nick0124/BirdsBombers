using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rollAngle;
    [SerializeField] private Transform _plane;
    public float testVal;
    float t;

    private float _max;
    private float _min;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.rotation * Vector3.left * _speed;

        // t += 0.5f * Time.deltaTime;
        // testVal = Mathf.Lerp(0, 1, t);

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles -= Vector3.up * Time.deltaTime * _rotationSpeed;
            
            

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles += Vector3.up * Time.deltaTime * _rotationSpeed;
            //_plane.localEulerAngles = Vector3.MoveTowards(_plane.localEulerAngles, new Vector3(10,0,0),10 * Time.deltaTime)*-1;
        }

        _plane.localEulerAngles = Vector3.up *testVal;
    }
}
