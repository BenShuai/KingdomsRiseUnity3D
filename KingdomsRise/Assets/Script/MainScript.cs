using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour {

	public GameObject TuDiObj;//基本土地板块对象

	public GameObject Shu1;//树1 对象【小树】
	public GameObject Shu2;//树2 对象
	public GameObject Shu3;//树3 对象
	public GameObject Shu4;//树4 对象
	public GameObject Shu5;//树5 对象

	public float speed=30;//相机移动速度

	public GameObject Man1;//人1

	// Use this for initialization
	void Start () {
		//初始化土地
		for(int j=0;j<200;j++){
			for(int i=0;i<200;i++){
				GameObject TuDiObj1 = GameObject.Instantiate(TuDiObj);
				TuDiObj1.transform.position=new Vector3(i*10f,0.1f,j*10f);
			}
		}

		//初始化树木
		for(int j=1;j<100;j++){
			for(int i=1;i<100;i++){
				GameObject shuO = GameObject.Instantiate(Shu1);
				shuO.transform.position=new Vector3(i*6f,0f,j*6f);

				int num = Random.Range(-180, 180);//随机数，旋转角度
				shuO.transform.Rotate(new Vector3(0f, 0f, num));
			}
		}

		GameObject Ren1 = GameObject.Instantiate(Man1);
		Ren1.transform.position=new Vector3(this.transform.position.x, 0, this.transform.position.z + 25);
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 player_postion = transform.position;
		float x = player_postion.x;
		float y = player_postion.y;
		float z = player_postion.z;

		//// 设置应用了当前函数的GameObject的坐标
		//// 1.直接赋值
		//this.GetComponent<Transform>().position = player_postion;
		//// 2.在某GameObject的基础上加
		//this.GetComponent<Transform>().position = new Vector3(player_postion.x, player_postion.y + 7.79F, player_postion.z - 15);
		//// 3.或者是
		//this.GetComponent<Transform>().position = player_postion + new Vector3(0, 7.79F, -15);

		if((z>=4890 && v>0) || (z<=-5020 && v<0) ){
			v=0;
		}
		if((x>=4950 && h>0) || (x<=-4950 && h<0)){
			h=0;
		}
		
		transform.Translate(new Vector3(h,0,v) * Time.deltaTime * speed);
		Man1.transform.position=new Vector3(this.transform.position.x, 0, this.transform.position.z + 5);
		
		Debug.Log(x+","+y+","+z);
		
	}
}
