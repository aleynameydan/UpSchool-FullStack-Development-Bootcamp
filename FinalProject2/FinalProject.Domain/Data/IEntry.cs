namespace FinalProject.WebApi.Data;

public interface IEntry
{
    
    Task<List<string>> HowManyProduct(string number, CancellationToken cancellationToken );
    Task<List<string>> WhatTypeProduct(string type, CancellationToken cancellationToken );
}