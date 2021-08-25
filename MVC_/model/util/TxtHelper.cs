using MVC_.model.entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVC_.model.util
{
    class TxtHelper
    {

        public List<object> convertTextToObject(string path)
        {
            List<object> inputObjList = new List<object>();
            string[] lines = File.ReadAllLines(path);
            string date1 = "DDMMYYYY";


            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("ACCOUNT;CREDIT;DEBIT;TYPE"))
                {
                    if (i - 1 >= 0)
                    {
                        date1 = Regex.Match(lines[i - 1], @"[\d{2}/]{2}\d{4}").ToString();
                    }

                    continue;
                }

                string[] rowData = lines[i].Split(';');
                if (rowData.Length > 2)
                {

                    dynamic row = new EntityWithDelegate();
                    row.account = rowData[0];
                    row.credit = rowData[1];
                    row.debit = rowData[2];
                    row.journal = rowData[3];
                    row.date = date1;
                    inputObjList.Add(row);
                }

            }

            return inputObjList;
        }

    }
}
