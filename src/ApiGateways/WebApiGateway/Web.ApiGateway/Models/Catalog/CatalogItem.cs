using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ApiGateway.Models.Catalog
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
    }
}
