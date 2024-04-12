using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Utils
{
    public class Utilities
    {
        public List<string> FillStates(List<string> states)
        {
            string[] stateAbbreviations = new string[]
            {
                "AC",
                "AL",
                "AP",
                "AM",
                "BA",
                "CE",
                "DF",
                "ES",
                "GO",
                "MA",
                "MT",
                "MS",
                "MG",
                "PA",
                "PB",
                "PR",
                "PE",
                "PI",
                "RJ",
                "RN",
                "RS",
                "RO",
                "RR",
                "SC",
                "SP",
                "SE",
                "TO"
            };

            states.AddRange(stateAbbreviations);
            return states;
        }

        public Dictionary<string, int> FillType()
        {
            Dictionary<string, int> types = new Dictionary<string, int>
            {
                { "Entrada", 0 },
                { "Saída", 1 }
            };

            return types;
        }

        public string ValidateNonNegativeNumber(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                text = "0";
            }

            bool isNumber = int.TryParse(text, out int number);

            if (!isNumber || number < 0)
            {
                MessageBox.Show("Por favor, insira um número não negativo");
                text = "0";
            }

            return text;
        }

        public SelectedProd ConvertProdToSelected(Product prod)
        {
            SelectedProd selected = new SelectedProd
            {
                IdProduct = prod.IdProduct,
                Name = prod.Name,
                Description = prod.Description,
                AvaliableAmount = prod.AvaliableAmount,
                AmountChange = 0
            };

            return selected;
        }
    }
}
