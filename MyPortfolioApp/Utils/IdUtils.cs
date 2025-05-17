namespace MyPortfolioApp.Utils
{
    public static class IdUtils
    {
        private static int CategoryId = 0;
        private static int TypeId = 0;
        private static int ExpenseId = 0;

        public static int GetNextCategoryId()
        {
            CategoryId++;
            return CategoryId;
        }

        public static int GetNextTypeId()
        {
            TypeId++;
            return TypeId;
        }

        public static int GetNextExpenseId()
        {
            ExpenseId++;
            return ExpenseId;
        }
    }
}
