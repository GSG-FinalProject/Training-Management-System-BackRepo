﻿namespace TMS.Domain.DTOs.Trainee;
public class RegisterTraineeDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TrainerId { get; set; }
}