using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelpoint : MonoBehaviour
{
    private AudioSource audiosorce;
    public AudioClip GetSE;
    // Start is called before the first frame update
    void Start()
    {
        audiosorce = GameObject.Find("LevelPoint").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelManager lManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        if (collision.gameObject.tag == "Player")
        {
            lManager._exp++;
            audiosorce.PlayOneShot(GetSE);
            Debug.Log(lManager._exp);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
