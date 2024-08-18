using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //敵のダメージテキストを上に上昇する演出
        transform.Translate(0, 0.001f, 0);
    }
}
