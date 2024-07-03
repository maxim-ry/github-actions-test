using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace UnitTestProject
{
    public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public IntegrationTests(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetProductById_ReturnsProduct()
        {
            // Arrange
            var productId = 1;

            // Act
            var response = await _client.GetAsync($"/api/products/{productId}");

            // Assert
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<Product>();
            Assert.Equal(productId, product.Id);
        }

        [Fact]
        public async Task CreateProduct_ReturnsCreatedProduct()
        {
            // Arrange
            var newProduct = new Product { Name = "New Product", Price = 10.0M, Description = "Product1" };
            // Act
            var response = await _client.PostAsJsonAsync("/api/products", newProduct);
            // Assert
            response.EnsureSuccessStatusCode();
            var createdProduct = await response.Content.ReadAsAsync<Product>();
            Assert.Equal(newProduct.Name, createdProduct.Name);
        }

        // TODO: Implement PUT, DELETE enpoints

        /*[Fact]
        public async Task UpdateProductById_ReturnsUpdatedProduct()
        {
            // Arrange
            var productId = 1;
            var updatedProduct = new Product { Id = 1, Name = "Updated Product", Price = 20.0M, Description = "Updated Product 1" };
            // Act
            var response = await _client.PutAsJsonAsync("/api/products/1", updatedProduct);

            // Assert
            response.EnsureSuccessStatusCode();
            var product = await response.Content.ReadAsAsync<Product>();
            Assert.Equal(productId, product.Id);
            *//*Assert.NotEqual(updatedProduct.Name, product.Name);
            Assert.NotEqual(updatedProduct.Price, product.Price);*//*
        }*/

    }
}
