namespace FinalProject.WebApi.Data;

public class Entry:IEntry
{
    public Task<List<string>> HowManyProduct(string number, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<string>> WhatTypeProduct(string type, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}