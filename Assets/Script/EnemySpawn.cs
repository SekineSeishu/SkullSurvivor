using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Player _player;//�v���C���[
    [SerializeField] private LevelManager _levelManager;//�o���l�̎擾
    [SerializeField] private GameObject nowEnemy;//���o�����Ă���G
    [SerializeField] private GameObject gaikotu;//�G�Q
    [SerializeField] private GameObject BossEnemy;//�{�X
    [SerializeField] private GameObject monster;//�G3
    [SerializeField] private GameObject zombi2;//�G4
    [SerializeField] private Transform enemyParent;

    private int maxEnemies = 20;//�G�̏��
    private float spawnInterval = 1.0f;//���X�|�[���Ԋu
    private float spawnAreaSize = 10.0f;//�o���G���A
    public int _nowEnemyCount = 0;//���݂̓G�̐�
    public int _deadEnemy= 0;//�|�����G�̐�
    [SerializeField] private float _bossInterval;//�{�X���o�Ă���܂ł̎���
    [SerializeField]private float _enemyChangeTime ;//�o������G�̎���
    public TMP_Text _deadCount;//�|�������̕\��
    public float radius = 1.0f;
    public LayerMask layerMask; // �`�F�b�N���郌�C���[��ݒ�


    void Start()
    {
        //������
        _enemyChangeTime = 0;
        _bossInterval = 0;
        StartCoroutine(SpawnEnemies());
    }

    private void Update()
    {
        //�|�����G�̐���\��
        _deadCount.SetText(_deadEnemy.ToString());
        _bossInterval += Time.deltaTime;
        _enemyChangeTime += Time.deltaTime;
        //�G���|���ꂽ���ɓ|���������X�V
        if (enemyParent.childCount != _nowEnemyCount)
        {
            _nowEnemyCount = enemyParent.childCount;
            _deadEnemy++;
        }
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // �G�̐؂�ւ��^�C�~���O�ŏo������G��ύX
            if (_enemyChangeTime >= 30.0f)
            {
                nowEnemy = gaikotu;
            }
            if (_enemyChangeTime >= 90.0f)
            {
                nowEnemy = zombi2;
            }
            if (_enemyChangeTime >= 150.0f)
            {
                nowEnemy = monster;
            }
            //����ɒB���Ă��Ȃ��ꍇ�A�V���ȓG���o��������
            if (_nowEnemyCount < maxEnemies )
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                // boxSize�Ŏw�肵���T�C�Y�̗̈�ɃR���C�_�[�����݂��邩���`�F�b�N
                Collider2D collider = Physics2D.OverlapCircle(spawnPosition, radius);
                if (collider == null)
                {
                    GameObject enemy = Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                    enemy.transform.parent = enemyParent;
                    enemy.GetComponent<Enemy>()._player = _player;
                    _nowEnemyCount++;
                }
            }
            if (_enemyChangeTime == 90)
            {
                Vector2 spawnPosition = GetRandomSpawnPosition();
                GameObject enemy = Instantiate(nowEnemy, spawnPosition, Quaternion.identity);
                enemy.transform.parent = enemyParent;
                _nowEnemyCount++;
            }


            if (_bossInterval >= 60 )
            {
                //1�������Ƀ{�X���Ăяo��
                Vector2 spawnPosition = GetRandomSpawnPosition();
                GameObject bossEnemy = Instantiate(BossEnemy, spawnPosition, Quaternion.identity);
                bossEnemy.transform.parent = enemyParent;
                _bossInterval = 0;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector2 GetRandomSpawnPosition()
    {
        // �o���G���A���̃����_���Ȉʒu���v�Z
        Vector2 randomCircle = Random.insideUnitCircle * spawnAreaSize;
        Vector2 spawnPosition = new Vector3(randomCircle.x,randomCircle.y, 0.0f) + transform.position;
        return spawnPosition;
    }
}
