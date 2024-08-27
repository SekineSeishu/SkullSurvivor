using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _result;
    public GameObject GameOver;
    public GameObject GameClear;
    public string LoadScene;

    public void StartButton()
    {
        SceneManager.LoadScene(LoadScene);
    }

    public void resultButton()
    {
        GameOver.SetActive(false);
        GameClear.SetActive(false);
        Instantiate(_result, gameObject.transform);
    }

    public void closeButton()
    {
        SceneManager.LoadScene(0);
        Destroy(_result);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
