

namespace FormulaOne.Domain.Entities;

public class Driver : BaseEntity
{
    public Driver()
    {
        
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DriverNumber { get; set; }
    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; }
}
