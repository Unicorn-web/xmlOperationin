/*
	Title:
	
	Description:
	
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;//xml文件操作命名空间
using UnityEngine.UI;
using System.IO;//IO文件流操作命名空间

public struct Item
{
	public int id;
	public string name;

	public Item(int _id,string _name)
	{
		id = _id;
		name = _name;
	}
}
public class Hero
{
	public string name;
	public int hp;
	public int def;
	public int atk;
	public List<Item> bag = new List<Item>();

	public Hero(string _name,int _atk,int _def,int _hp)
	{
		name = _name;
		atk = _atk;
		def = _def;
		hp = _hp;
	}
}

public class XMLFileLoad : MonoBehaviour
{
	List<Hero> heros;//游戏数据

	public Text xmlText;//数据显示组件

	string url;

	private void Start()
	{
		url = Application.dataPath + "/XML/";


		#region IO文件流操作
		if (!Directory.Exists(url))//判断文件夹是否存在
		{
			//不存在则创建该目录
			Directory.CreateDirectory(url);
		}
		else//存在该目录 测试读取一个文件内容
		{
			//判断 文件存在否
			if (File.Exists(url + "file.txt"))
			{
				//读取文件内容
				var str = File.ReadAllText(url + "file.txt");
				Debug.Log("读取到" + url + "file.txt" + "文件内容：" + str);

				//删除文件
				//File.Delete(url + "file.txt");
				//Debug.Log("删除文件成功！");

				//创建文件
				if (!File.Exists(url + "love.txt"))
				{
					File.Create(url + "love.txt");
					Debug.Log("创建文件成功！" + url + "love.txt");
				}


				File.WriteAllText(url + "love.txt", url);
			}
		}
		#endregion


		//Application.dataPath 资源文件夹所在路径  动态的
		Debug.Log("当前Asset资源文件夹位置：" + Application.dataPath);

		heros = new List<Hero>();
		//添加游戏数据
		var hero = new Hero("赵云",35,12,1000);
		hero.bag.Add(new Item(10025,"青釭剑"));
		hero.bag.Add(new Item(10026,"大还丹"));
		hero.bag.Add(new Item(10035,"铁剑"));

		var hero1 = new Hero("马超", 32, 11, 1100);
		hero1.bag.Add(new Item(10029, "大宛马"));
		hero1.bag.Add(new Item(10026, "大还丹"));
		hero1.bag.Add(new Item(10035, "铁剑"));

		var hero2 = new Hero("关羽", 36, 11, 1200);
		hero2.bag.Add(new Item(10099, "赤兔马"));
		hero2.bag.Add(new Item(100222, "青龙偃月刀"));
		hero2.bag.Add(new Item(10035, "铁剑"));

		heros.Add(hero);
		heros.Add(hero1);
		heros.Add(hero2);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W))//按键写入文件 永久保存游戏数据  xml文件写入
		{
			WriteXMLFile("HeroInfo.xml");
			Debug.Log("保存文件完毕！");
		}
		if (Input.GetKeyDown(KeyCode.R))//读取加载 xml文件
		{
			ReadXMLFile(url + "HeroInfo.xml");
		}


	}


	#region 写入操作
	void WriteXMLFile(string _fileName)
	{
		if (!File.Exists(url + _fileName))
		{
			File.Create(url + _fileName);
			Debug.Log("创建文件成功！" + url + _fileName);
		}
		//创建文档对象
		XmlDocument doc = new XmlDocument();

		//创建 root 标签
		var root = doc.CreateElement("root");
		doc.AppendChild(root); //root标签添加到文档对象

		//创建 n个 hero 标签
		foreach (var heroData in heros)//循环遍历英雄数据
		{
			var hero = doc.CreateElement("hero");
			root.AppendChild(hero);//添加到 root中

			//填写数据到标签 
			hero.SetAttribute("name", heroData.name);
			hero.SetAttribute("atk", heroData.atk.ToString());
			hero.SetAttribute("def", heroData.def.ToString());
			hero.SetAttribute("hp", heroData.hp.ToString());

			//创建背包 bag标签
			var bag = doc.CreateElement("bag");
			hero.AppendChild(bag);
			foreach (var itemData in heroData.bag)//遍历英雄背包数据 创建道具标签
			{
				var item = doc.CreateElement("item");
				bag.AppendChild(item);

				//赋值数据
				item.SetAttribute("id", itemData.id.ToString());
				item.SetAttribute("name", itemData.name);
			}
		}


		//保存文件
		Debug.Log("标签数据创建完毕 准备保存文件...");
		doc.Save(url + _fileName);

	}
	#endregion
	//写入操作


	#region 读取操作
	void ReadXMLFile(string _url)
	{
		//创建文档对象
		var doc = new XmlDocument();
		doc.Load(_url);

		//读取 root标签
		var root = doc.SelectSingleNode("root") as XmlElement;
		foreach (XmlElement hero in root.ChildNodes)//遍历所有 英雄标签
		{
			//填写数据到界面
			xmlText.text += hero.GetAttribute("name") + ":{";

			//遍历背包
			var bag = hero.SelectSingleNode("bag") as XmlElement;
			foreach (XmlElement item in bag.ChildNodes)
			{
				xmlText.text += item.GetAttribute("name") + " ";
			}
			xmlText.text += "} \n";
		}
	}
	#endregion
}

