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
    //ゲーム画面に行く
    public void StartButton()
    {
        _audio.PlayOneShot(_clickSE);
        SceneManager.LoadScene(LoadScene);
    }

    public void SkillListButton()
    {
        TMP_Text _buttonText = GetComponentInChildren<TMP_Text>();
        if (_buttonText.text == "スキル一覧")
        {
            _buttonText.text = "戻る";
            _startUI.SetActive(false);
            _skillList.SetActive(true);
        }
        else
        {
            _buttonText.text = "スキル一覧";
            _startUI.SetActive(true);
            _skillList.SetActive(false);
        }

    }

    //リザルト画面を表示
    public void resultButton()
    {
        _audio.PlayOneShot(_clickSE);
        _gameOver.SetActive(false);
        _gameClear.SetActive(false);
        Instantiate(_result, gameObject.transform);
    }

    //タイトル画面に戻る
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
