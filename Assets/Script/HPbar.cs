using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField]
    private Image HpBar;
    public float _maxHp = 100f;//最大HP
    public float _enemydamage = 5f;//敵に当たった際のダメージ
    private float _helse = 10f;//回復ボタンを押したときの回復量
    [SerializeField] private GameObject _GameOver;//ゲームオーバーテキスト
    [SerializeField] private GameObject _resultbutton;//リザルトボタン
    public AudioSource playeraudiosource;
    private bool _gameover;

    private float _currentHP;

    private AudioSource _audiosource;
    public AudioClip DamageSE;

    private void Awake()
    {

        _currentHP = _maxHp;
        //ゲームオーバーを可能にする
        _gameover = true;
        _audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //ダメージ分HPバーを短くする
            _audiosource.PlayOneShot(DamageSE);
            _currentHP = Mathf.Clamp(_currentHP - _enemydamage, 0, _maxHp);
            HpBar.fillAmount = _currentHP / _maxHp;
            Debug.Log(_currentHP);
            
        }
        
    }
    private void Update()
    {

        if (_currentHP == 0 && _gameover == true)
        {
            //HP0でゲームオーバー可能なら時間を止めてテキストとボタンを出す
            playeraudiosource.Stop();
            _gameover = false;
            Debug.Log("GameOver");
            _GameOver.SetActive(true);
            _resultbutton.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void PlusHP()
    {
        _currentHP = Mathf.Clamp(_currentHP + _helse, 0, _maxHp);
        HpBar.fillAmount = _currentHP / _maxHp;
    }
}
