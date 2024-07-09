using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstudosAPI.Model
{
    [Table("t_usuario")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? email { get; set; }
        public string? login { get; set; }
        public string? senha { get; set; }
        public string? photo { get; set; }

        public User(string? nome, string? email, string? login, string? senha, string photo)
        {
            this.nome = nome;
            this.email = email;
            this.login = login;
            this.senha = senha;
            this.photo = photo;
        }
    }
}
