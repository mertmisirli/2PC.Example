using Microsoft.EntityFrameworkCore;

namespace Coordinator.Models.Contexts
{
    public class TwoPhaseCommitDbContext : DbContext
    {
        public TwoPhaseCommitDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }

        public DbSet<NodeState> NodeStates { get; set; }


    }
}
