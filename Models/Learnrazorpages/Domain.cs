namespace DotNetRazorPages.Models.Learnrazorpages;

public class User
{
  public int Id { get; set; }
  public required string Name { get; set; }
  public required string UserName { get; set; }
  public required string Email { get; set; }
  public required string Phone { get; set; }
  public required string Website { get; set; }
  public required Address Address { get; set; }
  public required Company Company { get; set; }
}
public class Address
{
  public required string Street { get; set; }
  public required string Suite { get; set; }
  public required string City { get; set; }
  public required string Zipcode { get; set; }
  public required Geo Geo { get; set; }
}
public class Company
{
  public required string Name { get; set; }
  public required string Catchphrase { get; set; }
  public required string Bs { get; set; }
}
public class Geo
{
  public float Lat { get; set; }
  public float Lng { get; set; }
}
