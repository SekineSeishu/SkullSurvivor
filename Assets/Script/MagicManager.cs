using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicManager : MonoBehaviour
{
    [SerializeField] Skill _skill;
    [SerializeField] private Magic MagicPrehub;//スキルのプレハブ
    [SerializeField] private Player _player;
    [SerializeField] private float _coolTime;
    private bool _spawnTrigger;
    private bool _nowSkill;


    // Start is called before the first frame update
    void Start()
    {
        _spawnTrigger = false;
        _coolTime = _skill._coolTime;
    }


    void Update()
    {
        if (_spawnTrigger)
        {
            if (!_nowSkill)
            {
                _coolTime -= Time.deltaTime;
                if (_coolTime <= 0)
                {
                    transform.position = _player.transform.position;
                    Magic magic = Instantiate(MagicPrehub, gameObject.transform);
                    magic._player = _player;
                    _nowSkill = true;
                }
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

    private void Respawn()
    {
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }

    public void SkillLevelBounas()
    {
        if (_skill._skillLevel == 1)
        {
            _spawnTrigger = true;
        }
        if (_skill._skillLevel == 2)
        {
            _skill._damage = 40;
        }
        if (_skill._skillLevel == 3)
        {
            _skill._damage = 50;
        }
        if (_skill._skillLevel == 4)
        {
            _skill._damage = 60;
        }
        if (_skill._skillLevel == 5)
        {
            _skill._damage = 70;
        }
        if (_skill._skillLevel == 6)
        {
            _skill._coolTime = 10;
        }
    }
}
