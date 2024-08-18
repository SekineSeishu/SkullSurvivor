using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashManager : MonoBehaviour
{
    public Skill _skill;//�X�L���f�[�^
    public Slashing slashPrehubL;//�X�L��
    public Slashing slashPrehubR;//�X�L��
    public Player _player;
    public SpriteRenderer _playersp;
    public float _coolTime;//�N�[���^�C��
    public bool _nowSkill;//�X�L����������

    // Start is called before the first frame update
    void Start()
    {
        _skill._skillLevel = 1;
        _coolTime = _skill._coolTime;
    }

    public void SkillLevelBounas()
    {
        if (_skill._skillLevel >= 2)//���x��2���_���[�W�A�b�v
        {
            _skill._damage = 15;
        }
        //���x���R��//���E�ɔ�΂�
        if (_skill._skillLevel >= 4)//���x��4���_���[�W�A�b�v
        {
            _skill._damage = 20;
        }
        if (_skill._skillLevel >= 5)//���x���T���_���[�W�A�b�v
        {
            _skill._damage = 30;
        }
        if (_skill._skillLevel >= 6) //���x��6���a���̃T�C�Y��傫������
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
            if (!_nowSkill)//���݃X�L�����o�Ă��邩
            {
                transform.position = _player.gameObject.transform.position;
                //�X�L�����x���ɉ����Đ������鐔��ς���
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

