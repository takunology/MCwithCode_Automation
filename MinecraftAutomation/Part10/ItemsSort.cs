using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Part10
{
    public static class ItemsSort
    {
        //アイテムID順に並べ替え
        public static List<SlotItem> SortByID (this List<SlotItem> SlotItems)
        {
            List<SlotItem> SortedItemLIst = new List<SlotItem>();
            SortedItemLIst = SlotItems.OrderBy(x => x.ItemID).ToList();
            return SlotNumbering(SortedItemLIst);
        }
        
        //アイテムID順に並べ替え
        public static List<SlotItem> ReverseSortByID(this List<SlotItem> SlotItems)
        {
            List<SlotItem> SortedItemLIst = new List<SlotItem>();
            SortedItemLIst = SlotItems.OrderByDescending(x => x.ItemID).ToList();
            return SlotNumbering(SortedItemLIst);
        }

        //並び変えたアイテムをナンバリング
        private static List<SlotItem> SlotNumbering(List<SlotItem> SlotItemList)
        {
            List<SlotItem> Items = new List<SlotItem>();
            for (int i = 0; i < SlotItemList.Count; i++)
            {
                Items.Add(new SlotItem(i, SlotItemList[i].ItemID, SlotItemList[i].ItemCount));
            }
            return Items;
        }
    }
}
