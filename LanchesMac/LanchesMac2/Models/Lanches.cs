using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome do Lanche")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e no")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoCurta { get; set; }

        [Required(ErrorMessage = "A descrição do lanche deve ser informado")]
        [Display(Name = "Descrição do Lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no maximo {1} caracteres")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage = "Informar o preço do lanche")]
        [Display(Name = "Preço")]
        //aqui to decidindo o tipo da coluna e tambem uma precição de 10 casas antes da virgula e 2 de pois
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve esta entre 1 e 999,99")]
        [StringLength(200, ErrorMessage = "O {1} deve ter no máximo {1} caracteres")]
        public decimal Preco { get; set; }

        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} carateres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} carateres")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name = "Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name = "Estoque")]
        public bool EmEstoque { get; set; }



        //essas duas propiedades alem do que elas representam elas
        //tambem servem para o ENTIT FRAMEWORK entender que 
        //Categoria se relaciona a Lanches

        public int CategoriaId { get; set; }

        //aqui eu to criando uma propiedade do tipo objeto que pode ser sobreescrito
        public virtual Categoria Categoria { get; set; }
    }
}
