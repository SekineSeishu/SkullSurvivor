using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText; // ���Ԃ�\������UI�e�L�X�g
    [SerializeField] private GameObject _gameClear;//�Q�[���N���A�I�u�W�F�N�g
    [SerializeField] private GameObject _result;//���U���g
    [SerializeField] private AudioSource _playerAudioSource;
    private bool _clear;//�N���A�t���O

    private float _elapsedTime = 0f; // �o�ߎ��ԁi�b�P�ʁj

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���N���A���\�ɂ���
        _clear = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        _elapsedTime += Time.deltaTime;

        // �o�ߎ��Ԃ𕪂ƕb�ɕϊ�
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);

        // ���Ԃ��e�L�X�g�ɕ\��
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (_elapsedTime >= 180 && _clear == true)
        {
            //���Ԃ��B���ăN���A�\��ԂȂ玞�Ԃ��~�߂ăe�L�X�g�ƃ{�^����\��
            _playerAudioSource.Stop();
            _gameClear.SetActive(true);
            _result.SetActive(true);
            Time.timeScale = 0;
            _clear = false;
        }
    }
}
