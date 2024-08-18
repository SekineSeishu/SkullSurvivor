using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Skill _skill;
    public TMP_Text _name;
    public TMP_Text _level;
    public TMP_Text _description;
    public Image _image;

    void Start()
    {
        _name.text = _skill._skillName;
        _level.text = _skill._skillLevel.ToString();
        _description.text = _skill._skillText;
        _image.sprite = _skill._icon;
    }

    public void SkillLevelUp()
    {
        _skill._skillLevel++;
        SkillManager sm = GetComponentInParent<SkillManager>();
        sm.SkillUp(_skill.grop);
    }
}
