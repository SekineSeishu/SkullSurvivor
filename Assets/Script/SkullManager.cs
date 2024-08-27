using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkullManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;//スキルデータ
    public Skull _skullPrehub;//スキル
    public Player _player;
    public bool _spawnTrigger;//スキルを生成できるかフラグ
    public bool _nowSkill;//フィールドにスキルがあるかのフラグ
    public float _coolTime;
    private int _maxSkill;//最大で生成出来る数

    // Start is called before the first frame update
    void Start()
    {
        //スキルデータを渡して初期化する
        _skill._skillLevel = 0;
        _coolTime = _skill._coolTime;
        _spawnTrigger = false;
        _nowSkill = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnTrigger)
        {
            _coolTime -= Time.deltaTime;
            if (_coolTime <= 0)
            {
                if (!_nowSkill)//フィールドにスキルがなければ実行
                {
                    transform.position = _player.transform.position;
                    //レベルに応じて生成する
                    if (_maxSkill >= 1)
                    {
                        Skull skull = Instantiate(_skullPrehub, gameObject.transform);
                        //スカルにプレイヤー、半径、角度を設定する
                        skull._player = _player;
                        skull._radius = 2;
                        skull._angle = 5;
                    }
                    if (_maxSkill >= 2)
                    {
                        Skull skull2 = Instantiate(_skullPrehub, gameObject.transform);
                        //スカルにプレイヤー、半径、角度を設定する
                        skull2._player = _player;
                        skull2._radius = 2;
                        skull2._angle = 20;
                    }
                    if (_maxSkill >= 3)
                    {
                        Skull skull3 = Instantiate(_skullPrehub, gameObject.transform);
                        //スカルにプレイヤー、半径、角度を設定する
                        skull3._player = _player;
                        skull3._radius = 2;
                        skull3._angle = 10;
                    }
                    if (_maxSkill >= 4)
                    {
                        Skull skull4 = Instantiate(_skullPrehub, gameObject.transform);
                        //スカルにプレイヤー、半径、角度を設定する
                        skull4._player = _player;
                        skull4._radius = 2;
                        skull4._angle = 15;
                    }
                    _nowSkill = true;
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
    }

    public void Respawn()
    {
        //リセット
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }
    //スキルレベルが上がった際に呼び出す
    public void SkillLevelBounas()
    {
        //スキルのレベルが上がることに効果をプラスする

        if (_skill._skillLevel >= 1)//スキルを発動可能にする
        {
            _spawnTrigger = true;
            _maxSkill = 1;
        }
        if (_skill._skillLevel >= 2)//スキルのダメージを上げる
        {
            _skill._damage = 15;
        }
        if (_skill._skillLevel >= 3)//出せるスキルの量を１増やす
        {
            _maxSkill++ ;
        }
        if (_skill._skillLevel >= 4)//出せるスキルの量を１増やす
        {
            _maxSkill++;
        }
        if (_skill._skillLevel >= 5)//スキルのダメージを上げる
        {
            _skill._damage = 20;
        }
        if (_skill._skillLevel >= 6)//出せるスキルの量を１増やす
        {
            _maxSkill++;
        }
    }
}
