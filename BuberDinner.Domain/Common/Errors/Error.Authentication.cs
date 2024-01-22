using ErrorOr;

namespace BuberDinner.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static partial class Authentication
        {
            public static Error InvalidCredentials => Error.Validation(
                code: "User.InvalidCredentials",
                description: "Invalid credentials."
            );
        }        
    }
}