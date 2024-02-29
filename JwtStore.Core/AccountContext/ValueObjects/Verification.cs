using JwtStore.Core.SharedContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtStore.Core.AccountContext.ValueObjects
{
    public class Verification : ValueObject
    {
        protected Verification() { }
        public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifiedAt { get; private set; } = null;
        public bool IsActive => ExpiresAt == null && VerifiedAt != null;
        public void Verify(string code)
        {
            if (IsActive) { throw new Exception("Código já está ativo."); }

            if (DateTime.UtcNow > ExpiresAt) { throw new Exception("Código expirado."); }

            if ( string.Equals(Code.Trim(), code.Trim(), StringComparison.CurrentCultureIgnoreCase) is false) { throw new Exception("Código informado inválido!"); }
        }
    }
}
