namespace CardBlazor.Models
{
    public class Customer
    {
        public List<Card> cardTypes = new List<Card>();

        private static Customer uniqueInstance = new Customer();
        private Customer() { }

        public static Customer getInstance()
        {
            return uniqueInstance;
        }
    }
}
