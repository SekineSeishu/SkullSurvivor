using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public float growthRate; // 成長速度（秒ごとのスケールの増加率）
    public float SkillDamage;
    public float playtime;
    public Player _player;

    public AudioSource _audiosource;
    public AudioClip MagicSE;
    // Start is called before the first frame update
    void Start()
    {
        playtime = _skill._playTime;
        _audiosource = GetComponent<AudioSource>();
        _audiosource.PlayOneShot(MagicSE);
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

        //transform.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);

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
            //プレイヤーの攻撃力とスキルのダメージ
            enemy.HitDamage(_player.Attack * _skill._damage);
        }
    }
}
