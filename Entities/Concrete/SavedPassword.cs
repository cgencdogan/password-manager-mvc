using Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;
public class SavedPassword : BaseEntity {
    public string UserName { get; set; }
    public string Password { get; set; }
    public string? Description { get; set; }
    public string Url { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
}
