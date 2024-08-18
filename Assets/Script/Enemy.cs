using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    private GameObject  player; // �v���C���[
    Transform ptr;//�v���C���[�̈ʒu
    [SerializeField] float speed = 0.8f; // �G�̓����X�s�[�h
    SpriteRenderer sp;
    public float HP;
    [SerializeField]
    private GameObject LevelPoint;
    [SerializeField]
    private GameObject DamageText;

    private void Start()
    {
        player = GameObject.Find("Player");
        ptr = player.transform;// �v���C���[�̈ʒu���擾
        sp = GetComponent<SpriteRenderer>();
        DamageText.SetActive(false);
    }

    private void Update()
    {
        
        //player��ǐ�
        transform.position = Vector2.MoveTowards(transform.position, ptr.position, speed * Time.deltaTime);

        //�ǐՕ���������
        if (transform.position.x > ptr.position.x)//�E����
        {
            sp.flipX = true;
        }
        else if (transform.position.x < ptr.position.x)//������
        {
            sp.flipX = false;
        }

        if (HP <= 0)
        {
            //�|���ꂽ��o���l�����̏�ɗ��Ƃ�
            EnemySpawn enemyspawn = GameObject.Find("enemy respawn").GetComponent<EnemySpawn>();
            Instantiate(LevelPoint, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            enemyspawn.NowEnemies--;
            enemyspawn.DeadEnemy++;
        }

        
    }


    public void HitDamage(float damage)
    {
        //�_���[�W����������Ƃ��Ƀ_���[�W�̒l���e�L�X�g�ɂ��ĕ\��
        TextMeshProUGUI DT = DamageText.GetComponent<TextMeshProUGUI>();
        DamageText.SetActive(true);
        DT.SetText(damage.ToString());
        StartCoroutine(DestroyText());

        HP -= damage;
        Debug.Log("�G" + HP); 
    }

    private IEnumerator DestroyText()
    {
        //���Ԃ��o������_���[�W�e�L�X�g������
        yield return new WaitForSeconds(1f);
        DamageText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DespawnArea")
        {
            //�ǂ�艜�Ő������ꂽ�ꍇ���̏�ŏ���
            EnemySpawn enemyspawn = GameObject.Find("enemy respawn").GetComponent<EnemySpawn>();
            Destroy(gameObject);
            enemyspawn.NowEnemies--;
        }
    }
}
