using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _result;
    [SerializeField] private AudioClip _clickSE;
    private AudioSource _audio;
    [SerializeField] private GameObject _startUI;
    [SerializeField] private GameObject _skillList;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _gameClear;
    [SerializeField] private string LoadScene;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    //�Q�[����ʂɍs��
    public void StartButton()
    {
        _audio.PlayOneShot(_clickSE);
        SceneManager.LoadScene(LoadScene);
    }

    public void SkillListButton()
    {
        TMP_Text _buttonText = GetComponentInChildren<TMP_Text>();
        if (_buttonText.text == "�X�L���ꗗ")
        {
            _buttonText.text = "�߂�";
            _startUI.SetActive(false);
            _skillList.SetActive(true);
        }
        else
        {
            _buttonText.text = "�X�L���ꗗ";
            _startUI.SetActive(true);
            _skillList.SetActive(false);
        }

    }

    //���U���g��ʂ�\��
    public void resultButton()
    {
        _audio.PlayOneShot(_clickSE);
        _gameOver.SetActive(false);
        _gameClear.SetActive(false);
        Instantiate(_result, gameObject.transform);
    }

    //�^�C�g����ʂɖ߂�
    public void closeButton()
    {
        _audio.PlayOneShot(_clickSE);
        SceneManager.LoadScene(0);
        Destroy(_result);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
