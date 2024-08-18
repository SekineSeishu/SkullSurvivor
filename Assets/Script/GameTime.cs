using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // ���Ԃ�\������UI�e�L�X�g
    [SerializeField] private GameObject GameClear;
    [SerializeField] private GameObject result;
    private bool Clear;
    public AudioSource playeraudiosource;

    public float elapsedTime = 0f; // �o�ߎ��ԁi�b�P�ʁj

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���N���A���\�ɂ���
        Clear = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // �o�ߎ��Ԃ��X�V
        elapsedTime += Time.deltaTime;

        // �o�ߎ��Ԃ𕪂ƕb�ɕϊ�
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // ���Ԃ��e�L�X�g�ɕ\��
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (elapsedTime >= 180 && Clear == true)
        {
            //���Ԃ��B���ăN���A�\��ԂȂ玞�Ԃ��~�߂ăe�L�X�g�ƃ{�^����\��
            playeraudiosource.Stop();
            GameClear.SetActive(true);
            result.SetActive(true);
            Time.timeScale = 0;
            Clear = false;
        }
    }
}
