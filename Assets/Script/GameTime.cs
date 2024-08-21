using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText; // 時間を表示するUIテキスト
    [SerializeField] private GameObject _gameClear;//ゲームクリアオブジェクト
    [SerializeField] private GameObject _result;//リザルト
    [SerializeField] private AudioSource _playerAudioSource;
    private bool _clear;//クリアフラグ

    private float _elapsedTime = 0f; // 経過時間（秒単位）

    // Start is called before the first frame update
    void Start()
    {
        //ゲームクリアを可能にする
        _clear = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を更新
        _elapsedTime += Time.deltaTime;

        // 経過時間を分と秒に変換
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);

        // 時間をテキストに表示
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (_elapsedTime >= 180 && _clear == true)
        {
            //時間が達してクリア可能状態なら時間を止めてテキストとボタンを表示
            _playerAudioSource.Stop();
            _gameClear.SetActive(true);
            _result.SetActive(true);
            Time.timeScale = 0;
            _clear = false;
        }
    }
}
