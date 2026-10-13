using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Service;

public class MemberService
{
    private readonly LibraryDbContext _context;
    public MemberService(LibraryDbContext context)
    {
        _context = context;
    }
    public List<Member> GetAllMembers()
    {
        return _context.Members.ToList();
    }
    public Member GetMemberById(int id)
    {
        return _context.Members.FirstOrDefault(m => m.Id == id);
    }
    public void AddMember(Member member)
    {
        _context.Members.Add(member);
        _context.SaveChanges();
    }
    public void UpdateMember(Member member)
    {
        _context.Members.Update(member);
        _context.SaveChanges();
    }
    public void DeleteMember(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);
        if (member != null)
        {
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
    }
    public List<Member> SearchMembers(string searchTerm)
    {
        return _context.Members
            .Where(m => m.FullName.Contains(searchTerm) || m.Email.Contains(searchTerm))
            .ToList();
    }
}
