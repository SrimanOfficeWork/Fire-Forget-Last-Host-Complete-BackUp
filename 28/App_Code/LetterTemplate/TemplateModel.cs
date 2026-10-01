using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextEditor.Model
{
    public class TemplateModel
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string HTMLSource { get; set; }
        public List<TemplateField> TemplateFields { get; set; }
    }

}