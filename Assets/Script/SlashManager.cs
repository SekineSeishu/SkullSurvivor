using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashManager : MonoBehaviour
{
    public Skill _skill;//スキルデータ
    public Slashing slashPrehubL;//スキル
    public Slashing slashPrehubR;//スキル
    public Player _player;
    public SpriteRenderer _playersp;
    public float _coolTime;//クールタイム
    public bool _nowSkill;//スキル発動判定

    // Start is called before the first frame update
    void Start()
    {
        _skill._skillLevel = 1;
        _coolTime = _skill._coolTime;
    }

    public void SkillLevelBounas()
    {
        if (_skill._skillLevel >= 2)//レベル2→ダメージアップ
        {
            _skill._damage = 15;
        }
        //レベル３→//左右に飛ばす
        if (_skill._skillLevel >= 4)//レベル4→ダメージアップ
        {
            _skill._damage = 20;
        }
        if (_skill._skillLevel >= 5)//レベル５→ダメージアップ
        {
            _skill._damage = 30;
        }
        if (_skill._skillLevel >= 6) //レベル6→斬撃のサイズを大きくする
        {
            slashPrehubL.transform.localScale = new Vector3(3, 2, 1);
            slashPrehubR.transform.localScale = new Vector3(3, 2, 1);
        }
    }
    // Update is called once per frame
    void Update()
    {
        _coolTime -= Time.deltaTime;

        if (_coolTime <= 0)
        {
            if (!_nowSkill)//現在スキルが出ているか
            {
                transform.position = _player.gameObject.transform.position;
                //スキルレベルに応じて生成する数を変える
                if (_skill._skillLevel <= 2)
                {
                    if (_playersp.flipX == true)
                    {
                        Slashing slashR = Instantiate(slashPrehubR, gameObject.transform);
                        slashR._playerData = _player;
                    }
                    else if (_playersp.flipX == false)
                    {
                        Slashing slashL = Instantiate(slashPrehubL, gameObject.transform);
                        slashL._playerData = _player;
                    }
                }
                else if (_skill._skillLevel >= 3)
                {
                    Slashing slashL = Instantiate(slashPrehubL, gameObject.transform);
                    slashL._playerData = _player;
                    Slashing slashR = Instantiate(slashPrehubR, gameObject.transform);
                    slashR._playerData = _player;
                }
                _nowSkill = true;
            }
            else
            {
                if (transform.childCount == 0)
                {
                    Respawn();
                }
            }
        }
    }
    public void Respawn()
    {
        _nowSkill = false;
         _coolTime = _skill._coolTime;
    }
}

