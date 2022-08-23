using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItVis.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public UserAccount UserAccount { get; set; } = null!;
        public User(string name)
        {
            Name = name;
        }
    }
}
