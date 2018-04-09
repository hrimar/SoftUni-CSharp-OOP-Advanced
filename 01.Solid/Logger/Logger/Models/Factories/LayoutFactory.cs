using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Factories
{
   public class LayoutFactory
    {
        public ILayout CreatLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
             case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                case "JsonLayout":
                    layout = new JsonLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }
    }
}
