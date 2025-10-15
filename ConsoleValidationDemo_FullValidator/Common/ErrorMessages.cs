namespace ConsoleValidationDemo_FullValidator.Common
{
    public static class ErrorMessages
    {
        public const string ObjectNull = "Az ellenőrzött objektum nem lehet null.";
        public const string NameNull = "A név nem lehet null.";
        public const string NameEmpty = "A név nem lehet üres.";
        public const string NameTooShort = "A név legalább 2 karakter legyen.";
        public const string NameInvalidChars = "A név csak betűket, szóközt és kötőjelet tartalmazhat.";
        public const string EmailEmptyOrNull = "Az e-mail nem lehet üres.";
        public const string EmailInvalid = "Az e-mail formátuma érvénytelen.";
        public const string AmountNegative = "Az egyenleg nem lehet negatív.";
        public const string AmountTooLarge = "Az egyenleg túl nagy.";
        public static string NamePartNotCapitalized = "A név részeinek nagybetűvel kell kezdődniük.";
    }
}
