using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public Player _centerPoint; // プレイヤーの周りを回る中心点
    public float _radius = 2.0f; // 半径
    private float _speed = 2.0f; // 回転速度
    public int _skillDamage;

    public float _angle;

    private float _playTime;

    // Start is called before the first frame update
    void Start()
    {
        _skillDamage = _skill._damage;
        _playTime = _skill._playTime;
    }

    // Update is called once per frame
    void Update()
    {

        _playTime -= Time.deltaTime;
        if (_playTime <= 0)
        {
            Destroy(gameObject);
        }
        
        // 時間に基づいて角度を更新
        _angle += _speed * Time.deltaTime;

        // 新しい位置を計算
        Vector3 offset = new Vector3(Mathf.Cos(_angle), Mathf.Sin(_angle), 0) * _radius;
        transform.position = _centerPoint.transform.position + offset;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            //プレイヤーの攻撃力とスキルのダメージ
            Player player = GameObject.Find("Player").GetComponent<Player>();
            enemy.HitDamage(player._attack * _skillDamage);
        }
    }
}
