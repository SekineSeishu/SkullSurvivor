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
        foreach (var skill in skills)
        {
            skill._skillLevel = 0;
        }
    }

    public void RandomSkillButton()
    {
        //全てのスキルを一度デッキに入れる
        deck = new List<Skill>(skills);
        for (int i = 0; i < deck.Count; i++)
        {
            //最大レベルの時はデッキから外す
            if (deck[i]._skillLevel == deck[i]._maxSkillLevel)
            {
                deck.Remove(deck[i]);
            }
        }
        //デッキからランダムなスキルのレベルアップボタンを生成する
        //生成したスキルはデッキから外す
        for (int i = 0; i < _selectNum; i++)
        {
            if (deck.Count == 0)
            {
                Debug.Log("スキルがありません");
                break;
            }
            int selectSKill = Random.Range(0, deck.Count);
            Debug.Log("deck:" + selectSKill);
           SkillButton skillButton =  Instantiate(_skillButton, _buttonPosition[i]);
            skillButton._skill = deck[selectSKill];
            Debug.Log("deckName:" + deck[selectSKill]._skillName);
            deck.RemoveAt(selectSKill);
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
                _player.attackUp();
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
