using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField] private Skill _skill;//�X�L���f�[�^
    [SerializeField] private Image HpBar;//HP�o�[
    public float _maxHp = 100f;//�ő�HP
    public float _enemydamage = 5f;//�G�ɓ��������ۂ̃_���[�W
    [SerializeField] private GameObject _GameOver;//�Q�[���I�[�o�[�e�L�X�g
    [SerializeField] private GameObject _resultbutton;//���U���g�{�^��
    public AudioSource playeraudiosource;
    private bool _gameover;//�Q�[���I�[�o�[�t���O

    private float _currentHP;

    private AudioSource _audiosource;
    public AudioClip DamageSE;

    private void Awake()
    {

        _currentHP = _maxHp;
        //�Q�[���I�[�o�[���\�ɂ���
        _gameover = true;
        _audiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //�_���[�W��HP�o�[��Z������
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
            //HP0�ŃQ�[���I�[�o�[�\�Ȃ玞�Ԃ��~�߂ăe�L�X�g�ƃ{�^�����o��
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
        _currentHP = Mathf.Clamp(_currentHP + _skill._helse, 0, _maxHp);
        HpBar.fillAmount = _currentHP / _maxHp;
    }
}
