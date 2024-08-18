using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private Skill _skill;
    public float growthRate; // �������x�i�b���Ƃ̃X�P�[���̑������j
    public float SkillDamage;
    public float playtime;
    public Player _player;

    public AudioSource _audiosource;
    public AudioClip MagicSE;
    // Start is called before the first frame update
    void Start()
    {
        playtime = _skill._playTime;
        _audiosource = GetComponent<AudioSource>();
        _audiosource.PlayOneShot(MagicSE);
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

        //transform.position = new Vector3(_player.position.x, _player.position.y, _player.position.z);

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
            //�v���C���[�̍U���͂ƃX�L���̃_���[�W
            enemy.HitDamage(_player.Attack * _skill._damage);
        }
    }
}
