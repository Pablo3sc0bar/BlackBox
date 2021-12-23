using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlackBox.Entities.ProductAdditionals
{
    public class Book
    {

        /// <summary>
        /// Получает или задает ID книги
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Получает или Название книги
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или Название книги
        /// </summary>
        public string PhotoLink { get; set; }

        /// <summary>
        /// Получает или Описание книги
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Получает или задает ISBN
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Получает или задает Ссылку для скачивания
        /// </summary>
        public string DownloadLink { get; set; }

        /// <summary>
        /// Получает или задает Жанр
        /// </summary>
        public virtual Jenre Jenre { get; set; }

        /// <summary>
        /// Получает или задает ID Жанра
        /// </summary>
        public int JenreId { get; set; }

        /// <summary>
        /// Получает или задает Жанр
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// Получает или задает ID Жанра
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Получает или задает Цену
        /// </summary>
        public double Cost { get; set; }
    }
}
