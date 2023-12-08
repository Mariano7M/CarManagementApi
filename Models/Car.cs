namespace CarManagementApi.Models
{
  public class Car
  {
    public long id { get; set; }
    public string? make { get; set; }
    public string? model { get; set; }
    public int year { get; set; }
  }
}