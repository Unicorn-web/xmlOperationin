using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EquipmentProp : ItemProp
{
    public int atk { get; set; }
    public int def { get; set; }

    public EquipmentProp()
    {
        type = ItemType.IT_Equiment;
        atk = 0;
        def = 0;
    }

    public EquipmentProp(EquipmentProp equipmentProp):base(equipmentProp)
    {
        
        atk = equipmentProp.atk;
        def = equipmentProp.def;
    }

    public override ItemProp Clone()
    {
        EquipmentProp equipmentProp = new EquipmentProp(this);
        return equipmentProp;
    }
}
