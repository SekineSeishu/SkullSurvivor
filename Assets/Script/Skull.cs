using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public Player _centerPoint; // �v���C���[�̎������钆�S�_
    public float _radius = 2.0f; // ���a
    private float _speed = 2.0f; // ��]���x
    public int _skillDamage;

    public float _angle;

    private float _playTime;

    // Start is called before the first frame update
    void Start()
    {
        _skillDamage = _skill._damage;
        _playTime = _skill._playTime;
    }

    // Update is called once per frame
    void Update()
    {

        _playTime -= Time.deltaTime;
        if (_playTime <= 0)
        {
            Destroy(gameObject);
        }
        
        // ���ԂɊ�Â��Ċp�x���X�V
        _angle += _speed * Time.deltaTime;

        // �V�����ʒu���v�Z
        Vector3 offset = new Vector3(Mathf.Cos(_angle), Mathf.Sin(_angle), 0) * _radius;
        transform.position = _centerPoint.transform.position + offset;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (collision.gameObject.tag == "Enemy")
        {
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W
            Player player = GameObject.Find("Player").GetComponent<Player>();
            enemy.HitDamage(player._attack * _skillDamage);
        }
    }
}
