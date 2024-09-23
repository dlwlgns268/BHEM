using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int _playerCurHp;
    public int PlayerAtk;
    private static int _playerDef;
    private static int _playerMaxHp;
    private static GameObject _player;
    private float _invincibleTime = 0f;
    public GameObject Bullet;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        _playerMaxHp = 200;
        PlayerAtk = 75;
        _playerDef = 25;
        _playerCurHp = _playerMaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        _invincibleTime -= Time.deltaTime;
        if (_invincibleTime < 0)
        {
            _invincibleTime = 0;
        }
        if (_playerCurHp <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && _invincibleTime <= 0f)
        {
            _playerCurHp -= Enemy.GetComponent<EnemyCode>().Atk - _playerDef;
            _invincibleTime = 990.5f;
        }
        
        if (collision.gameObject.CompareTag("Fallen"))
        {
            _playerCurHp = 0;
        }
    }
}
