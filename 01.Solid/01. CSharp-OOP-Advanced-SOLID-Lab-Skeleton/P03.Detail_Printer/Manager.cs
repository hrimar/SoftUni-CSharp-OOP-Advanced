using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IWorker
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string ToString()
        {
            string result = base.ToString()
                + $"Documents: {string.Join(Environment.NewLine, this.Documents)}";
            
          
            return result;
        }
    }
}
