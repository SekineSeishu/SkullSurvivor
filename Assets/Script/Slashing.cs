using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slashing : MonoBehaviour
{
    public Skill _skill;
    public Player _player;
    [SerializeField] private GameObject SlashL;
    [SerializeField] private GameObject SlashR;
    public float SkillDamage = 10f;
    private float _playtime;
    [SerializeField] private type side;
    private AudioSource audiosource;
    [SerializeField] private AudioClip SlashSE;

    //左右切り替え
    public enum type
    {
        Left,
        Right
    }

    void Start()
    {
        //ダメージと攻撃生存時間をスキルデータから受け取ってSEを流す
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

        //左右どちらに飛ばすかで移動を切り替える
        switch (side)
        {
            case type.Left:
                transform.Translate(-0.5f, 0, 0);
                break;
            case type.Right:
                transform.Translate(0.5f, 0, 0);
                break;
        }

        //攻撃生存時間が終わったら消える
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
            //プレイヤーの攻撃力とスキルのダメージで計算して敵にダメージを与える
            enemy.HitDamage(_player._attack * SkillDamage); 
        }
    }
}
