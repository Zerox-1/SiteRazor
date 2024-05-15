using Microsoft.EntityFrameworkCore;
using Site.Data;

namespace Site.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new SiteContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<SiteContext>>()))
			{
				if (context == null || context.Room == null)
				{
					throw new ArgumentNullException("Null SiteContext");
				}

				// Look for any Rooms.
				if (context.Room.Any())
				{
					return;   // DB has been seeded
				}

				context.Room.AddRange(
					new Room
					{
						Adress = "Россия, г. Батайск, Партизанская ул., д. 23 кв.14",
						Landlord = "Маугли",
						Duration = 3,
						Price = 1
					},

					new Room
					{
						Adress = "Россия, г. Железногорск, Заводская ул., д. 11 кв.144",
						Landlord = "Эвелина",
						Duration = 5,
						Price = 8.99M
					},

					new Room
					{
						Adress = "Россия, г. Великий Новгород, Комсомольская ул., д. 18 кв.7",
						Landlord = "Артём",
						Duration = 4,
						Price = 9.99M
					},

					new Room
					{
						Adress = "Россия, г. Йошкар-Ола, Новоселов ул., д. 22 кв.147",
						Landlord = "Мелания",
						Duration = 2,
						Price = 3.99M
					}
				);
				context.SaveChanges();
			}
		}
	}
}
