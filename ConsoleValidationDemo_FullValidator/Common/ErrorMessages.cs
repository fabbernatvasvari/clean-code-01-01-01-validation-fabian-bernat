namespace ConsoleValidationDemo_FullValidator.Common
{
    public static class ErrorMessages
    {
        public const string GlobalMessage = "\n --- Validációs hiba: ";
        public const string ObjectNull = GlobalMessage +  "Az ellenőrzött objektum nem lehet null.";
        public const string NameNull = GlobalMessage + "A név nem lehet null.";
        public const string NameEmpty = GlobalMessage + "A név nem lehet üres.";
        public const string NameTooShort = GlobalMessage + "A név legalább 2 karakter kell, hogy legyen.";
        public const string NameInvalidChars = GlobalMessage + "A név csak betűket, szóközt és kötőjelet tartalmazhat.";
        public const string EmailEmptyOrNull = GlobalMessage + "Az e-mail nem lehet üres.";
        public const string EmailInvalid = GlobalMessage + "Az e-mail formátuma érvénytelen.";
        public const string AmountNegative = GlobalMessage + "Az egyenleg nem lehet negatív.";
        public const string AmountTooLarge = GlobalMessage + "Az egyenleg túl nagy.";
        public static string NamePartNotCapitalized = GlobalMessage + "A név részeinek nagybetűvel kell kezdődniük.";
    }
}
