using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slashing : MonoBehaviour
{
    public Skill _skill;
    public Player _playerData;
    [SerializeField] private GameObject SlashL;
    [SerializeField] private GameObject SlashR;
    public float SkillDamage = 10f;
    private float _playtime;
    [SerializeField] private Direction side;
    private AudioSource audiosource;
    [SerializeField] private AudioClip SlashSE;

    public enum Direction
    {
        Left,
        Right
    }

    void Start()
    {
        //�U�����Ԃ����Z�b�g����SE�𗬂�
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

        switch (side)
        {
            case Direction.Left:
                transform.Translate(-0.5f, 0, 0);
                break;
            case Direction.Right:
                transform.Translate(0.5f, 0, 0);
                break;
        }
        
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
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W
            Player player = GameObject.Find("Player").GetComponent<Player>();
            enemy.HitDamage(player.Attack * SkillDamage); 
        }
    }
}
