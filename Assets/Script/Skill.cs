using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "ScriptableObject/Create Skill")]
public class Skill : ScriptableObject
{
    public enum skillgrop
    {
        attack,
        slash,
        skull,
        heal,
        magic
    }

    public skillgrop grop;
    public string _skillName;
    public int _skillLevel;
    public int _maxSkillLevel;
    public string _skillText;
    public List<string> _skillList;
    public int _damage;
    public int _helse;
    public float _attack;
    public float _coolTime;
    public int _playTime;
    public AudioClip _se;
    public Sprite _icon;

    public void SkillLevel()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

