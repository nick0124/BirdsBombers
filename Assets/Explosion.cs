using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _maxScale;
    [SerializeField] private float _animationSpeed;
    private bool _reachMaxScale = false;
    private float _scaleMiltiply;
    private Vector3 _initialScale;

    // Start is called before the first frame update
    void Start()
    {
        _initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_scaleMiltiply < _maxScale && _reachMaxScale == false)
        {
            _scaleMiltiply += _animationSpeed * Time.deltaTime;
        }
        else
        {
            _reachMaxScale = true;
        }

        if (_reachMaxScale)
        {
            _scaleMiltiply -= _animationSpeed * 2 * Time.deltaTime;
        }

        transform.localScale = _initialScale * _scaleMiltiply;

        if (transform.localScale.x < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("explose");
    }
}
