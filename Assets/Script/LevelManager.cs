using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image _levelber;//レベルバー画像
    [SerializeField] private TMP_Text _levelText;//レベル表示テキスト
    [SerializeField] private int _levelUpExp;//レベルアップに必要な経験値数
    public int _level;//現在のレベル
    public int _exp;//現在の経験値
    [SerializeField] private Player _player;
    private float _attackUp = 0.2f;//レベルごとに上がるプレイヤーの攻撃力
    [SerializeField] private HPbar _hpBar;//HPバー
    [SerializeField] private SkillManager _skillManager; //スキルマネージャー


    // Start is called before the first frame update
    void Start()
    {
        //初期化
        _exp = 0;
        _levelUpExp = 2;
    }

    // Update is called once per frame
    void Update()
    {
        //レベルが上がった際にレベルボーナスの表示と必要経験値とプレイヤーと敵の攻撃力の増加
        _levelber.fillAmount = (float)_exp / _levelUpExp;

        _levelText.SetText("Lv" + _level);

        if (_exp == _levelUpExp)
        {
            Time.timeScale = 0;
            _skillManager.RandomSkillButton();
            _level++;
            _levelUpExp += 8;
            _player._attack += _attackUp;
            _hpBar._enemydamage += 1;
            _exp = 0;
        }
        
    }

}
