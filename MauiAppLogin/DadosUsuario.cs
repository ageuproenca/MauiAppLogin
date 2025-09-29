using System.ComponentModel.DataAnnotations;

namespace MauiAppLogin
{
    public class DadosUsuario
    {
        [Key]
        public int Id { get; set; } 
        public string Usuario { get; set; } 
        public string Senha { get; set; } 
    }
}
