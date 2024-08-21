using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Skill;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<Skill> deck;//残っているスキルリスト(ここからランダムに選ぶ)
    [SerializeField] private List<Skill> skills;//全てのスキル
    [SerializeField] private SkillButton _skillButton;//レベルアップボタン
    [SerializeField] private List<Transform> _buttonPosition;//ボタン生成位置
    [SerializeField] private Player _player;
    [SerializeField] private SlashManager _slashManager;//斬撃
    [SerializeField] private SkullManager _skullManager;//スカル
    [SerializeField] private MagicManager _magicManager;//魔法陣
    [SerializeField] private HPbar _hp;

    private int _selectNum = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void RandomSkillButton()
    {
        //全てのスキルを一度デッキに入れる
        deck = new List<Skill>(skills);
        foreach (Skill skill in deck)
        {
            //最大レベルの時はデッキから外す
            if (skill._skillLevel == skill._maxSkillLevel)
            {
                deck.Remove(skill);
            }
        }
        //デッキからランダムなスキルのレベルアップボタンを生成する
        //生成したスキルはデッキから外す
        for (int i = 0; i < _selectNum; i++)
        {
            Instantiate(_skillButton.gameObject, _buttonPosition[i]);
            _skillButton._skill = deck[Random.Range(0, skills.Count)];
            deck.Remove(_skillButton._skill);
        }
    }

    public void SkillUp(skillgrop grop)
    {
        //スキルボタンを消す
        RemoveSkillButton();
        //スキルの種類に応じて処理を行う
        switch (grop)
        {
            case skillgrop.attack:
                _player._attack += 0.5f;
                break;
            case skillgrop.slash:
                _slashManager.SkillLevelBounas();
                break;
            case skillgrop.skull:
                _skullManager.SkillLevelBounas();
                break;
            case skillgrop.heal:
                _hp.PlusHP();
                break;
            case skillgrop.magic:
                _magicManager.SkillLevelBounas();
                break;
        }
    }

    public void RemoveSkillButton()
    {
        foreach (var position in _buttonPosition)
        {
            foreach (Transform button in position)
            {
                Destroy(button.gameObject);
                Time.timeScale = 1.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
