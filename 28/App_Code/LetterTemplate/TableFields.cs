using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextEditor.Model
{
    public class TableVariables
    {
        public string TableName { get; set; }
        public List<TableColumns> ColumnNames { get; set; }
    }

    public class TableColumns
    {
        public string ColumnName { get; set; }
        public int OrderBy { get; set; }
    }
}