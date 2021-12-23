using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackBox.Entities.ProductAdditionals
{
    public class Author
    {
        public IEnumerable<Book> Books;
        public Author()
        {
            Books = new List<Book>();
        }
        /// <summary>
        /// Получает или задает ID автора
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Получает или задает Описание автора
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает Описание автора
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Получает или задает фото автора
        /// </summary>
        public string ImageLink { get; set; }
    }
}
