using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gerenciador_de_estoque.src.Utils
{
    public class Utils
    {
        public static List<string> FillStates(List<string> states)
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

        public static List<string> FillType(List<string> types)
        {
            string[] type = new string[]
            {
                "Entrada",
                "Saída"
               
            };

            types.AddRange(type);
            return types;
        }
    }
}
