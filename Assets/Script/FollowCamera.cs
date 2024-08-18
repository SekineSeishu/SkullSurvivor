using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    GameObject playerobj;
    Player player;//�v���C���[�̃X�N���v�g
    Transform playertransform;

    void Start()
    {
        playerobj = GameObject.FindGameObjectWithTag("Player");
        player = GetComponent<Player>();
        playertransform = playerobj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }
    void MoveCamera()
    {
        transform.position = new Vector3(playertransform.position.x, playertransform.position.y,-10);
    }
}
