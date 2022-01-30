using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;


namespace WebApp.ChainOfResponsibility.ChainOfResponsibility
{
    public class ExcelProcessHandler<T>:ProcessHandler
    {
        private DataTable GetTable(Object o)
        {
            var table = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(x=>table.Columns.Add(x.Name,x.PropertyType));

            var list = o as List<T>;

            list.ForEach(x =>
            {
                var values = type.GetProperties().Select(propertyInfo => propertyInfo.GetValue(x, null)).ToArray();

                table.Rows.Add(values);

            });

            return table;
        }

        public override object Handle(object o)
        {
            var wb = new XLWorkbook();

            var ds = new DataSet();

            ds.Tables.Add(GetTable(o));

            wb.Worksheets.Add(ds);

            var excelMemoryStream = new MemoryStream();

            wb.SaveAs(excelMemoryStream);

            return base.Handle(excelMemoryStream);
        }
    }
}
