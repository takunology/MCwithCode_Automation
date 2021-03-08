using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Part10
{
    /// <summary>
    /// Minecraft に投げるコマンド
    /// </summary>
    public class Commands : Rcon
    {
        //↑ ここまで Part8 (省略)

        //ここから Part10
        public async Task<List<SlotItem>> GetChestItems(int x, int y, int z)
        {
            await rcon.ConnectAsync();

            int ChestItemSlot = 27;
            List<SlotItem> ChestItems = new List<SlotItem>();

            for (int i = 0; i < ChestItemSlot; i++)
            {
                string result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}]");
                if (!result.Contains("no"))
                {
                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Slot");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemSlot = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].id");
                    result = result.Substring(result.IndexOf("\""));
                    string ItemID = Regex.Replace(result, @"[^a-zA-Z:_]", "");

                    result = await rcon.SendCommandAsync($"/data get block {x} {y} {z} Items[{i}].Count");
                    result = result.Substring(result.IndexOf("data"));
                    int ItemCount = int.Parse(Regex.Replace(result, @"[^0-9]", ""));

                    ChestItems.Add(new SlotItem(ItemSlot, ItemID, ItemCount));
                }
            }
            return ChestItems;
        }

        public async Task SetChestItems(int x, int y, int z, List<SlotItem> SlotItems)
        {
            // storage -> append -> merge to chest -> remove
            await rcon.ConnectAsync();
            await rcon.SendCommandAsync("/data merge storage chestitems {Items:[]}");

            foreach (var item in SlotItems.ToNBT())
            {
                await rcon.SendCommandAsync($"/data modify storage chestitems Items append value {item}");
                await rcon.SendCommandAsync($"/data modify block {x} {y} {z} Items set from storage chestitems Items");
            }
            await rcon.SendCommandAsync($"/data remove storage chestitems Items");
        }
    }
}