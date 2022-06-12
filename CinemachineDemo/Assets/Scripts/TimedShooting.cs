using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedShooting : MonoBehaviour
{
    public GameObject _projectile;
    public Transform _muzzlePoint;

    public float _delay;
    public bool _playOnAwake;

    private float _timeSinceStart;
    public float _stopAfter;

    public void Awake()
    {
        if(_playOnAwake)
        {
            _timeSinceStart = 0;
            InvokeRepeating("Fire", _delay, _delay);
        }
    }

    public void Update()
    {
        _timeSinceStart += Time.deltaTime;

        if (_timeSinceStart > _stopAfter)
            CancelInvoke();
    }

    private void Fire()
    {
        Instantiate(_projectile, _muzzlePoint.position, _muzzlePoint.rotation);
    }
}
