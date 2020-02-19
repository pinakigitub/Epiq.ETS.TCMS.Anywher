using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epiq.ETS.TCMS.Anywhere.Testing.E2ETest.Test_Framework.Pages
{
    public class Link
    {
        public string Href { get; set; }
        public string Text { get; set; }

        public Link() { }

        public Link(string href, string text) {
            Href = href;
            Text = text;
        }
    }    
}
