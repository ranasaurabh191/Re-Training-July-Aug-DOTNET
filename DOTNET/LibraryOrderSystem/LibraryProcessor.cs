namespace LibraryOrderSystem
{
    static class LibraryProcessor
    {
        public static bool TryProcessOrder(out List<string> validIsbns, params string[] isbns)
        {
            validIsbns = new List<string>();

            foreach (string isbn in isbns)
            {
                if (TryParseISBN(isbn, out string cleaned))
                {
                    validIsbns.Add(cleaned);
                }
            }

            return validIsbns.Count > 0;
        }

        public static bool TryParseISBN(string isbn, out string cleaned)
        {
            cleaned = isbn.Replace("-", "").Replace(" ", "");

            if (cleaned.Length == 13)
            {
                foreach (char c in cleaned)
                {
                    if (!char.IsDigit(c))
                    {
                        cleaned = "";
                        return false;
                    }
                }

                return true;
            }

            cleaned = "";
            return false;
        }
    }
}