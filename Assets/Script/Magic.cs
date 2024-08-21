using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private Skill _skill;//スキルデータ
    [SerializeField] private float growthRate; // 成長速度（秒ごとのスケールの増加率）
    [SerializeField] private float _skillDamage;//スキルダメージ
    [SerializeField] private float playtime;//攻撃継続時間
    public Player _player;

    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioClip _magicSE;
    // Start is called before the first frame update
    void Start()
    {
        //スキルデータを渡して初期化してSEを流す
        playtime = _skill._playTime;
        _audiosource.PlayOneShot(_magicSE);
    }

    // Update is called once per frame
    void Update()
    {
        playtime -= Time.deltaTime;

        // 現在のスケールを取得
        Vector3 currentScale = transform.localScale;

        // 成長率を時間に乗じてスケールを変更
        currentScale += Vector3.one * growthRate * Time.deltaTime;

        // オブジェクトのスケールを変更
        transform.localScale = currentScale;

        //一定時間経ったら消える
        if (playtime <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
        if (collision.gameObject.tag == "Enemy")
        {
            //プレイヤーの攻撃力とスキルのダメージで計算して敵にダメージを与える
            enemy.HitDamage(_player._attack * _skill._damage);
        }
    }
}
