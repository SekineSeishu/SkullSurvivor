using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Result : MonoBehaviour
{
    [SerializeField] private List<Skill> _skillList;
    [SerializeField] private TextMeshProUGUI resultSlashLevel;//斬撃スキルのレベルテキスト(リザルト)
    [SerializeField] private TextMeshProUGUI resultSkullLevel;//スカルスキルのレベルテキスト(リザルト)
    [SerializeField] private TextMeshProUGUI resultMagicLevel;//魔法陣スキルのレベルテキスト(リザルト)
    [SerializeField] private TextMeshProUGUI resultHealCount;//回復スキルの回数テキスト(リザルト)
    [SerializeField] private TextMeshProUGUI resultAttackCount;//攻撃力アップスキルの回数テキスト(リザルト)

    // Start is called before the first frame update
    void Start()
    {
        //全てのスキルをグループごとにレベルテキストにセットする
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
