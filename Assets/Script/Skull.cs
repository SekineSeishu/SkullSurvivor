using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private Skill _skill;//�X�L���f�[�^
    public Player _player; // �v���C���[�̎������钆�S�_
    public float _radius = 2.0f; // ���a
    private float _speed = 2.0f; // ��]���x
    public int _skillDamage;

    public float _angle;//�p�x

    private float _playTime;//�U����������

    // Start is called before the first frame update
    void Start()
    {
        //�_���[�W�ƍU���������Ԃ��X�L���f�[�^����󂯎��
        _skillDamage = _skill._damage;
        _playTime = _skill._playTime;
    }

    // Update is called once per frame
    void Update()
    {
        //��莞�Ԃ��o�����������
        _playTime -= Time.deltaTime;
        if (_playTime <= 0)
        {
            Destroy(gameObject);
        }
        
        // ���ԂɊ�Â��Ċp�x���X�V
        _angle += _speed * Time.deltaTime;

        // �V�����ʒu���v�Z
        Vector3 offset = new Vector3(Mathf.Cos(_angle), Mathf.Sin(_angle), 0) * _radius;
        transform.position = _player.transform.position + offset;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W�Ōv�Z���ēG�Ƀ_���[�W��^����
            enemy.HitDamage(_player._attack * _skillDamage);
        }
    }
}
