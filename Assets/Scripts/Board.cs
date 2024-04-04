/*
	Title:
	
	Description:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Board : MonoBehaviour
{
	public float moveSpeed;

	public Vector2 boundary;//边界  x最小  y最大 范围

	bool isPlaying;

	//球
	public Rigidbody ball;
	private void Update()
	{
		transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0) * moveSpeed * Time.deltaTime);

		//限制移动
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x,boundary.x,boundary.y),//限制x方向范围
			transform.position.y,
			transform.position.z);


		//按空格键 发射球
		if (Input.GetKeyDown(KeyCode.Space) && !isPlaying)
		{
			isPlaying = true;
			ball.isKinematic = false;
			ball.velocity = new Vector3(10, 10, 0);//45° 方向速度

			//防止板子控制球的运动 脱离父子关系
			ball.transform.parent = null;
		}

	}
}

