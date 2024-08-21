using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MagicManager : MonoBehaviour
{
    [SerializeField] Skill _skill;//�X�L���f�[�^
    [SerializeField] private Magic MagicPrehub;//�X�L���̃v���n�u
    [SerializeField] private Player _player;
    [SerializeField] private float _coolTime;
    private bool _spawnTrigger;//�X�L���𐶐��ł��邩�t���O
    private bool _nowSkill;//�t�B�[���h�ɃX�L�������邩�̃t���O


    // Start is called before the first frame update
    void Start()
    {
        //�X�L���f�[�^��n���ď�����
        _spawnTrigger = false;
        _coolTime = _skill._coolTime;
    }


    void Update()
    {
        if (_spawnTrigger)
        {
            if (!_nowSkill)//�t�B�[���h�ɃX�L�����Ȃ���Ύ��s
            {
                _coolTime -= Time.deltaTime;
                if (_coolTime <= 0)
                {
                    transform.position = _player.transform.position;
                    Magic magic = Instantiate(MagicPrehub, gameObject.transform);
                    //�X�L���Ƀv���C���[�̏���^����(�_���[�W��^����ۂɃv���C���[�̍U���͂��g������)
                    magic._player = _player;
                    _nowSkill = true;
                }
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

    private void Respawn()
    {
        //���Z�b�g
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }

    //�X�L�����x�����オ�����ۂɌĂяo��
    public void SkillLevelBounas()
    {
        //�X�L���̃��x�����オ�邱�ƂɌ��ʂ��v���X����
        if (_skill._skillLevel == 1)//�X�L���𔭓��\�ɂ���
        {
            _spawnTrigger = true;
        }
        if (_skill._skillLevel == 2)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 40;
        }
        if (_skill._skillLevel == 3)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 50;
        }
        if (_skill._skillLevel == 4)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 60;
        }
        if (_skill._skillLevel == 5)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 70;
        }
        if (_skill._skillLevel == 6)//�X�L���̃N�[���^�C����Z�k����
        {
            _skill._coolTime = 10;
        }
    }
}
