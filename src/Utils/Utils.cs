using System.Collections.Generic;
using System.Windows.Forms;

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

        public List<string> FillType(List<string> types)
        {
            string[] type = new string[]
            {
                "Entrada",
                "Saída"
               
            };

            types.AddRange(type);
            return types;
        }

        public string ValidateNonNegativeNumber(string text)
        {
            int number;

            if (string.IsNullOrEmpty(text))
            {
                text = "0";
            }

            bool isNumber = int.TryParse(text, out number);

            if (!isNumber || number < 0)
            {
                MessageBox.Show("Por favor, insira um número não negativo");
                text = "0";
            }

            return text;
        }

    }
}
