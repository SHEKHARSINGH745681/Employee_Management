﻿namespace EmployeeAdminPortal.DTO
{
    public class AddressDTO
    {

        public string? Village { get; set; } 
        public string? City { get; set; } 
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;


    }
}
