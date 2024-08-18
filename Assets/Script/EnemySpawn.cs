using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject nowEnemy;//���o�����Ă���G
    [SerializeField] private GameObject gaikotu;//�G�Q
    [SerializeField] private GameObject BossEnemy;//�{�X
    [SerializeField] private GameObject monster;//�G3
    [SerializeField] private GameObject zombi2;//�G4

    private int maxEnemies = 20;//�G�̏��
    private float spawnInterval = 1.0f;//���X�|�[���Ԋu
    private float spawnAreaSize = 10.0f;//�o���G���A
    public int NowEnemies = 0;//���݂̓G�̐�
    public int DeadEnemy = 0;//�|�����G�̐�
    [SerializeField] private float BossInterval;//�{�X���o�Ă���܂ł̎���
    [SerializeField]private float EnemyspawnTime ;
    public TextMeshProUGUI DeadCount;
    public TextMeshProUGUI RisultDeadCount;


    void Start()
    {
        EnemyspawnTime = 0;
        BossInterval = 0;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        //�|�����G�̐���\��
        DeadCount.SetText(DeadEnemy.ToString());
        RisultDeadCount.SetText(DeadEnemy.ToString());
        BossInterval += Time.deltaTime;
        EnemyspawnTime += Time.deltaTime;

        if (NowEnemies <= 0)
        {
            NowEnemies = 0;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // �G�̐؂�ւ��^�C�~���O�ŏo������G��ύX
            if (EnemyspawnTime >= 30.0f)
            {
                nowEnemy = gaikotu;
            }
            if (EnemyspawnTime >= 90.0f)
            {
                nowEnemy = zombi2;
            }
            if (EnemyspawnTime >= 150.0f)
            {
                nowEnemy = monster;
            }
            //����ɒB���Ă��Ȃ��ꍇ�A�V���ȓG���o��������
            if (NowEnemies < maxEnemies )
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                NowEnemies++;   
            }
            if (EnemyspawnTime == 90)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                NowEnemies++;
            }


            if (BossInterval >= 60 )
            {
                //1�������Ƀ{�X���Ăяo��
                Vector2 spawnPosition = GetRandomSpawnPosition();
                Instantiate(BossEnemy, spawnPosition, Quaternion.identity);
                BossInterval = 0;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // �o���G���A���̃����_���Ȉʒu���v�Z
        Vector2 randomCircle = Random.insideUnitCircle * spawnAreaSize;
        Vector3 spawnPosition = new Vector3(randomCircle.x,randomCircle.y, 0.0f) + transform.position;
        return spawnPosition;
    }

    //�G�����ꂽ�Ƃ�
    public void EnemyDestroyed()
    {
        NowEnemies--;
        DeadEnemy++;
    }
}
