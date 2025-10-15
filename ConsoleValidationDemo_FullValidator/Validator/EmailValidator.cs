using ConsoleValidationDemo_FullValidator.Common;
using System.ComponentModel.DataAnnotations;


namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class EmailValidator
    {
        public static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ValidationException(ErrorMessages.EmailEmptyOrNull);

            if (!new EmailAddressAttribute().IsValid(email))
                throw new ValidationException(ErrorMessages.EmailInvalid);
            
            foreach (var ch in email)
            {
                if (char.IsWhiteSpace(ch))
                    throw new ValidationException(ErrorMessages.EmailInvalid);
            }

            foreach (var part in email.Split('@'))
            {
                if (part.Length == 0)
                    throw new ValidationException(ErrorMessages.EmailInvalid);
            }

            foreach (var part in email.Split('.'))
            {
                if (part.Length == 0)
                    throw new ValidationException(ErrorMessages.EmailInvalid);
            }

            if (email.Count(c => c == '@') != 1)
                throw new ValidationException(ErrorMessages.EmailInvalid);

            if (email.StartsWith("@") || email.EndsWith("@") || email.StartsWith(".") || email.EndsWith("."))
                throw new ValidationException(ErrorMessages.EmailInvalid);

            var atIndex = email.IndexOf('@');
            var dotIndex = email.LastIndexOf('.');
            if (dotIndex <= atIndex || dotIndex == atIndex + 1)
                throw new ValidationException(ErrorMessages.EmailInvalid);
        }
    }
}
