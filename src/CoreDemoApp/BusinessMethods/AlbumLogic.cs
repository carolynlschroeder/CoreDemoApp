using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemoApp.BusinessMethods
{
    public class AlbumLogic
    {
        public static SelectList GetQuantitySelectList()
        {
            var quantityDictionary = GetDictionary();
            return
                new SelectList(
                    ((Dictionary<int, int>)quantityDictionary).Select(x => new { value = x.Key, text = x.Value }),
                    "value", "text");
        }

        public static Dictionary<int, int> GetDictionary()
        {
            var quantityDictionary = new Dictionary<int, int>();
            for (int i = 1; i <= 10; i++)
            {
                quantityDictionary.Add(i, i);
            }
            return quantityDictionary;
        }
    }
}
