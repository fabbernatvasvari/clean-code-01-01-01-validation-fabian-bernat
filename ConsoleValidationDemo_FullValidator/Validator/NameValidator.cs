using ConsoleValidationDemo_FullValidator.Common;
using ConsoleValidationDemo_FullValidator.Exception;

namespace ConsoleValidationDemo_FullValidator.Validator
{
    public static class NameValidator
    {
        public static void ValidateName(string name)
        {
            if (name is null)
                throw new ValidationException(ErrorMessages.NameNull);

            var trimmed = name.Trim();
            if (trimmed.Length == 0)
                throw new ValidationException(ErrorMessages.NameEmpty);

            if (trimmed.Length < 2)
                throw new ValidationException(ErrorMessages.NameTooShort);

            foreach (var ch in trimmed)
            {
                if (!(char.IsLetter(ch) || ch == ' ' || ch == '-'))
                    throw new ValidationException(ErrorMessages.NameInvalidChars);
            }

            foreach (var part in trimmed.Split(' ', '-'))
            {
                if (part.Length == 0) continue; // Két elválasztó egymás után
                if (!char.IsUpper(part[0]))
                    throw new ValidationException(ErrorMessages.NamePartNotCapitalized);
            }
        }
    }
}
