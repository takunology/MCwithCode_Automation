using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;

namespace Part8
{
    public class ReadFromExcel
    {
        //ブロックの種類を格納
        private List<List<List<string>>> BlockData = new List<List<List<string>>>();

        public ReadFromExcel(string path)
        {
            var Book = WorkbookFactory.Create(path);

            //そのブック内のシート数を取得
            int SHEET = Book.NumberOfSheets;
            
            for(int i = 0; i < SHEET; i++)
            {
                List<List<string>> RowData = new List<List<string>>();

                //そのシート内の行数を得る
                ISheet sheet = Book.GetSheetAt(i);
                int ROW = sheet.LastRowNum;         
                for(int j = 0; j < ROW; j++)
                {
                    List<string> ColData = new List<string>();
                    //その行数内の列数を得る
                    IRow row = sheet.GetRow(j);
                    int COL = row.LastCellNum;
                    for(int k = 0; k < COL; k++)
                    {
                        //その列のセル情報を得る
                        ICell CELL = row.GetCell(k);

                        ColData.Add(CELL.StringCellValue);
                        Console.WriteLine($"{i} {j} {k} : {ColData[k]}");
                    }

                    RowData.Add(ColData);
                }
                BlockData.Add(RowData);
            }
             
        }

        public List<List<List<string>>> GetBlockData()
        {
            // 外部クラスに BlockData を渡す
            return BlockData;
        }
    }
}
