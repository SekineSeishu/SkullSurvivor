using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private Skill _skill;//�X�L���f�[�^
    [SerializeField] private float growthRate; // �������x�i�b���Ƃ̃X�P�[���̑������j
    [SerializeField] private float _skillDamage;//�X�L���_���[�W
    [SerializeField] private float playtime;//�U���p������
    public Player _player;

    [SerializeField] private AudioSource _audiosource;
    [SerializeField] private AudioClip _magicSE;
    // Start is called before the first frame update
    void Start()
    {
        //�X�L���f�[�^��n���ď���������SE�𗬂�
        playtime = _skill._playTime;
        _audiosource.PlayOneShot(_magicSE);
    }

    // Update is called once per frame
    void Update()
    {
        playtime -= Time.deltaTime;

        // ���݂̃X�P�[�����擾
        Vector3 currentScale = transform.localScale;

        // �����������Ԃɏ悶�ăX�P�[����ύX
        currentScale += Vector3.one * growthRate * Time.deltaTime;

        // �I�u�W�F�N�g�̃X�P�[����ύX
        transform.localScale = currentScale;

        //��莞�Ԍo�����������
        if (playtime <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
        if (collision.gameObject.tag == "Enemy")
        {
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W�Ōv�Z���ēG�Ƀ_���[�W��^����
            enemy.HitDamage(_player._attack * _skill._damage);
        }
    }
}
