using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkullManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public Skull _skullPrehub;//スキル
    public Player _player;
    public int _SkullLevel;//スキルのレベル
    public bool _spawnTrigger;
    public bool _nowSkill;
    public float _coolTime;
    private int _maxSkill;

    // Start is called before the first frame update
    void Start()
    {
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
            if (_coolTime >= 5)
            {
                if (!_nowSkill)
                {
                    transform.position = _player.transform.position;
                    if (_maxSkill >= 1)
                    {
                        Skull skull = Instantiate(_skullPrehub, gameObject.transform);
                        skull._centerPoint = _player;
                        skull._radius = 2;
                        skull._angle = 5;
                    }
                    if (_maxSkill >= 2)
                    {
                        Skull skull2 = Instantiate(_skullPrehub, gameObject.transform);
                        skull2._centerPoint = _player;
                        skull2._radius = 2;
                        skull2._angle = 20;
                    }
                    if (_maxSkill >= 3)
                    {
                        Skull skull3 = Instantiate(_skullPrehub, gameObject.transform);
                        skull3._centerPoint = _player;
                        skull3._radius = 12;
                        skull3._angle = 10;
                    }
                    if (_maxSkill >= 4)
                    {
                        Skull skull4 = Instantiate(_skullPrehub, gameObject.transform);
                        skull4._centerPoint = _player;
                        skull4._radius = 2;
                        skull4._angle = 15;
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
    }

    public void Respawn()
    {
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }
    public void SkillLevelBounas()
    {
        //スキルのレベルが上がることに効果をプラスする

        if (_skill._skillLevel >= 1)//スキルを発動可能にする
        {
            _spawnTrigger = true;
        }
        if (_skill._skillLevel >= 2)//スキルのダメージを上げる
        {
            _skill._damage = 15;
        }
        if (_skill._skillLevel >= 3)//出せるスキルの量を１増やす
        {
            _maxSkill= 2;
        }
        if (_skill._skillLevel >= 4)//出せるスキルの量を１増やす
        {
            _maxSkill = 3;
        }
        if (_skill._skillLevel >= 5)//スキルのダメージを上げる
        {
            _skill._damage = 20;
        }
        if (_skill._skillLevel >= 6)//出せるスキルの量を１増やす
        {
            _maxSkill = 4;
        }
    }
}
