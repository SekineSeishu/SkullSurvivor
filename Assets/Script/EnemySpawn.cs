using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject nowEnemy;//今出現している敵
    [SerializeField] private GameObject gaikotu;//敵２
    [SerializeField] private GameObject BossEnemy;//ボス
    [SerializeField] private GameObject monster;//敵3
    [SerializeField] private GameObject zombi2;//敵4

    private int maxEnemies = 20;//敵の上限
    private float spawnInterval = 1.0f;//リスポーン間隔
    private float spawnAreaSize = 10.0f;//出現エリア
    public int NowEnemies = 0;//現在の敵の数
    public int DeadEnemy = 0;//倒した敵の数
    [SerializeField] private float BossInterval;//ボスが出てくるまでの時間
    [SerializeField]private float EnemyspawnTime ;
    public TextMeshProUGUI DeadCount;
    public TextMeshProUGUI RisultDeadCount;


    void Start()
    {
        EnemyspawnTime = 0;
        BossInterval = 0;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        //倒した敵の数を表示
        DeadCount.SetText(DeadEnemy.ToString());
        RisultDeadCount.SetText(DeadEnemy.ToString());
        BossInterval += Time.deltaTime;
        EnemyspawnTime += Time.deltaTime;

        if (NowEnemies <= 0)
        {
            NowEnemies = 0;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 敵の切り替えタイミングで出現する敵を変更
            if (EnemyspawnTime >= 30.0f)
            {
                nowEnemy = gaikotu;
            }
            if (EnemyspawnTime >= 90.0f)
            {
                nowEnemy = zombi2;
            }
            if (EnemyspawnTime >= 150.0f)
            {
                nowEnemy = monster;
            }
            //上限に達していない場合、新たな敵を出現させる
            if (NowEnemies < maxEnemies )
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                NowEnemies++;   
            }
            if (EnemyspawnTime == 90)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                NowEnemies++;
            }


            if (BossInterval >= 60 )
            {
                //1分おきにボスを呼び出す
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(BossEnemy, spawnPosition, Quaternion.identity);
                BossInterval = 0;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // 出現エリア内のランダムな位置を計算
        Vector2 randomCircle = Random.insideUnitCircle * spawnAreaSize;
        Vector3 spawnPosition = new Vector3(randomCircle.x,randomCircle.y, 0.0f) + transform.position;
        return spawnPosition;
    }

    //敵がやられたとき
    public void EnemyDestroyed()
    {
        NowEnemies--;
        DeadEnemy++;
    }
}
