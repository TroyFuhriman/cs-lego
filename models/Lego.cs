namespace Legos.Models
{
  public class Lego
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string size { get; set; }
  }
  public class KitLego : Lego
  {
    public int KitLegoId { get; set; }
  }

}