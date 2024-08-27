using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashManager : MonoBehaviour
{
    public Skill _skill;//�X�L���f�[�^
    public Slashing slashPrehubL;//�X�L��
    public Slashing slashPrehubR;//�X�L��
    public Player _player;
    public SpriteRenderer _playersp;//�v���C���[�̌���
    public float _coolTime;//�N�[���^�C��
    public bool _nowSkill;//�t�B�[���h�ɃX�L�������邩�̃t���O

    // Start is called before the first frame update
    void Start()
    {
        //�X�L�����x���̏������ƃN�[���^�C�����X�L���f�[�^����󂯎��
        _skill._skillLevel = 1;
        _coolTime = _skill._coolTime;
    }

    //�X�L�����x�����オ�����ۂɌĂяo��
    public void SkillLevelBounas()
    {
        //�X�L���̃��x�����オ�邱�ƂɌ��ʂ��v���X����
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
                //�X�L�����x���ɉ����Đ������鐔��ς���
                //�X�L���Ƀv���C���[�̏���^����(�_���[�W��^����ۂɃv���C���[�̍U���͂��g������)
                if (_skill._skillLevel <= 2)
                {
                    if (_playersp.flipX == true)
                    {
                        transform.position = _player.gameObject.transform.position;
                        Slashing slashR = Instantiate(slashPrehubR, gameObject.transform);
                        slashR._player = _player;
                    }
                    else if (_playersp.flipX == false)
                    {
                        transform.position = _player.gameObject.transform.position;
                        Slashing slashL = Instantiate(slashPrehubL, gameObject.transform);
                        slashL._player = _player;
                    }
                }
                else if (_skill._skillLevel >= 3)
                {
                    transform.position = _player.gameObject.transform.position;
                    Slashing slashL = Instantiate(slashPrehubL, gameObject.transform);
                    slashL._player = _player;
                    Slashing slashR = Instantiate(slashPrehubR, gameObject.transform);
                    slashR._player = _player;
                }
                _nowSkill = true;
            }
            else
            {
                //�S�ẴX�L������������N�[���^�C�������Z�b�g����
                if (transform.childCount == 0)
                {
                    Respawn();
                }
            }
        }
    }
    public void Respawn()
    {
        //���Z�b�g
        _nowSkill = false;
         _coolTime = _skill._coolTime;
    }
}

