using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Core.Contexts.SharedContext.Entities
{
    public abstract class Entity
    {
        protected Entity() => Id = Guid.NewGuid();
        public Guid Id { get; }
        public bool Equals(Guid id) => Id == id;
        //public override int GetHashCode() => Id.GetHashCode();
    }
}
