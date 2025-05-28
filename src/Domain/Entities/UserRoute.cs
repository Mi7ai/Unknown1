using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    //This tracks who worked on which route and how much of the route they completed.
    public class UserRoute
    {
        [Key]
        public int UserRouteId { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int RouteId { get; set; }
        public Route Route { get; set; } = null!;

        // Work Progress Tracking
        public decimal DistanceCovered { get; set; } // e.g., 50km of 100km
        public bool Completed { get; set; } = false;
        public DateTime AssignedAt { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedAt { get; set; }

        // New: Records when the driver switched to another route
        public DateTime? SwitchedAt { get; set; }
    }
}