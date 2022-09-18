namespace ModelEnums.Extensions
{
    public static class ConvertEnumToStringExtension
    {
        public static string ConvertToShortenedString(this Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "Муж.";
                case Gender.Female:
                    return "Жен.";
                default:
                    return "Не опред.";
            }
        }
    }
}
