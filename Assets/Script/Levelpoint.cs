using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelpoint : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;
    [SerializeField]private AudioSource _audiosorce;
    public AudioClip _getSE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //経験値ゲット時にSEを流して消す
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _levelManager._exp++;
            _audiosorce.PlayOneShot(_getSE);
            Debug.Log(_levelManager._exp);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
