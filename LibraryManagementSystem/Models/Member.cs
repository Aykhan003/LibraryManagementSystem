namespace LibraryManagementSystem.Models;

public class Member
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber
    {
        get { return field; }
        set
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d{10}$"))
            {
                throw new ArgumentException("Phone number must be a 10-digit number.");
            }
            field = value;
        }
    }
    public DateTime RegistrationDate
    {
        get { return field; }
        set
        {
            if (value > DateTime.Now)
            {
                throw new ArgumentException("Registration date cannot be in the future.");
            }
            field = value;
        }
    }
}
