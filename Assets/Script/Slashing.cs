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

    //���E�؂�ւ�
    public enum type
    {
        Left,
        Right
    }

    void Start()
    {
        //�_���[�W�ƍU���������Ԃ��X�L���f�[�^����󂯎����SE�𗬂�
        _playtime = _skill._playTime;
        SkillDamage = _skill._damage;
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(SlashSE);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //���Ԃ̊ԏ����ɂ���ăX�L�����΂�
        _playtime -= Time.deltaTime;

        //���E�ǂ���ɔ�΂����ňړ���؂�ւ���
        switch (side)
        {
            case type.Left:
                transform.Translate(-0.5f, 0, 0);
                break;
            case type.Right:
                transform.Translate(0.5f, 0, 0);
                break;
        }

        //�U���������Ԃ��I������������
        if (_playtime <= 0)
        {
            Destroy(gameObject);
            Debug.Log("������");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.gameObject.tag == "Enemy")
        {
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W�Ōv�Z���ēG�Ƀ_���[�W��^����
            enemy.HitDamage(_player._attack * SkillDamage); 
        }
    }
}
