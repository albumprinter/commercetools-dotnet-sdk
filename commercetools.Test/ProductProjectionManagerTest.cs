﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using commercetools.Common;
using commercetools.Products;
using commercetools.ProductProjections;
using commercetools.ProductTypes;
using commercetools.Project;
using commercetools.TaxCategories;
using Xunit;

namespace commercetools.Test
{
    /// <summary>
    /// Test the API methods in the ProductProjectionManager class.
    /// </summary>
    public class ProductProjectionManagerTest : IDisposable
    {
        private Client _client;
        private Project.Project _project;
        private List<Product> _testProducts;
        private ProductType _testProductType;
        private TaxCategory _testTaxCategory;

        /// <summary>
        /// Test setup
        /// </summary>
        public ProductProjectionManagerTest()
        {
            _client = new Client(Helper.GetConfiguration());

            Task<Response<Project.Project>> projectTask = _client.Project().GetProjectAsync();
            projectTask.Wait();
            Assert.True(projectTask.Result.Success);
            _project = projectTask.Result.Result;

            ProductTypeDraft productTypeDraft = Helper.GetTestProductTypeDraft();
            Task<Response<ProductType>> productTypeTask = _client.ProductTypes().CreateProductTypeAsync(productTypeDraft);
            productTypeTask.Wait();
            Assert.True(productTypeTask.Result.Success);

            _testProductType = productTypeTask.Result.Result;
            Assert.NotNull(_testProductType.Id);

            TaxCategoryDraft taxCategoryDraft = Helper.GetTestTaxCategoryDraft(_project);
            Task<Response<TaxCategory>> taxCategoryTask = _client.TaxCategories().CreateTaxCategoryAsync(taxCategoryDraft);
            taxCategoryTask.Wait();
            Assert.True(taxCategoryTask.Result.Success);

            _testTaxCategory = taxCategoryTask.Result.Result;
            Assert.NotNull(_testTaxCategory.Id);

            _testProducts = new List<Product>();

            for (int i = 0; i < 5; i++)
            {
                ProductDraft productDraft = Helper.GetTestProductDraft(_project, _testProductType.Id, _testTaxCategory.Id);
                Task<Response<Product>> productTask = _client.Products().CreateProductAsync(productDraft);
                productTask.Wait();
                Assert.True(productTask.Result.Success);

                Product product = productTask.Result.Result;
                Assert.NotNull(product.Id);

                _testProducts.Add(product);
            }
        }

        /// <summary>
        /// Test teardown
        /// </summary>
        public void Dispose()
        {
            Task task;

            foreach (Product product in _testProducts)
            {
                task = _client.Products().DeleteProductAsync(product);
                task.Wait();
            }

            task = _client.ProductTypes().DeleteProductTypeAsync(_testProductType);
            task.Wait();

            task = _client.TaxCategories().DeleteTaxCategoryAsync(_testTaxCategory);
            task.Wait();
        }

        /// <summary>
        /// Tests the ProductProjectionManager.GetProductProjectionByIdAsync method.
        /// </summary>
        /// <see cref="ProductProjectionManager.GetProductProjectionByIdAsync"/>
        [Fact]
        public async Task ShouldGetProductProjectionByIdAsync()
        {
            Response<ProductProjection> response = await _client.ProductProjections().GetProductProjectionByIdAsync(_testProducts[0].Id, true);
            Assert.True(response.Success);

            ProductProjection productProjection = response.Result;
            Assert.NotNull(productProjection.Id);
            Assert.Equal(productProjection.Id, _testProducts[0].Id);
        }

        /// <summary>
        /// Tests the ProductProjectionManager.GetProductProjectionByKeyAsync method.
        /// </summary>
        /// <see cref="ProductProjectionManager.GetProductProjectionByKeyAsync"/>
        [Fact]
        public async Task ShouldGetProductProjectionByKeyAsync()
        {
            Response<ProductProjection> response = await _client.ProductProjections().GetProductProjectionByKeyAsync(_testProducts[1].Key, true);
            Assert.True(response.Success);

            ProductProjection productProjection = response.Result;
            Assert.NotNull(productProjection.Id);
            Assert.Equal(productProjection.Id, _testProducts[1].Id);
        }

        /// <summary>
        /// Tests the ProductProjectionManager.QueryProductProjectionsAsync method.
        /// </summary>
        /// <see cref="ProductProjectionManager.QueryProductProjectionsAsync"/>
        [Fact]
        public async Task ShouldQueryProductProjectionsAsync()
        {
            Response<ProductProjectionQueryResult> response = await _client.ProductProjections().QueryProductProjectionsAsync();
            Assert.True(response.Success);

            ProductProjectionQueryResult productProjectionQueryResult = response.Result;
            Assert.NotNull(productProjectionQueryResult.Results);

            int limit = 2;
            response = await _client.ProductProjections().QueryProductProjectionsAsync(limit: limit);
            Assert.True(response.Success);

            productProjectionQueryResult = response.Result;
            Assert.NotNull(productProjectionQueryResult.Results);
            Assert.True(productProjectionQueryResult.Results.Count <= limit);
        }
    }
}
