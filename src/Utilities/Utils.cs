using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Models;

namespace Gerenciador_de_estoque.src.Utilities
{
    public class Utils
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
                return text;
            }

            bool isNumber = int.TryParse(text, out int number);

            if (!isNumber || number < 0)
            {
                MessageBox.Show("Por favor, insira um número maior ou igual a zero");
                text = "";
            }

            return text;
        }

        public Product ConvertSelectedToProduct(SelectedProd selected)
        {
            Product product = new Product
            {
                Id = selected.Id,
                Name = selected.Name,
                AvailableAmount = selected.AvailableAmount,
                Description = selected.Description
            };
            return product;
        }

        public DataGridView AddProductColumns(DataGridView table)
        {
            try
            {
                table.Columns.Clear();
                table.Columns.Add("IdProduct", "Id");
                table.Columns["IdProduct"].Visible = false;
                table.Columns.Add("Name", "Nome do Produto");
                table.Columns.Add("AvaliableAmount", "Quantidade em Estoque");
                table.Columns.Add("Description", "Descrição");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de produtos: {ex.Message}");
            }

            return table;
        }

        public SelectedProd SelectRowProduct(DataGridView table)
        {
            SelectedProd product = new SelectedProd();
            try
            {
                if (table.CurrentRow != null)
                {
                    int index = table.CurrentRow.Index;

                    if (
                        int.TryParse(
                            table.Rows[index].Cells["IdProduct"].Value.ToString(),
                            out int id
                        )
                    )
                    {
                        product.Id = id;
                    }

                    product.Name = table.Rows[index].Cells["Name"].Value as string;
                    product.Description = table.Rows[index].Cells["Description"].Value as string;

                    if (
                        int.TryParse(
                            table.Rows[index].Cells["AvaliableAmount"].Value.ToString(),
                            out int availableAmount
                        )
                    )
                    {
                        product.AvailableAmount = availableAmount;
                    }
                }

                return product;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar produto: {ex.Message}");
                return product;
            }
        }
    }
}
