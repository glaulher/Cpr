using System;
namespace Cpr.Domain.LivroCaixa
{
    public class LivroCaixa : Entity
    {
        public bool Tipo {get; private set;}
        public virtual Categoria Categoria { get; private set; }
        public DateTime Data { get; private set; }
        public string Descricao {get; private set;}
        public decimal Valor {get; private set;}
        
        
        public LivroCaixa(bool tipo, Categoria categoria, DateTime data, string descricao, decimal valor)
        {
            ValidateValues(tipo, categoria, data, descricao, valor);
            SetProperties(tipo, categoria, data, descricao, valor);
        }
        protected LivroCaixa(){}

        public void Update(bool tipo, Categoria categoria, DateTime data, string descricao, decimal valor)
        {
            ValidateValues(tipo, categoria, data, descricao, valor);
            SetProperties(tipo, categoria, data, descricao, valor);
        }

        private void SetProperties(bool tipo, Categoria categoria, DateTime data, string descricao, decimal valor)
        {
            Tipo = tipo;
            Categoria = categoria;
            Data = data;
            Descricao = descricao;
            Valor = valor;
        }

        private static void ValidateValues(bool tipo, Categoria categoria, DateTime data, string descricao, decimal valor)
        {
            DomainException.when(categoria == null, "Categoria é requerida");
            DomainException.when(string.IsNullOrEmpty(descricao), "Descrição é requirido");
            DomainException.when(valor < 0, "Valor é requerido");           
        }

        public void RemoveFromStock(int quantity){

           // DomainException.when((StockQuantity - quantity) < 0, "Quantity invalid to LivroCaixa stock");
          // StockQuantity -= quantity;
        }
    
         public void delete(string categEntradaSaida)
        {
         //  ValidateValues(tipo, categoria, data, descricao, valor);
        }

    }
}