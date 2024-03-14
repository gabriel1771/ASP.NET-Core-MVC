using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    //aqui eu to reforçando que vai ser gerado uma tabela com o nome
    //categoria
    [Table("Categorias")]
    public class Categoria
    {
        //aqui mesma coisa porem para uma coluna Key
        [Key]
        public int CategoriaId { get; set; }


        //definindo o tamanho e uma mensagem caso isso seja desrespeitado
        [StringLength(100, ErrorMessage = "O tamanho máximo é 100 caractere")]
        //aqui eu tornando um campo obrigatório e informando um texto
        [Required(ErrorMessage = "Informe o nome da categoria")]
        //aqui eu to meio que definindo o nome da coluna para Nome em vez de CategoriaNome
        [Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caractere")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        //aqui eu criei um propiedade do tipo List do tipo Lanche chamado Lanches
        //porem isso aqui tambem serve para o ENTIT FRAMEWORK entender que 
        //Categoria se relaciona a Lanches
        public List<Lanche> Lanches { get; set;}

    }
}
