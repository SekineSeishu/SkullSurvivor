using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // 時間を表示するUIテキスト
    [SerializeField] private GameObject GameClear;
    [SerializeField] private GameObject result;
    private bool Clear;
    public AudioSource playeraudiosource;

    public float elapsedTime = 0f; // 経過時間（秒単位）

    // Start is called before the first frame update
    void Start()
    {
        //ゲームクリアを可能にする
        Clear = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // 経過時間を更新
        elapsedTime += Time.deltaTime;

        // 経過時間を分と秒に変換
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // 時間をテキストに表示
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (elapsedTime >= 180 && Clear == true)
        {
            //時間が達してクリア可能状態なら時間を止めてテキストとボタンを表示
            playeraudiosource.Stop();
            GameClear.SetActive(true);
            result.SetActive(true);
            Time.timeScale = 0;
            Clear = false;
        }
    }
}
