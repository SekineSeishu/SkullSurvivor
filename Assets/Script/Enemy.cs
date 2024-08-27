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
    public Player  _player; // プレイヤー
    [SerializeField] float speed = 0.8f; // 敵の動くスピード
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
        
        //playerを追跡
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, speed * Time.deltaTime);

        //追跡方向を向く
        if (transform.position.x > _player.transform.position.x)//右方向
        {
            sp.flipX = true;
        }
        else if (transform.position.x < _player.transform.position.x)//左方向
        {
            sp.flipX = false;
        }

        if (HP <= 0)
        {
            //倒されたら経験値をその場に落とす
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
        //ダメージをもらったときにダメージの値をテキストにして表示
        TextMeshProUGUI DT = DamageText.GetComponent<TextMeshProUGUI>();
        DamageText.SetActive(true);
        DT.SetText(damage.ToString("f0"));
        StartCoroutine(DestroyText());

        HP -= damage;
        Debug.Log("敵" + HP); 
    }

    private IEnumerator DestroyText()
    {
        //時間が経ったらダメージテキストを消す
        yield return new WaitForSeconds(1f);
        DamageText.SetActive(false);
    }
}
