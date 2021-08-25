using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MVC_.model;
using MVC_.model.entity;
using MVC_.model.util;

namespace MVC_.model
{
    public class Model
    {
        private List<object> inputObjList;
        
        public Model(string path)
        {
            //pdf转txt
            PdfUtil pdfUtil = new PdfUtil(path);
            pdfUtil.convertPdfToText();
            pdfUtil.txtFilter();
            //txt转obj
            TxtHelper txtHelper = new TxtHelper();
            inputObjList = txtHelper.convertTextToObject("临时最终.txt");
        }

       

        public List<object> getObjList()
        {
            return inputObjList;
        }

        
    }
}
