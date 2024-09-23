using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    
    public Animator _bulletAnmation;
    public float SmallBulletDamage = 0.2f;

    private static readonly int BulletDestroyed = Animator.StringToHash("BulletDestroyed");

    // Start is called before the first frame update
    void Start()
    {
        //_bulletAnmation.SetBool(BulletDestroyed, false);
        Invoke(nameof(DestroyTime), 1f);
    }

    void DestroyTime()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Platform"))
        {
            //_bulletAnmation.SetBool(BulletDestroyed, true);
            Destroy(gameObject);
            //_bulletAnmation.SetBool(BulletDestroyed, false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            //_bulletAnmation.SetBool(BulletDestroyed, true);
            Destroy(gameObject);
            //_bulletAnmation.SetBool(BulletDestroyed, false);
        }
    }
}