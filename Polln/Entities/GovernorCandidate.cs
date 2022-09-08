
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class GovernorCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string Photo { get; set; }
        public string PartyLogo { get; set; }
        public ICollection<GovernorVote> GovernorVotes { get; set; }

    }
}