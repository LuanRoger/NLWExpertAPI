﻿namespace NLWExpertAPI.Endpoints.RequestResponseModels;

public class RegisterNewUserRequest
{
    public string nome { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
}