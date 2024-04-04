using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DrugProp : ItemProp
{
    public int hp { get; set; }
    public int mp { get; set; }

    //默认构造函数 + 拷贝构造函数 + 重写基类Clone 虚函数  

    // 构造函数
    public DrugProp()
    {
        type = ItemType.IT_Drug;
        hp = 0;
        mp = 0;
    }

    // 拷贝构造 继承了base()获取到基类ItemProp拷贝构造 其他参数初始值 函数中只对hp，mp赋值将会替代初始值,type可以不用重新赋值，因为Drug就是drug
    public DrugProp(DrugProp drugProp): base(drugProp)
    {
        
        hp = drugProp.hp;
        mp = drugProp.mp;
    }

    // 重写 虚函数
    public override ItemProp Clone()
    {
        Debug.Log("获取药物的克隆了");
        var drugProp = new DrugProp(this); 
        return drugProp;
    }
}

