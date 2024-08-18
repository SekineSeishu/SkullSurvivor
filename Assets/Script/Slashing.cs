using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slashing : MonoBehaviour
{
    public Skill _skill;
    public Player _playerData;
    [SerializeField] private GameObject SlashL;
    [SerializeField] private GameObject SlashR;
    public float SkillDamage = 10f;
    private float _playtime;
    [SerializeField] private Direction side;
    private AudioSource audiosource;
    [SerializeField] private AudioClip SlashSE;

    public enum Direction
    {
        Left,
        Right
    }

    void Start()
    {
        //攻撃時間をリセットしてSEを流す
        _playtime = _skill._playTime;
        SkillDamage = _skill._damage;
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(SlashSE);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //時間の間条件によってスキルを飛ばす
        _playtime -= Time.deltaTime;

        switch (side)
        {
            case Direction.Left:
                transform.Translate(-0.5f, 0, 0);
                break;
            case Direction.Right:
                transform.Translate(0.5f, 0, 0);
                break;
        }
        
        if (_playtime <= 0)
        {
            Destroy(gameObject);
            Debug.Log("消えた");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy")
        {
            //プレイヤーの攻撃力とスキルのダメージ
            Player player = GameObject.Find("Player").GetComponent<Player>();
            enemy.HitDamage(player.Attack * SkillDamage); 
        }
    }
}
