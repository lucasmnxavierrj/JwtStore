using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JwtStore.Core.Contexts.SharedContext.Extensions;
using JwtStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwtStore.Core.Contexts.AccountContext.ValueObjects
{
    public class Email : ValueObject
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        protected Email() { }

        #region public constructors
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address)) throw new ArgumentNullException("E-mail inválido!");

            Address = address.Trim().ToLower();

            if (Address.Length < 5) throw new ArgumentException("E-mail inválido");

            if (EmailRegex().IsMatch(Address) is false) throw new ArgumentException("E-mail Inválido");
        }
        #endregion

        #region public properties
        public string Address { get; }
        public Verification Verification { get; private set; } = new();
        #endregion

        #region public methods
        public string Hash => Address.ToBase64();

        public static implicit operator string(Email email) => email.Address;

        public static implicit operator Email(string address) => new Email(address);
        public override string ToString() => Address;
        public void ResendVerification() => Verification = new();
        #endregion

        #region private methods
        private static Regex EmailRegex() => new Regex(Pattern);
        #endregion
    }
}
