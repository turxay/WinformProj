using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P507Pr0ject.ViewModels
{
    class LSB_Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Amount { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Amount}";
        }
    }
}
