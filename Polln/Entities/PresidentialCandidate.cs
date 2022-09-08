using System.Collections.Generic;

namespace WebApi.Entities
{
    public class PresidentialCandidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Party { get; set; }
        public string Photo { get; set; }
        public string PartyLogo { get; set; }
        public ICollection<PresidentialVote> PresidentialVotes { get; set; }

    }
}