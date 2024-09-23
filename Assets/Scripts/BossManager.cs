using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public int BossAtk = 0;
    private int _bossDef;
    private int _bossMaxHp;
    public int BossDotAtk;
    private int _bossCurHp;
    // Start is called before the first frame update
    void Start()
    {
        _bossMaxHp = 7539;
        _bossCurHp = _bossMaxHp;
        BossAtk = 53;
        _bossDef = 49;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
