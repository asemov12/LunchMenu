using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchMenu.Repository.Helpers
{
    public class Filter
    {
        public Dictionary<string, object> Conditions { get; } = new();
        public static Filter Empty => new();

        public void AddCondition(string key, object value) { Conditions[key] = value; }
    }
}
