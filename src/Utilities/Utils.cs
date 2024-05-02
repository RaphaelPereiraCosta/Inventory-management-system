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
        public List<string> ListStates()
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

            List<string> states = new List<string>();
            states.AddRange(stateAbbreviations);
            return states;
        }

        public Dictionary<string, int> ListTypes()
        {
            Dictionary<string, int> types = new Dictionary<string, int>
            {
                { "Entrada", 0 },
                { "Saída", 1 }
            };

            return types;
        }

        public List<string> ListMonths(List<ProductMovement> movements)
        {
            List<string> months = new List<string> { "Mês" };

            foreach (ProductMovement movement in movements)
            {
                string month = Convert.ToDateTime(movement.Date).ToString("MMM");
                if (!months.Contains(month))
                {
                    months.Add(month);
                }
            }

            return months;
        }

        public List<string> ListYears(List<ProductMovement> movements)
        {
            List<string> years = new List<string> { "Ano" };

            foreach (ProductMovement movement in movements)
            {
                string year = Convert.ToDateTime(movement.Date).Year.ToString();
                if (!years.Contains(year))
                {
                    years.Add(year);
                }
            }

            return years;
        }

        public DataGridView AddProductColumns(DataGridView table)
        {
            try
            {
                table.Columns.Clear();
                table.Columns.Add("Id", "Id");
                table.Columns["Id"].Visible = false;
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

                    product.Id = GetIntValueFromCell(table, index, "Id");
                    product.Name = GetStringValueFromCell(table, index, "Name");
                    product.Description = GetStringValueFromCell(table, index, "Description");
                    product.AvailableAmount = GetIntValueFromCell(table, index, "AvaliableAmount");
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

                    supplier.Id = GetIntValueFromCell(table, index, "Id");
                    supplier.Name = GetStringValueFromCell(table, index, "Name");
                    supplier.City = GetStringValueFromCell(table, index, "City");
                    supplier.CEP = GetStringValueFromCell(table, index, "CEP");
                    supplier.Neighborhood = GetStringValueFromCell(table, index, "Neighborhood");
                    supplier.Phone = GetStringValueFromCell(table, index, "Phone");
                    supplier.Street = GetStringValueFromCell(table, index, "Street");
                    supplier.Email = GetStringValueFromCell(table, index, "Email");
                    supplier.Number = GetStringValueFromCell(table, index, "Number");
                    supplier.Complement = GetStringValueFromCell(table, index, "Complement");
                    supplier.State = GetStringValueFromCell(table, index, "State");
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
                movement.Supplier = supplierController.GetOneSupplier(supplierId);
                movement.Supplier.Id = supplierId;
                movement.Supplier.Name = GetStringValueFromCell(table, index, "SupplierName");

                ProductController productController = new ProductController();
                movement.ProductsList = productController.GatherProductsByMovementId(movement.Id);

                movement.Type = GetStringValueFromCell(table, index, "Type");
                movement.Date = GetStringValueFromCell(table, index, "Date");

                return movement;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao selecionar movimento: {ex.Message}");
                return movement;
            }
        }

        public int GetIntValueFromCell(DataGridView table, int rowIndex, string columnName)
        {
            if (
                int.TryParse(table.Rows[rowIndex].Cells[columnName].Value.ToString(), out int value)
            )
            {
                return value;
            }
            return 0;
        }

        public string GetStringValueFromCell(DataGridView table, int rowIndex, string columnName)
        {
            return table.Rows[rowIndex].Cells[columnName].Value.ToString();
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

        public List<ProductMovement> FilterMovementList(
            List<ProductMovement> sourceList,
            string name,
            string month,
            string year
        )
        {
            if (!string.IsNullOrEmpty(name))
            {
                sourceList = FilterMovementListByName(sourceList, name);
            }
            if (!string.IsNullOrEmpty(month) || month == "Mês")
            {
                sourceList = FilterMovementListByMonth(sourceList, month);
            }
            if (!string.IsNullOrEmpty(year) || year == "Ano")
            {
                sourceList = FilterMovementListByYear(sourceList, year);
            }

            return sourceList;
        }

        public List<ProductMovement> FilterMovementListByName(
            List<ProductMovement> sourceList,
            string name
        )
        {
            List<ProductMovement> filtered = new List<ProductMovement>();

            foreach (ProductMovement movement in sourceList)
            {
                if (movement.Supplier.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    filtered.Add(movement);
                }
            }
            return filtered;
        }

        public List<ProductMovement> FilterMovementListByMonth(
            List<ProductMovement> sourceList,
            string month
        )
        {
            List<ProductMovement> filtered = new List<ProductMovement>();

            foreach (ProductMovement movement in sourceList)
            {
                DateTime movementDate = Convert.ToDateTime(movement.Date);

                if (movementDate.ToString("MMM") == month)
                {
                    filtered.Add(movement);
                }
            }
            return filtered;
        }

        public List<ProductMovement> FilterMovementListByYear(
            List<ProductMovement> sourceList,
            string year
        )
        {
            List<ProductMovement> filtered = new List<ProductMovement>();

            foreach (ProductMovement movement in sourceList)
            {
                DateTime movementDate = Convert.ToDateTime(movement.Date);

                if (movementDate.ToString("yyyy") == year)
                {
                    filtered.Add(movement);
                }
            }
            return filtered;
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
                MessageBox.Show(
                    "Este campo só aceita numeros inteiros. Letras e simbulos serão removidos"
                );
                text = RemoveNonDigits(text);
            }

            return text;
        }

        public string RemoveNonDigits(string text)
        {
            return new string(text.Where(char.IsDigit).ToArray());
        }

        public string GetSubstring(string text, int digits)
        {
            if (text.Length > digits)
                text = text.Substring(0, digits);

            return text;
        }

        public bool VerifyLength(string text, string field, int digits)
        {
            text = RemoveNonDigits(text);

            if (text.Length < digits && text.Length > 0)
            {
                MessageBox.Show(
                    "O "
                        + field
                        + " parece estar incompleto. Por favor, complete ou apague o conteúdo do campo.",
                    "Aviso",
                    MessageBoxButtons.OK
                );
                return false;
            }
            return true;
        }
    }
}
