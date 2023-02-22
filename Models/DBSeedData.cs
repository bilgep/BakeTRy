namespace BakeTRy.Models
{
    public class DBSeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            BaketryDBContext baketryDBContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BaketryDBContext>();

            // Seed Categories if empty
            if (!baketryDBContext.Categories.Any())
            {
                baketryDBContext.Categories.AddRange(
                    new Category {  CategoryName = "Breads" },
                    new Category { CategoryName = "Simit" },
                    new Category {  CategoryName = "Borek" });
            }

            baketryDBContext.SaveChanges();

            if (!baketryDBContext.Pastries.Any())
            {
                baketryDBContext.Pastries.AddRange(
                new Pastry { 
                    Name = "Somun (Loaf)", 
                    Price = 5.5M, ImageUrl = "/img/somun.jpg", 
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId, 
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId), Description = "Turkey’s most popular bread is the pointy-tipped, boat-shaped regular loaf, with its distinctive slash down the centre. This traditional, airy white bread is available in every bakery, local mini-market and shop throughout Turkey, and the government sets its price. "
                },
                new Pastry { Name = "Vakifkebir", Price = 7M, ImageUrl = "/img/vakifkebir.jpg", 
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId), Description= "Another everyday white flour Turkish bread is called Vakfıkebir or Trabzon ekmek, hailing from the Black Sea. Made from a dense sourdough and cooked in a wood oven, it is far more filling than somun ekmek, has a longer shelf life and is generally round in shape."
                },
                new Pastry {  Name = "Cornbread", Price = 8.5M, ImageUrl = "/img/cornbread.jpg", 
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Breads")!.CategoryId), Description = "Tasty savoury cornbread is popular in many countries, and Turkey is no exception. Excellent served warm from the oven, and perhaps with a lashing of lightly salted local butter, it’s a real treat! The best Turkish cornbread is said to come from the Black Sea where they produce many varieties, some with cheese, herbs or even anchovies cooked into the dough."
                },
                new Pastry { Name = "Simit", Price = 5M, ImageUrl = "/img/simit.jpg",
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Simit")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Simit")!.CategoryId), Description = "Turkish simit is a circular bread that's commonly accompanied by either tea or ayran (salted yogurt drink) and consumed for breakfast with fruit preserves or in savory combinations with cheese, pastırma (salt cured beef), and fresh vegetables."
                },
                new Pastry { Name = "Butter Simit", Price = 6M, ImageUrl = "/img/buttersimit.png",
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Simit")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Simit")!.CategoryId), Description= "Turkish simit baked with butter."
                },
                new Pastry { Name = "Cheese Borek", Price = 10.5M, ImageUrl = "/img/cheeseborek.jpg",
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Borek")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Borek")!.CategoryId), Description = "Turkish Borek is thinly rolled pastry, often the paper-sheet thin variety known as phyllo (yufka in Turkish), which is wrapped around cheese filling arranged in layers. "
                },
                new Pastry { Name = "Patato Borek", Price = 10.5M, ImageUrl = "/img/patatoborek.jpg",
                    CategoryId = baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Borek")!.CategoryId,
                    CurrentCategory = baketryDBContext.Categories.FirstOrDefault(c => c.CategoryId == baketryDBContext.Categories.FirstOrDefault<Category>(x => x.CategoryName == "Borek")!.CategoryId), Description= "Turkish Borek is thinly rolled pastry, often the paper-sheet thin variety known as phyllo (yufka in Turkish), which is wrapped around patato and vegetable fillings arranged in layers. "
                }
                    );

            }

            baketryDBContext.SaveChanges();



        }
    }
}
