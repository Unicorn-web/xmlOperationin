using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

class ItemPropFactory
{
    // 道具库
    Dictionary<int, ItemProp> itemLib = new Dictionary<int, ItemProp>();
    // 从xml中读取items
    void LoadItems(string _path)
    {
        Debug.Log(_path);
        XmlDocument doc = new XmlDocument();
        doc.Load(_path);
        // 必须强转
        var root = doc.SelectSingleNode("root") as XmlElement;
        foreach(XmlElement node in root.ChildNodes)
        {
            ItemProp item = new ItemProp();

            item.type = (ItemType)int.Parse(node.GetAttribute("type"));
            if (item.type == ItemType.IT_Drug)
            {
                DrugProp drug = new DrugProp();
                drug.hp = int.Parse(node.GetAttribute("hp"));
                drug.mp = int.Parse(node.GetAttribute("mp"));
                item = drug;
            }
            else if (item.type == ItemType.IT_Equiment)
            {
                EquipmentProp equipment = new EquipmentProp();
                equipment.atk = int.Parse(node.GetAttribute("atk"));
                equipment.def = int.Parse(node.GetAttribute("def"));
                item = equipment;
            }
            else if(item.type == ItemType.IT_None)
            {
                item = new ItemProp();
                //continue;
            }
            item.id = int.Parse(node.GetAttribute("id"));
            item.name = node.GetAttribute("name");
            item.iconPath = node.GetAttribute("iconPath");
            item.buyPrice = int.Parse(node.GetAttribute("buyPrice"));
            item.sellPrice = int.Parse(node.GetAttribute("sellPrice"));
            item.desc = node.GetAttribute("desc");
            item.maxNum = int.Parse(node.GetAttribute("maxNum"));
            // 添加到库中，在内存中随时访问
            itemLib.Add(item.id,item);
        }
    }

    // 从Libitem里获取item道具
    public ItemProp CreateItemById(int _id)
    {
        if (!itemLib.ContainsKey(_id))
        {
            Debug.Log("没有找到对应的_id");
            return null;
        }
        // 用克隆是为了防止后续操作对itemLib数据进行修改，所以此处用的item是基于itemLib中所指向的对象创建的新对象，不是itemLib中所指向的对象
        return itemLib[_id].Clone();
    }


    #region 单例
    ItemPropFactory() {
        LoadItems(Application.dataPath + "/XML/ItemConfig.xml");
    }
    // 只读的Instance用例
    public static readonly ItemPropFactory Instance = new ItemPropFactory();
    #endregion
}
