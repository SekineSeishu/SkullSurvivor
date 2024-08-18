using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Image _levelber;
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private TextMeshProUGUI _resultLevel;
    public int _levelUP = 2;
    public int _level;
    public int _exp;
    [SerializeField]
    private GameObject _buttonSelect;
    [SerializeField]
    public GameObject _player;
    private float _attackUp = 0.2f;
    [SerializeField]
    private GameObject _hpBar;
    [SerializeField] private SkillManager _skillManager;


    // Start is called before the first frame update
    void Start()
    {
        _exp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //レベルが上がった際にレベルボーナスの表示と必要経験値とプレイヤーと敵の攻撃力の増加
        Player player = _player.GetComponent<Player>();
        HPbar hpbar = _hpBar.GetComponent<HPbar>();
        _levelber.fillAmount = (float)_exp / _levelUP;

        _levelText.SetText("Lv" + _level);
        _resultLevel.SetText("Lv" + _level);

        if (_exp >= _levelUP)
        {
            _skillManager.RandomSkillButton();
            Time.timeScale = 0;
            _level++;
            _levelUP += 8;
            player.Attack += _attackUp;
            hpbar._enemydamage += 1;
            _exp = 0;
        }
        
    }

}
