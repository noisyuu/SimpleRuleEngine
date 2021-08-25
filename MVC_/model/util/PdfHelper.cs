using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.Text.RegularExpressions;

namespace MVC_.model.util 
{


    public class PdfUtil
    {
        PdfReader pdfReader = null;

        string filePath;
        public PdfUtil(string filePath)
        {
            this.filePath = filePath;

            loadPdf(filePath);
        }


        public void loadPdf(string filePath)
        {

            try
            {
                pdfReader = new PdfReader(filePath);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

        }

        public bool loadPdf(string filePath, string msg)
        {

            msg = "";

            try
            {

                pdfReader = new PdfReader(filePath);

                convertPdfToText();
            }
            catch (Exception e)
            {
                msg = e.Message;
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {

                Console.WriteLine("loading pdf success");
            }
            return true;
        }


        public bool convertPdfToText()
        {
            try
            {
                if (File.Exists("临时文件-1.txt"))
                    File.Delete("临时文件-1.txt");
                int pageCount = pdfReader.NumberOfPages;
                for (int pg = 1; pg <= pageCount; pg++)
                {
                    var value = PdfTextExtractor.GetTextFromPage(pdfReader, pg);


                    File.AppendAllText("临时文件-1.txt", value, System.Text.Encoding.Default);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            return true;
        }

        public void showPdf()
        {
            for (int i = 1; i < pdfReader.NumberOfPages; i++)
            {
                Console.WriteLine(PdfTextExtractor.GetTextFromPage(pdfReader, i));
            }
        }

        public void txtFilter()
        {
            if (File.Exists("临时最终.txt")) File.Delete("临时最终.txt");
            string journal = "";//存储journal标签后的值
            string date = "";
            string datePattern = @"[0-9][0-9]/[0-1][0-9]/[1-2][0-9][0-9][0-9]";
            string[] lines = File.ReadAllLines("临时文件-1.txt", System.Text.Encoding.Default);
            bool titleFlag = false;
            bool dataFlag = false;
            bool journalRepeatFlag = false;

            foreach (string line in lines)
            {

                if (line.Trim() == "") continue;//跳过空白行
                if (line.Contains("END OF REPORT")) break;//end of report
                if (line.Contains("G/L DATE"))
                {
                    date = Regex.Match(line, datePattern).ToString();
                }

                if (line.Contains("PROGRAM")) titleFlag = false;

                //获取JOURNAL 后的字符串
                if (line.Contains("JOURNAL"))
                {

                    titleFlag = true;
                    if (journalRepeatFlag) continue;//如果journal重复，跳过此行数据

                    string[] JournalElement = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase); ;
                    journal = JournalElement[1];

                       
                    File.AppendAllText("临时最终.txt", journal + ";" + date + "\n");
                    journalRepeatFlag = true;
                    continue;


                }

                if (!titleFlag) continue;//跳过表头数据

                if (line.Contains("ACCOUNT") && line.Contains("CREDIT") && line.Contains("DEBIT")) //输出台头
                {
                    journalRepeatFlag = false;
                        
                    string title = "ACCOUNT;CREDIT;DEBIT;TYPE";
                    File.AppendAllText("临时最终.txt", title + "\n"); continue;
                }


                if (line.Contains("-----"))
                {
                    dataFlag = !dataFlag;
                    continue; //忽略-------
                }

                string[] data = Regex.Split(line, "\\s+", RegexOptions.IgnoreCase);
                if (dataFlag)
                {
                    string row = data[0] + ";" + data[1] + ";" + data[2] + ";" + journal;
                    File.AppendAllText("临时最终.txt", row + "\n");
                        
                }
                else
                {
                    string row = data[0] + ";" + data[1];
                    File.AppendAllText("临时最终.txt", row + "\n");
                        
                }



;
            }
        }

    }
    

    
}
