using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac2.Models
{
    [Table("CarrinhoCompraItens")]
    public class CarrinhoCompraItem   //aqui estou criando mais uma entidade para o meu modelo de dominio
    {
        //aqui eu vou ter um Id pra cada item no meu carrinho
        //ou seja, cada CarrinhoCompraITem vai ser unico, só vai variar a quantidade
        public int CarrinhoCompraItemId { get; set; }
        
        //aqui eu to criando outra coluna Id que no caso vai ser o id do lanche que está 
        //no carrinho
        public Lanche Lanche { get; set; }

        public int Quantidade { get; set; }

        //aqui eu to criando um Id para cada carrinho de compra de cada cliente
        //ou seja, vai varios CarrinhoCompraItem vão ter o mesmo valor
        [StringLength(200)]
        public string CarrinhoCompraId { get; set; }

    }
}
