using System;
using System.Collections.Generic;
using System.Text;

namespace Part10
{
    public class SlotItem
    {
        public int ItemSlot { get; set; }
        public string ItemID { get; set; }
        public int ItemCount { get; set; }

        public SlotItem(int Slot, string ID, int Count)
        {
            ItemSlot = Slot;
            ItemID = ID;
            ItemCount = Count;
        }
    }
}