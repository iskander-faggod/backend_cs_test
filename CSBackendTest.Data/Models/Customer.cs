using System.ComponentModel.DataAnnotations;

namespace CSBackendTest.Data.Models;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public string Surname { get; set; } 

}