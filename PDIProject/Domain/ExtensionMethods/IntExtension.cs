namespace PDIProject.Domain.ExtensionMethods
{
    public static class IntExtension
    {
        public static DateTime ToDateTime(this int value)
        {
            var dateStr = value.ToString();
            if (dateStr.Length != 8)
                throw new ArgumentException("Insira uma data em int válida com 8 dígitos");

            var year = int.Parse(dateStr.Substring(0, 4));
            var month = int.Parse(dateStr.Substring(4, 2));
            var day = int.Parse(dateStr.Substring(6, 2));
            return new DateTime(year, month, day);
        }
    }
}
