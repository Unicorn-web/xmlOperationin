using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//物品id
//public enum ItemID
//{
//    IT_None = 0,
//    ID_HP = 10,
//    ID_MP = 11,

//    ID_IronySword = 21,  //剑
//    //ID_WoodenSword, 
//    //ID_GoldenSword,

//    ID_IronyBow = 31,      //弓
//    ID_IronyAxe = 41,      //斧
//    ID_IronyJacket = 51,   //胸甲
//    ID_IronyHelmet = 61,   //头盔
//};

public enum ItemType
{
    IT_None,
    IT_Normal = 1,
    IT_Drug = 2,
    IT_Equiment = 3,
    IT_Material = 4,
}

public class ItemProp
{
    public int id { get; set; }      //自动属性 与public的字段区别在于2个访问器之前可以加访问权限，可以有效的控制这个字段的get和set，安全性和灵活性更高
    public ItemType type { get; set; }  //物品类型

    public string name { get; set; }
    public string desc { get; set; }
    public string iconPath { get; set; }  //物品图标的路径
    public int buyPrice { get; set; }     //购买的价格
    public int sellPrice { get; set; }    //卖出去的价格

    public int maxNum { get; set; }   //叠加上限  
    public int curNum = 0;            //当前道具的叠加数量，当前数据是一个动态的值，不应该是从Xml中创建出来的

    //C#中构造函数
    public ItemProp()
    {
        this.id = 0;
        this.type = ItemType.IT_None;

        this.name = "";
        this.desc = "";
        this.iconPath = "";
        this.buyPrice = 0;
        this.sellPrice = 0;

        this.maxNum = 0;
    }

    //C#中拷贝构造函数如何去写
    public ItemProp(ItemProp prop)
    {
        if (prop != null)
        {
            this.id = prop.id;
            this.type = prop.type;

            this.name = prop.name;
            this.desc = prop.desc;
            this.iconPath = prop.iconPath;
            this.buyPrice = prop.buyPrice;
            this.sellPrice = prop.sellPrice;

            this.curNum = prop.curNum;
            this.maxNum = prop.maxNum;  
        }

    }

    //克隆该对象的新对象
    public virtual ItemProp Clone()
    {
        ItemProp prop = new ItemProp(this);
        return prop;
    }


}

