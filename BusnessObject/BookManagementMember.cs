using System;
using System.Collections.Generic;

namespace BusnessObject;

public partial class BookManagementMember
{
    public int MemberId { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public int MemberRole { get; set; }

    public BookManagementMember() { }

    public BookManagementMember(int memberId, string password, string fullName, string email, int memberRole)
    {
        MemberId = memberId;
        Password = password;
        FullName = fullName;
        Email = email;
        MemberRole = memberRole;
    }
    public override string? ToString()
    {
        return base.ToString();
    }
    public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();
}
