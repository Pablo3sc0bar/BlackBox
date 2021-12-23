using BlackBox.Entities.Accounting;
using BlackBox.Entities.ProductAdditionals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBox.Entities.Ordering
{
    public class UsersAndBooks
    {
        [Key]
        public int ID { get; set; }
        public virtual Book Book { get; set; }

        public int BookID { get; set; }

        public virtual User User { get; set; }

        public int UserID { get; set; }
    }
}
