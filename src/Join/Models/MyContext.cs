using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Join.Models;

public class User {
    [Key]
    public string UserName { set; get; }
}

public class PreferTarget {
    [ForeignKey(nameof(UserId))]
    public User User { set; get; }
    public string UserId { set; get; }
}

public class Document {
    public int Id { set; get; }
    public string Uuid { set; get; } = Guid.NewGuid().ToString("N");
    public string Subject { set; get; }
    [Column(TypeName = "jsonb")]
    public List<PreferTarget> PreferTargets { set; get; }
}

public class MyContext : DbContext {

    public MyContext(DbContextOptions options) : base(options) {

    }

    public DbSet<User> Users { set; get; }
    public DbSet<Document> Documents { set; get; }
}