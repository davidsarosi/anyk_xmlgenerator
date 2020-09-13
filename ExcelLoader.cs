using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Szamlakezeles
{
    public class ExcelLoader
    {
        public string Path;
        Application exxcel = new Application();
        Workbook wb;
        Worksheet ws;

        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint ProcessId);

        public void Copy(string newFile)
        {
            File.Copy(Path,newFile);
        }

        public ExcelLoader(string path)

        {
            this.Path = path;
            try
            {
                exxcel.DisplayAlerts = false;
                wb = exxcel.Workbooks.Open(Path, false, false);
                ws = wb.ActiveSheet;
               
            }
            catch (Exception e)
            {
                // ignored
            }
        }
        public void WriteToConsole()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    string cellvalue = ReadCell(i, j);
                    if (cellvalue == null)
                    {
                        break;
                    }
                    Console.Write(cellvalue + " ");
                }
                Console.WriteLine("\n");
            }
        }
        public string ReadCell(int i, int j)
        {
            i++; j++;
            var cellValue = ws.Cells[i, j].Value;
            if (cellValue == null)
            {
                return null;
            }
            return cellValue.ToString();
        }
        public virtual void Close()
        {
            try
            {
                //cleanup
                GC.Collect();
                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
               // Marshal.ReleaseComObject(exxcel);
                Marshal.ReleaseComObject(ws);

                //close and release
                
                wb.Close(true,this.Path);
                Marshal.ReleaseComObject(wb);

                //quit and release

                exxcel.Quit();
                Marshal.FinalReleaseComObject(exxcel);
            }
            catch (Exception e)
            {
                int hWnd = exxcel.Application.Hwnd;
                uint processID;
                GetWindowThreadProcessId((IntPtr)hWnd, out processID);
                Process[] procs = Process.GetProcessesByName("excel");
                foreach (Process p in procs)
                {
                    if (p.Id == processID)
                        p.Kill();
                }
                Marshal.FinalReleaseComObject(exxcel);
            }
           
        }

        public void WriteCell(string msgstr, int i, int j)
        {
            //A megadott helyre, a megadott szöveget beírom.
            i++;j++;
            ws.Cells[i, j].Value = msgstr;
            if(ws.Cells[i, j].Comment != null)
            {
                ws.Cells[i, j].Comment.Delete();
            }
            //ws.Cells[i, j].AddComment("Módositva: " + DateTime.Now.ToString())
        }

        public void ColorCell(System.Drawing.Color color, int i, int j)
        {
            i++; j++;
            //Majd megint meg kell növelni a j-t hogy a fejlécet átugorjuk
            i++;
            ws.Cells[i, j].Interior.Color = color;
            //Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)ws.Cells[1, (i + 1)];
            //rng.Interior.Color = color;
            //Microsoft.Office.Interop.Excel.Range formatRange;
            //Range r = (Range)ws.Range[ws.Cells[1, 1], ws.Cells[2, 2]].Cells;
            //Range x = ws.UsedRange;
            //formatRange = ws.Range["A1","A2"];
            //formatRange.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
            //r.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Red);
        }

        public void SetBorders()
        {
            ws.UsedRange.Cells.Borders.LineStyle = XlLineStyle.xlContinuous;
        }
        public void SetAlignmentLeft()
        {
            ws.UsedRange.Cells.HorizontalAlignment = XlHAlign.xlHAlignLeft;
        }


        internal void SaveAs(string result)
        {
            wb.SaveAs(result);
        }
        public int getWidth()
        {
            return ws.Columns.Count;
        }
        public int getHeight()
        {
            return ws.Rows.Count;
        }
        public void setCellBackgroundColor(int i, int j, System.Drawing.Color color)
        {
            try
            {
                ws.Cells[i + 1, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(color);
            }
            catch (Exception)
            {

            }
            
        }
        public void setCellComment(int i, int j, string comment)
        {
            try
            {
                ws.Cells[i + 1, j + 1].AddComment(comment);
            }
            catch (Exception)
            {
            }

        }
        public void Save()
        {
            //exxcel.DisplayAlerts = false;
            wb.Save();
            exxcel.ActiveWorkbook.Save();
        }

        public void AutoFit()
        {
            Microsoft.Office.Interop.Excel.Range usedrange = ws.UsedRange;
            usedrange.Columns.AutoFit();
        }
        public int GetRowCount()
        {
            int recursiveINT = GetRowCount(0, ws.Rows.Count);

            return recursiveINT;
        }
        public int GetRowCount(int first, int last)
        {
            // megkeresem azt az indexet, ami a tároló fele;
            int i = first + Convert.ToInt32((last-first + 1) / 2);
            string beforeI = ReadCell(i - 1, 0);
            string afterI = ReadCell(i + 1,0);
            if (beforeI != null && afterI == null)
            {
                return i;
            }
            else if (beforeI == null && afterI == null)
            {
                return GetRowCount(first,i);
            }
            else
            {
                return GetRowCount(i,last);
            }
        }

    }
}
