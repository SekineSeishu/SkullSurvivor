using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
	public float speed = 0.5f;
	SpriteRenderer sp;
	public float Attack = 1.0f;
	private Animator animator;


	// Start is called before the first frame update
	void Start()
    {
		sp = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		// �ړ�����
		// ���݈ʒu��Position�ɑ��
		Vector2 Position = transform.position;

		if (Input.GetKey(KeyCode.A))
		{
			sp.flipX = false;
			// �������Position�ɑ΂��ĉ��Z���Z���s��
			Position.x -= speed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			//�L�����N�^�[�𔽓]������
			sp.flipX = true;
			Position.x += speed;
		}
		else if (Input.GetKey(KeyCode.W))
		{
			Position.y += speed;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Position.y -= speed;
		}
		// ���݂̈ʒu�ɉ��Z���Z���s����Position��������
		transform.position = Position;
	}
		
	}


