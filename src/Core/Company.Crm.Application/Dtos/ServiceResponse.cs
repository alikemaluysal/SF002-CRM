﻿namespace Company.Crm.Application.Dtos;

public class ServiceResponse
{
    public ServiceResponse(string errorMessage)
    {
        Message = errorMessage;
    }

    public ServiceResponse(bool isSuccess, string errorMessage)
    {
        IsSuccess = isSuccess;
        Message = errorMessage;
    }

    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
}
