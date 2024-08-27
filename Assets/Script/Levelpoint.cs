using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levelpoint : MonoBehaviour
{
    [SerializeField] public LevelManager _levelManager;//���x���̊Ǘ�
    [SerializeField]private AudioSource _audiosorce;//SE���Đ���
    public AudioClip _getSE;//�o���l�l����SE
    // Start is called before the first frame update
    void Start()
    {
       transform.parent =  GameObject.FindObjectOfType<LevelManager>().transform;
        _levelManager = GetComponentInParent<LevelManager>();
        _audiosorce = _levelManager.GetComponent<AudioSource>();
    }

    //�o���l�Q�b�g����SE�𗬂��ď���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _audiosorce.PlayOneShot(_getSE);
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
