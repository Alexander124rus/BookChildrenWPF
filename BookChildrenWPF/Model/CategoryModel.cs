using System;
using System.Collections.Generic;
using System.Text;

namespace BookChildrenWPF.Model
{
    public class CategoryModel
    {
        public int IdCategory { get; set; }
        public string UrlImageCategory { get; set; }
        public string NameCategory { get; set; }
        public string TextCategory { get; set; }
        public ImageUserCardModel ImageCategory { get; set; }
    }
}
