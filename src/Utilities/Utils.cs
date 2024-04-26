using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Gerenciador_de_estoque.src.Controllers;
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

        public string ValidateNumber(string text)
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

        public DataGridView AddMovementColumns(DataGridView table)
        {
            try
            {
                table.Columns.Clear();
                table.Columns.Add("Id", "Id");
                table.Columns["Id"].Visible = false;
                table.Columns.Add("SupplierId", "SId");
                table.Columns["SupplierId"].Visible = false;
                table.Columns.Add("SupplierName", "Nome do Fornecedor");
                table.Columns.Add("Type", "Tipo");
                table.Columns.Add("Date", "Data");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao adicionar colunas à lista de movimentações: {ex.Message}"
                );
            }

            return table;
        }

        public DataGridView AddSupplierColumns(DataGridView table)
        {
            try
            {
                table.Columns.Clear();
                table.Columns.Add("Id", "Id");
                table.Columns.Add("Name", "Nome");
                table.Columns.Add("Phone", "Telefone");
                table.Columns.Add("CEP", "CEP");
                table.Columns.Add("Neighborhood", "Bairro");
                table.Columns.Add("Street", "Rua");
                table.Columns.Add("Email", "Email");
                table.Columns.Add("Number", "Número");
                table.Columns.Add("Complement", "Complemento");
                table.Columns.Add("City", "Cidade");
                table.Columns.Add("State", "Estado");

                table.Columns["Id"].Visible = false;
                table.Columns["CEP"].Visible = false;
                table.Columns["Neighborhood"].Visible = false;
                table.Columns["Street"].Visible = false;
                table.Columns["Email"].Visible = false;
                table.Columns["Number"].Visible = false;
                table.Columns["Complement"].Visible = false;
                table.Columns["Phone"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar colunas à lista de fornecedores: {ex.Message}");
            }

            return table;
        }

        public Product SelectRowProduct(DataGridView table)
        {
            Product product = new Product();
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

        public Supplier SelectRowSupplier(DataGridView table)
        {
            Supplier supplier = new Supplier();
            try
            {
                if (table.CurrentRow != null)
                {
                    int index = table.CurrentRow.Index;

                    if (int.TryParse(table.Rows[index].Cells["Id"].Value.ToString(), out int id))
                    {
                        supplier.Id = id;
                    }

                    supplier.Name = table.Rows[index].Cells["Name"].Value.ToString();
                    supplier.City = table.Rows[index].Cells["City"].Value.ToString();
                    supplier.CEP = table.Rows[index].Cells["CEP"].Value.ToString();
                    supplier.Neighborhood = table
                        .Rows[index]
                        .Cells["Neighborhood"]
                        .Value.ToString();
                    supplier.Phone = table.Rows[index].Cells["Phone"].Value.ToString();
                    supplier.Street = table.Rows[index].Cells["Street"].Value.ToString();
                    supplier.Email = table.Rows[index].Cells["Email"].Value.ToString();
                    supplier.Number = table.Rows[index].Cells["Number"].Value.ToString();
                    supplier.Complement = table.Rows[index].Cells["Complement"].Value.ToString();
                    supplier.State = table.Rows[index].Cells["State"].Value.ToString();
                }

                return supplier;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar fornecedor: {ex.Message}");
                return supplier;
            }
        }

        public ProductMovement SelectRowMovement(DataGridView table)
        {
            if (table.CurrentRow == null)
            {
                return new ProductMovement();
            }

            int index = table.CurrentRow.Index;
            var movement = new ProductMovement();

            try
            {
                movement.Id = GetIntValueFromCell(table, index, "Id");
                int supplierId = GetIntValueFromCell(table, index, "SupplierId");

                SupplierController supplierController = new SupplierController();
                movement.Supplier = supplierController.GetOneFornecedor(supplierId);
                movement.Supplier.Id = supplierId;
                movement.Supplier.Name = table.Rows[index].Cells["SupplierName"].Value as string;

                ProductController productController = new ProductController();
                movement.ProductsList = productController.GatherProductsByMovementId(movement.Id);

                movement.Type = table.Rows[index].Cells["Type"].Value as string;
                movement.Date = table.Rows[index].Cells["Date"].Value.ToString();

                return movement;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar movimento: {ex.Message}");
                return movement;
            }
        }

        private int GetIntValueFromCell(DataGridView table, int rowIndex, string columnName)
        {
            if (
                int.TryParse(table.Rows[rowIndex].Cells[columnName].Value.ToString(), out int value)
            )
            {
                return value;
            }
            return 0;
        }

        public List<Product> FilterProductList(List<Product> sourceList, string name)
        {
            List<Product> filtered = new List<Product>();

            foreach (Product product in sourceList)
            {
                if (product.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.Add(product);
                }
            }
            return filtered;
        }


        public List<Supplier> FilterSupplierList(List<Supplier> sourceList, string name)
        {
            List<Supplier> filtered = new List<Supplier>();

            foreach (Supplier supplier in sourceList)
            {
                if (supplier.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.Add(supplier);
                }
            }
            return filtered;
        }

        public string FormatPhone(string text)
        {
            try
            {
                text = new string(text.Where(char.IsDigit).ToArray());

                if (text.Length > 10)
                    text = text.Substring(0, 10);

                if (text.Length == 10)
                    text = text.Insert(0, "(").Insert(3, ")").Insert(8, "-");

                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar telefone: {ex.Message}");

                return text;
            }
        }

        public string FormatCEP(string text)
        {
            try
            {
                text = new string(text.Where(char.IsDigit).ToArray());

                if (text.Length > 8)
                    text = text.Substring(0, 8);

                if (text.Length == 8 && !text.Contains("-"))
                    text = text.Insert(5, "-");

                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar CEP: {ex.Message}");
                return text;
            }
        }

        public string FormatDate(string text)
        {
            try
            {
                text = new string(text.Where(char.IsDigit).ToArray());

                if (text.Length > 8)
                    text = text.Substring(0, 8);

                if (text.Length == 8 && text[2] != '/' && text[5] != '/')
                {
                    text = text.Insert(2, "/");
                    text = text.Insert(5, "/");
                }

                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao formatar a data: {ex.Message}");
                return text;
            }
        }
    }
}
