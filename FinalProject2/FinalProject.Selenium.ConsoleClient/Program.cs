using System.Net.Http.Json;
using FinalProject.Selenium.ConsoleClient;
using FinalProject.WebApi.Dtos;
using Microsoft.AspNetCore.SignalR.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


TransactionsWebDriver transactionsWebDriver = new TransactionsWebDriver();

Pagination pagination = new Pagination(transactionsWebDriver);

transactionsWebDriver.Start();
Thread.Sleep(3000);

pagination.CountingPages();

