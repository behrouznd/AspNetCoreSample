using AspNetCoreSample.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreSample.Core.Entities
{
    public class Category : Entity
    {
        public string CategoryName { get; set; }
        public ICollection<Product>  Products { get; set; }
    }
}
