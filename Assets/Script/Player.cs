using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
	[SerializeField] private Skill _skill;//スキルデータ
	public float _speed = 0.5f;//移動速度
	SpriteRenderer _sp;//プレイヤーの向き
	public float _attack = 1.0f;//攻撃力
	private Animator animator;


	// Start is called before the first frame update
	void Start()
	{
		_sp = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		// 移動処理
		// 現在位置をPositionに代入
		Vector2 Position = transform.position;

		if (Input.GetKey(KeyCode.A))
		{
			_sp.flipX = false;
			// 代入したPositionに対して加算減算を行う
			Position.x -= _speed;
		}
		else if (Input.GetKey(KeyCode.D))
		{
			//キャラクターを反転させる
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
		// 現在の位置に加算減算を行ったPositionを代入する
		transform.position = Position;
	}

	//攻撃力アップ
	public void attackUp()
	{
		_attack += _skill._attack;

    }
}


