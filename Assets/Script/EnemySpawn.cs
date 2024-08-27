using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Player _player;//プレイヤー
    [SerializeField] private LevelManager _levelManager;//経験値の取得
    [SerializeField] private GameObject nowEnemy;//今出現している敵
    [SerializeField] private GameObject gaikotu;//敵２
    [SerializeField] private GameObject BossEnemy;//ボス
    [SerializeField] private GameObject monster;//敵3
    [SerializeField] private GameObject zombi2;//敵4
    [SerializeField] private Transform enemyParent;

    private int maxEnemies = 20;//敵の上限
    private float spawnInterval = 1.0f;//リスポーン間隔
    private float spawnAreaSize = 10.0f;//出現エリア
    public int _nowEnemyCount = 0;//現在の敵の数
    public int _deadEnemy= 0;//倒した敵の数
    [SerializeField] private float _bossInterval;//ボスが出てくるまでの時間
    [SerializeField]private float _enemyChangeTime ;//出現する敵の時間
    public TMP_Text _deadCount;//倒した数の表示
    public float radius = 1.0f;
    public LayerMask layerMask; // チェックするレイヤーを設定


    void Start()
    {
        //初期化
        _enemyChangeTime = 0;
        _bossInterval = 0;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        //倒した敵の数を表示
        _deadCount.SetText(_deadEnemy.ToString());
        _bossInterval += Time.deltaTime;
        _enemyChangeTime += Time.deltaTime;
        //敵が倒された時に倒した数を更新
        if (enemyParent.childCount != _nowEnemyCount)
        {
            _nowEnemyCount = enemyParent.childCount;
            _deadEnemy++;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 敵の切り替えタイミングで出現する敵を変更
            if (_enemyChangeTime >= 30.0f)
            {
                nowEnemy = gaikotu;
            }
            if (_enemyChangeTime >= 90.0f)
            {
                nowEnemy = zombi2;
            }
            if (_enemyChangeTime >= 150.0f)
            {
                nowEnemy = monster;
            }
            //上限に達していない場合、新たな敵を出現させる
            if (_nowEnemyCount < maxEnemies )
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                // boxSizeで指定したサイズの領域にコライダーが存在するかをチェック
                Collider2D collider = Physics2D.OverlapCircle(spawnPosition, radius);
                if (collider == null)
                {
                    GameObject enemy = Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                    enemy.transform.parent = enemyParent;
                    enemy.GetComponent<Enemy>()._player = _player;
                    _nowEnemyCount++;
                }
            }
            if (_enemyChangeTime == 90)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                GameObject enemy = Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                enemy.transform.parent = enemyParent;
                _nowEnemyCount++;
            }


            if (_bossInterval >= 60 )
            {
                //1分おきにボスを呼び出す
                Vector2 spawnPosition = GetRandomSpawnPosition();
                GameObject bossEnemy = Instantiate(BossEnemy, spawnPosition, Quaternion.identity);
                bossEnemy.transform.parent = enemyParent;
                _bossInterval = 0;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        // 出現エリア内のランダムな位置を計算
        Vector2 randomCircle = Random.insideUnitCircle * spawnAreaSize;
        Vector2 spawnPosition = new Vector3(randomCircle.x,randomCircle.y, 0.0f) + transform.position;
        return spawnPosition;
    }
}
