﻿namespace TMS.Domain.DTOs.shared;
public class UpdateUserDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? TrainingFieldId { get; set; }
    public string Bio { get; set; }
}
