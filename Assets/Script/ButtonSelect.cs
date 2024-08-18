using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSelect : MonoBehaviour
{
    public List<GameObject> Attackbuttons; 
    public List<GameObject> supprtbuttons;
    private AudioSource audiosource;
    public AudioClip LevelupSE;

    // Start is called before the first frame update
    void Start()
    {
        ActivateRandomButton();
        audiosource = GetComponent<AudioSource>();
        audiosource.PlayOneShot(LevelupSE);
    }

    void ActivateRandomButton()
    {
        //それぞれのスキルボタンをランダムで表示させる
        int randomIndex = Random.Range(0, Attackbuttons.Count);
        int randomIndex2 = Random.Range(0, supprtbuttons.Count);

        Attackbuttons[randomIndex].SetActive(true);
        supprtbuttons[randomIndex2].SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
