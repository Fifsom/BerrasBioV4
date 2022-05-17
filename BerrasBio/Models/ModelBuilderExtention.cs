using Microsoft.EntityFrameworkCore;

namespace BerrasBio.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Iron Man 1" },
                new Movie { Id = 2, Title = "SpiderMan Far From Home" },
                new Movie { Id = 3, Title = "Cars 1" });

            modelBuilder.Entity<Salon>().HasData(
                new Salon { Id = 1, Name = "1", NumOfSeats = 50 });

            modelBuilder.Entity<ShowCase>().HasData(
                new ShowCase { Id = 1, Starts = DateTime.Parse("2022-05-20, 20:00:00"), AvailableSeats = 50, MovieId = 1, SalonId = 1 },
                new ShowCase { Id = 2, Starts = DateTime.Parse("2022-05-20, 22:00:00"), AvailableSeats = 50, MovieId = 2, SalonId = 1 });
        }
    }
}
