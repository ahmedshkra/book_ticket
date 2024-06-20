using Microsoft.EntityFrameworkCore;
using تذكرتك_علينا.Data;

namespace تذكرتك_علينا.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new تذكرتك_عليناContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<تذكرتك_عليناContext>>()))
        {
            // Look for any movies.
            if (context.infomodel.Any())
            {
                return;   // DB has been seeded
            }
            context.infomodel.AddRange(
                new infomodel
                {
                    Name ="Ahmed Sayed",
                    YOurTeam="الاهلى",
                    Phone="٠١٠٢٤٦٥٧٩٣٣",
                    Place="المقصورة الرئيسية",
                    Price=190,
                    Ispuy=true,
                    Date=new DateTime()
                }
               
            );
            context.SaveChanges();
        }
    }
}
