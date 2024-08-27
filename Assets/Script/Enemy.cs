using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Skill;


public class Enemy : MonoBehaviour
{
    public enum EnemyGrop
    {
        enemy,
        bossEnemy
    }
    public EnemyGrop grop;
    public Player  _player; // �v���C���[
    [SerializeField] float speed = 0.8f; // �G�̓����X�s�[�h
    SpriteRenderer sp;
    public float HP;
    [SerializeField]
    private GameObject LevelPoint;
    [SerializeField]
    private GameObject DamageText;

    private void Start()
    {
        _player =FindObjectOfType<Player>();
        sp = GetComponent<SpriteRenderer>();
        DamageText.SetActive(false);
    }

    private void Update()
    {
        
        //player��ǐ�
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);

        //�ǐՕ���������
        if (transform.position.x > _player.transform.position.x)//�E����
        {
            sp.flipX = true;
        }
        else if (transform.position.x < _player.transform.position.x)//������
        {
            sp.flipX = false;
        }

        if (HP <= 0)
        {
            //�|���ꂽ��o���l�����̏�ɗ��Ƃ�
            switch (grop)
            {
                case EnemyGrop.enemy:
                    Instantiate(LevelPoint, transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                    break;
                case EnemyGrop.bossEnemy:
                    for(int i = 0; i <= 5; i++)
                    {
                        Instantiate(LevelPoint, transform.position, Quaternion.identity);
                        Destroy(this.gameObject);
                    }
                    break;
            }
        }

        
    }


    public void HitDamage(float damage)
    {
        //�_���[�W����������Ƃ��Ƀ_���[�W�̒l���e�L�X�g�ɂ��ĕ\��
        TextMeshProUGUI DT = DamageText.GetComponent<TextMeshProUGUI>();
        DamageText.SetActive(true);
        DT.SetText(damage.ToString("f0"));
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
}
