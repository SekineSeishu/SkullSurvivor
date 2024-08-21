using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
	[SerializeField] private Skill _skill;//�X�L���f�[�^
	public float _speed = 0.5f;//�ړ����x
	SpriteRenderer _sp;//�v���C���[�̌���
	public float _attack = 1.0f;//�U����
	private Animator animator;


	// Start is called before the first frame update
	void Start()
	{
		_sp = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		// �ړ�����
		// ���݈ʒu��Position�ɑ��
		Vector2 Position = transform.position;

		if (Input.GetKey(KeyCode.A))
		{
			_sp.flipX = false;
			// �������Position�ɑ΂��ĉ��Z���Z���s��
			Position.x -= _speed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			//�L�����N�^�[�𔽓]������
			_sp.flipX = true;
			Position.x += _speed;
		}
		else if (Input.GetKey(KeyCode.W))
		{
			Position.y += _speed;
		}
		else if (Input.GetKey(KeyCode.S))
		{
			Position.y -= _speed;
		}
		// ���݂̈ʒu�ɉ��Z���Z���s����Position��������
		transform.position = Position;
	}

	//�U���̓A�b�v
	public void attackUp()
	{
		_attack += _skill._attack;

    }
}


