using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Result : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillList;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private EnemySpawn _enemyDead;
    [SerializeField] private TextMeshProUGUI resultPlayerLevel;//�v���C���[�̃��x���e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultEnemyKill;//�L�����e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultSlashLevel;//�a���X�L���̃��x���e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultSkullLevel;//�X�J���X�L���̃��x���e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultMagicLevel;//���@�w�X�L���̃��x���e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultHealCount;//�񕜃X�L���̉񐔃e�L�X�g(���U���g)
    [SerializeField] private TextMeshProUGUI resultAttackCount;//�U���̓A�b�v�X�L���̉񐔃e�L�X�g(���U���g)

    // Start is called before the first frame update
    void Start()
    {
        //�S�ẴX�L�����O���[�v���ƂɃ��x���e�L�X�g�ɃZ�b�g����
        foreach (var skill in _skillList)
        {
            switch (skill.grop)
            {
                case Skill.skillgrop.attack:
                    resultAttackCount.SetText(skill._skillLevel.ToString());
                    break;
                case Skill.skillgrop.slash:
                    resultSlashLevel.SetText(skill._skillLevel.ToString());
                    break;
                case Skill.skillgrop.skull:
                    resultSkullLevel.SetText(skill._skillLevel.ToString());
                    break;
                case Skill.skillgrop.heal:
                    resultHealCount.SetText(skill._skillLevel.ToString());
                    break;
                case Skill.skillgrop.magic:
                    resultMagicLevel.SetText(skill._skillLevel.ToString());
                    break;
            }
        }
        resultEnemyKill.SetText(_enemyDead._deadEnemy.ToString());
        resultPlayerLevel.SetText("Lv" + _levelManager._level.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
