using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkullManager : MonoBehaviour
{
    [SerializeField] private Skill _skill;//�X�L���f�[�^
    public Skull _skullPrehub;//�X�L��
    public Player _player;
    public bool _spawnTrigger;//�X�L���𐶐��ł��邩�t���O
    public bool _nowSkill;//�t�B�[���h�ɃX�L�������邩�̃t���O
    public float _coolTime;
    private int _maxSkill;//�ő�Ő����o���鐔

    // Start is called before the first frame update
    void Start()
    {
        //�X�L���f�[�^��n���ď���������
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
                if (!_nowSkill)//�t�B�[���h�ɃX�L�����Ȃ���Ύ��s
                {
                    transform.position = _player.transform.position;
                    //���x���ɉ����Đ�������
                    if (_maxSkill >= 1)
                    {
                        Skull skull = Instantiate(_skullPrehub, gameObject.transform);
                        //�X�J���Ƀv���C���[�A���a�A�p�x��ݒ肷��
                        skull._player = _player;
                        skull._radius = 2;
                        skull._angle = 5;
                    }
                    if (_maxSkill >= 2)
                    {
                        Skull skull2 = Instantiate(_skullPrehub, gameObject.transform);
                        //�X�J���Ƀv���C���[�A���a�A�p�x��ݒ肷��
                        skull2._player = _player;
                        skull2._radius = 2;
                        skull2._angle = 20;
                    }
                    if (_maxSkill >= 3)
                    {
                        Skull skull3 = Instantiate(_skullPrehub, gameObject.transform);
                        //�X�J���Ƀv���C���[�A���a�A�p�x��ݒ肷��
                        skull3._player = _player;
                        skull3._radius = 2;
                        skull3._angle = 10;
                    }
                    if (_maxSkill >= 4)
                    {
                        Skull skull4 = Instantiate(_skullPrehub, gameObject.transform);
                        //�X�J���Ƀv���C���[�A���a�A�p�x��ݒ肷��
                        skull4._player = _player;
                        skull4._radius = 2;
                        skull4._angle = 15;
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
    }

    public void Respawn()
    {
        //���Z�b�g
        _nowSkill = false;
        _coolTime = _skill._coolTime;
    }
    //�X�L�����x�����オ�����ۂɌĂяo��
    public void SkillLevelBounas()
    {
        //�X�L���̃��x�����オ�邱�ƂɌ��ʂ��v���X����

        if (_skill._skillLevel >= 1)//�X�L���𔭓��\�ɂ���
        {
            _spawnTrigger = true;
            _maxSkill = 1;
        }
        if (_skill._skillLevel >= 2)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 15;
        }
        if (_skill._skillLevel >= 3)//�o����X�L���̗ʂ��P���₷
        {
            _maxSkill++ ;
        }
        if (_skill._skillLevel >= 4)//�o����X�L���̗ʂ��P���₷
        {
            _maxSkill++;
        }
        if (_skill._skillLevel >= 5)//�X�L���̃_���[�W���グ��
        {
            _skill._damage = 20;
        }
        if (_skill._skillLevel >= 6)//�o����X�L���̗ʂ��P���₷
        {
            _maxSkill++;
        }
    }
}
