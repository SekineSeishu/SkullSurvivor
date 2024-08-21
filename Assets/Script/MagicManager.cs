using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicManager : MonoBehaviour
{
    [SerializeField] Skill _skill;//スキルデータ
    [SerializeField] private Magic MagicPrehub;//スキルのプレハブ
    [SerializeField] private Player _player;
    [SerializeField] private float _coolTime;
    private bool _spawnTrigger;//スキルを生成できるかフラグ
    private bool _nowSkill;//フィールドにスキルがあるかのフラグ


    // Start is called before the first frame update
    void Start()
    {
        //スキルデータを渡して初期化
        _spawnTrigger = false;
        _coolTime = _skill._coolTime;
    }


    void Update()
    {
        if (_spawnTrigger)
        {
            if (!_nowSkill)//フィールドにスキルがなければ実行
            {
                _coolTime -= Time.deltaTime;
                if (_coolTime <= 0)
                {
                    transform.position = _player.transform.position;
                    Magic magic = Instantiate(MagicPrehub, gameObject.transform);
                    //スキルにプレイヤーの情報を与える(ダメージを与える際にプレイヤーの攻撃力を使うため)
                    magic._player = _player;
                    _nowSkill = true;
                }
            }
            else
            {
                //全てのスキルが消えたらクールタイムをリセットする
                if (transform.childCount == 0)
                {
                    Respawn();
                }
            }
        }
    }

    private void Respawn()
    {
        //リセット
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }

    //スキルレベルが上がった際に呼び出す
    public void SkillLevelBounas()
    {
        //スキルのレベルが上がることに効果をプラスする
        if (_skill._skillLevel == 1)//スキルを発動可能にする
        {
            _spawnTrigger = true;
        }
        if (_skill._skillLevel == 2)//スキルのダメージを上げる
        {
            _skill._damage = 40;
        }
        if (_skill._skillLevel == 3)//スキルのダメージを上げる
        {
            _skill._damage = 50;
        }
        if (_skill._skillLevel == 4)//スキルのダメージを上げる
        {
            _skill._damage = 60;
        }
        if (_skill._skillLevel == 5)//スキルのダメージを上げる
        {
            _skill._damage = 70;
        }
        if (_skill._skillLevel == 6)//スキルのクールタイムを短縮する
        {
            _skill._coolTime = 10;
        }
    }
}
