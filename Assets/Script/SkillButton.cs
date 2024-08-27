using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Skill _skill;//�X�L���f�[�^
    public TMP_Text _name;
    public TMP_Text _level;
    public TMP_Text _description;
    public Image _image;

    void Start()
    {
        //�X�L���f�[�^��UI�ɓn��
        _name.text = _skill._skillName;
        if (_skill._skillLevel == 0)
        {
            _level.text = "new";
        }
        else
        {
            _level.text = "Lv:" + _skill._skillLevel;
        }
        _description.text = _skill._skillText;
        _image.sprite = _skill._icon;
    }

    public void SkillLevelUp()
    {
        //�w�肵���X�L���̃��x�����グ�ă��x���A�b�v���̏���
        _skill._skillLevel++;
        SkillManager sm = GetComponentInParent<SkillManager>();
        sm.SkillUp(_skill.grop);
    }
}
