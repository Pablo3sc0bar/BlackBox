using BlackBox.Entities.ProductAdditionals;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBox.Entities.Accounting
{
    public class User
    {
        public List<Book> Books;
        public User()
        {
            Books = new List<Book>();
        }
        /// <summary>
        /// Получает или задает ИД
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Получает или задает Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Получает или задает Email
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Получает или задает День рождения пользователя
        /// </summary>
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Получаеи или задаеи Роль пользователя
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Получает или задаеи Id роли
        /// </summary>
        public int? RoleId { get; set; }

    }
}
