using Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete;
public class Category : BaseEntity{
    public string Name { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public ICollection<SavedPassword> SavedPasswords { get; set; }
}