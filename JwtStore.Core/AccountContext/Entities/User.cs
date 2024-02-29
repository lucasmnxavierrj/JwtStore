using JwtStore.Core.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.AccountContext.ValueObjects;
using JwtStore.Core.SharedContext.Entities;

namespace JwtStore.Core.AccountContext.Entities
{
    public class User : Entity
    {
        protected User() { }
        public User(string email, string? password = null)
        { 
            Email = email;
            Password = new(password);
        }
        public string Name{ get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public string Image { get; } = string.Empty;

        #region public methods
        public void UpdatePassword(string plainTextPassword, string code)
        {
            if (!string.Equals(code.Trim(), Password.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Código de restauração inválido");

            var password = new Password(plainTextPassword);
            Password = password;
        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }

        public void ChangePassword(string plainTextPassword)
        {
            var password = new Password(plainTextPassword);
            Password = password;
        }
        #endregion
    }
}
