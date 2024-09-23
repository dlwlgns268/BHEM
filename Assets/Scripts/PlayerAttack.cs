using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    private float _reloadTime = 2f;
    private float Power = 6.4f;
    private float _lastFireTime = 0;
    private float _bulletDirection = 0;
    public GameObject Enemy;
    private int _createLoop = 0;
    private float _createTime;
    private float _timer;

    private void Update()
    {
        if (_createLoop >= 5)
        {
            _createLoop = 0;
        }
    }


    public void Fire()
    {
        if (Time.time - _lastFireTime >= _reloadTime)
        {
            while (_createLoop < 5)
            {
                Vector3 direction = transform.right * transform.localScale.x;
                GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);
                if (GetComponent<PlayerMove>()._goingLeft == true)
                {
                    _bulletDirection = -1f;
                }
                else
                {
                    _bulletDirection = 1f;
                }

                bullet.transform.localScale = new Vector3(_bulletDirection, 1f, 1f);

                bullet.GetComponent<Rigidbody2D>().AddForce(direction * Power, ForceMode2D.Impulse);
                _createLoop++;
                
            }
            _lastFireTime = Time.time;
        }
    }
    
}
