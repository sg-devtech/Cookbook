using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook
{
    public class Recepts
    {
        public int AnzahlderZutaten { get; set; }
        public string Topic { get; set; }

        public string Zubereitung { get; set; }

        public List<string> Materials { get; set; } = new List<string>();
    }
}
