﻿using System.ComponentModel.DataAnnotations;

namespace KPMG.ComplianceMonitor.Infra.CrossCutting.Identity.Models;

public class LoginUser
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}
