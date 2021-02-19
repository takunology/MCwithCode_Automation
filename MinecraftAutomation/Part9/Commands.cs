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
    }
}