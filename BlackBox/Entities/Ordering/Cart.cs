using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackBox.Entities;
using BlackBox.Entities.Accounting;
using BlackBox.Entities.ProductAdditionals;

namespace BlackBox.Entities.Ordering
{
    public class Cart 
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Получает или задает User
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Получает или задает Id юзера
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Получает или задает Продукт в корзине
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// Получает или задает Id продукта
        /// </summary>
        public int BookId { get; set; }

    }
}
