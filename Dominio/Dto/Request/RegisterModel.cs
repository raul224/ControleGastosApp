﻿namespace Dominio.Dto;

public class RegisterModel
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string PasswordValidation { get; set; }
}