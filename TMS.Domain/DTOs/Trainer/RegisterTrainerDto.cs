﻿using System.ComponentModel.DataAnnotations;

namespace TMS.Domain.DTOs.Trainer;

public class RegisterTrainerDto
{
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(100, ErrorMessage = "Password must be at least {2} characters long.", MinimumLength = 6)]
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? Bio { get; set; }
    public int TrainingFieldId { get; set; }
}