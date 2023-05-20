using System.Collections.ObjectModel;
using System.Globalization;
using FinalProject.WebApi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace FinalProject.Selenium.ConsoleClient;

public class Pagination
{
    
    private static TransactionsWebDriver _transactionsWebDriver ;
    
    // sadece seçilen webdriver link çalışmasını sağlıyor
    public Pagination(TransactionsWebDriver transactionsWebDriver)
    {
        _transactionsWebDriver = transactionsWebDriver;
    }
    
    //sayılacak sayfa sayısı için alan oluşturuluyor
    public int PageCount { get; set; }
    

    
    public void CountingPages()
    {
        IWebElement productList = _transactionsWebDriver.driver.FindElement(By.CssSelector("ul.pagination"));

        // Ürünlerin listesini alın
        IList<IWebElement> products = productList.FindElements(By.TagName("li"));

        //sayfa sayısını alın : nexti de bi sayfa sanıyor
        PageCount = products.Count;
        Console.WriteLine("Ürün Sayısı: " + PageCount);
        
        
        for (int i = 1; i < PageCount; i++)
        {
            _transactionsWebDriver.driver.Navigate().GoToUrl("https://finalproject.dotnet.gg/?currentPage=" + i);
            //
            // IReadOnlyCollection<IWebElement> allProductsName =
            //     _transactionsWebDriver.driver.FindElements(By.CssSelector(".fw-bolder.product-name"));
            //
            // IReadOnlyCollection<IWebElement> allProductsPrice =
            //     _transactionsWebDriver.driver.FindElements(By.CssSelector(".price"));
            //
            //
            IReadOnlyCollection<IWebElement> productElements = _transactionsWebDriver.driver.FindElements(By.CssSelector(".card.h-100"));
            
            foreach (IWebElement productElement in productElements)
            {
                string productName = productElement.FindElement(By.CssSelector(".fw-bolder.product-name")).GetAttribute("innerText");
                string productPrice = productElement.FindElement(By.CssSelector(".price")).GetAttribute("innerText");
                productPrice = productPrice.Replace("$", "").Replace(",", "").Trim();
                
                decimal price = string.IsNullOrWhiteSpace(productPrice) ? 0 : decimal.Parse(productPrice, CultureInfo.InvariantCulture);
                
                string productSalePrice = string.Empty;

                
                IWebElement salePriceElement = null;
                
                try
                {
                    salePriceElement = productElement.FindElement(By.CssSelector(".sale-price"));
                }
                catch (NoSuchElementException)
                {
                    // Ignore and continue without sale price
                }

                if (salePriceElement != null)
                {
                    productSalePrice = salePriceElement.GetAttribute("innerText");
                    productSalePrice = productSalePrice.Replace("$", "").Replace(",", "").Trim();
                }
                
                bool isOnSale = productElement.FindElements(By.CssSelector("body > section > div > div > div:nth-child(1) > div > div.badge.bg-dark.text-white.position-absolute.onsale")).Count > 0;
                decimal salePrice = string.IsNullOrWhiteSpace(productSalePrice) ? 0 : decimal.Parse(productSalePrice, CultureInfo.InvariantCulture);

                string pictureUrl = productElement.FindElement(By.CssSelector(".card-img-top")).GetAttribute("src");

                Product product = new Product
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.NewGuid(),
                    Name = productName,
                    Price = price,
                    SalePrice = salePrice,
                    IsOnSale = isOnSale,
                    Picture = pictureUrl,
                    CreatedOn = DateTimeOffset.Now
                };
                
                products.Add(productElement);
                

                
                //Console.WriteLine($"Product Name: {productName} | Price: {productPrice}");
            }

            foreach (Product product in products)
            {
                Console.WriteLine($"Name: {product.Name} Price: {product.Price} Sale Price: {product.SalePrice} Is On Sale: {product.IsOnSale} Picture: {product.Picture}");
            }

            


        }
    }
    
}