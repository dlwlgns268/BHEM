using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooter : MonoBehaviour {
    public GameObject missile;
    public GameObject target;
    public GameObject Player;
    private float _bulletDirection = 0;
    private const float AttackSight = 80;
    private float _attackDelay = 0;
    
    public float spd;
    public int shot = 6;

    private void Update()
    {
        _attackDelay -= Time.deltaTime;
        if (_attackDelay < 0)
        {
            _attackDelay = 0;
        }
        float distance = Vector3.Distance(Player.transform.position , target.transform.position);
        if (distance <= AttackSight && _attackDelay <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(CreateMissile());
                _attackDelay = 2;
            }
        }
    }

    public void Shot() {
        StartCoroutine(CreateMissile());
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator CreateMissile() {
        int _shot = shot;
        while (_shot > 0) {
            Debug.Log("Tang!");
            _shot--;
            if (GetComponent<PlayerMove>()._goingLeft == true)
            {
                _bulletDirection = -1f;
            }
            else
            {
                _bulletDirection = 1f;
            }

            var transform1 = transform;
            Vector3 direction = transform1.right * (transform1.localScale.x * _bulletDirection);
            GameObject bullet = Instantiate(missile, transform1.position + direction, Quaternion.identity);
            bullet.GetComponent<Attack>().master = gameObject;
            bullet.GetComponent<Attack>().enemy = target; 
            
            yield return new WaitForSeconds(0.07f);
        }
        yield return null;
    }
}
