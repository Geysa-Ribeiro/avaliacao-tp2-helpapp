using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using HelpApp.Domain.Entities;
using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace HelpApp.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Atributos

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Construtor

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Metodos

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _dbContext.Products.Include(products => product.Category).AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetById(int id)
        {
            ValidateId(id);

            var product = await _dbContext.Products.Include(product => product.Category).AsNoTracking().FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public async Task<Product> Create(Product product)
        {
            ValidateProduct(product);

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangeAsync();

            return product;
        }

        public async Task<Product> Update (Product product)
        {
            ValidateProduct(product);

            _dbContext.Products.Update(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Remove(Product product)
        {
            ValidateProduct(product);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();

            return product;
        }

        #endregion

        #region Validação

        private void ValidateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product), "Product must be provided.");
        }

        private void ValidateId(int id)
        {
            if (!id.HasValue || id <= 0)
                throw new ArgumentException("Category ID has to be a positive number.", nameof(id));
        }

        #endregion
    }
}
