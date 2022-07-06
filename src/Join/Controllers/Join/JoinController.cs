using Join.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Join.Controllers.Join;

[ApiController]
[Route("api/[controller]/[action]")]
public class JoinController : ControllerBase {

    [HttpGet]
    public ActionResult<List<Document>> Join([FromServices] MyContext context) {
        //  is invalid inside an 'Include' operation,
        var doc =
                context.Documents.Include(x => x.PreferTargets).ThenInclude(x => x.User);
        return doc.ToList();
    }

    [HttpGet]
    public IActionResult Insert([FromServices] MyContext context) {
        context.Users.Add(new Models.User { UserName = "wk" });
        context.Users.Add(new Models.User { UserName = "jw" });

        context.Documents.Add(new Document {
            Subject = "A001",
            PreferTargets = new List<PreferTarget> {
                new PreferTarget {
                    UserId = "wk",
                },
                new PreferTarget {
                    UserId = "jw"
                }
            }
        });

        context.SaveChanges();
        return Ok();
    }
}