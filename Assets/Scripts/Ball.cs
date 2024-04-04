/*
	Title:
	
	Description:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Ball : MonoBehaviour
{
	public GameObject explosion;
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Block")
		{
			var obj = GameObject.Instantiate(explosion);
			obj.transform.position = collision.transform.position;//在方块的位置 创建爆炸效果
			GameObject.Destroy(collision.gameObject);//删除方块
			GameObject.Destroy(obj, 1);//删除特效

		}
	}

}

