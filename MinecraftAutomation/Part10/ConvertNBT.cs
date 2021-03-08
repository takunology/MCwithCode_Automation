using System;
using System.Collections.Generic;
using System.Text;

namespace Part10
{
    public static class ConvertNBT
    {
        public static List<string> ToNBT(this List<SlotItem> ItemList)
        {
            List<string> NBT = new List<string>();

            foreach(var item in ItemList)
            {
                NBT.Add("{" + $"Slot:{item.ItemSlot}b,id:\"{item.ItemID}\",Count:{item.ItemCount}b" + "}");
            }

            return NBT;
        }
    }
}
