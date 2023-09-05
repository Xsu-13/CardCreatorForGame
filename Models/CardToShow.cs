namespace CardBlazor.Models
{
    public class CardToShow
    {
        public string Text { get; set; }

        public PropertyToShow Human { get; set; } = new PropertyToShow() { Text = "Человеческие ресурсы", Value = null };
        public PropertyToShow Food { get; set; } = new PropertyToShow() { Text = "Еда", Value = null };
        public PropertyToShow OtherSupplies { get; set; } = new PropertyToShow() { Text = "Прочие припасы", Value = null };
        public PropertyToShow Equipment { get; set; } = new PropertyToShow() { Text = "Аммуниция", Value = null };
        public PropertyToShow Reputation { get; set; } = new PropertyToShow() { Text = "Репутация", Value = null };
        public PropertyToShow Distance { get; set; } = new PropertyToShow() { Text = "Цель до которой нужно дойти", Value = null };
        public PropertyToShow Radiation { get; set; } = new PropertyToShow() { Text = "Радиация", Value = null };
        public PropertyToShow Temperature { get; set; } = new PropertyToShow() { Text = "Температура", Value = null };

        public List<PropertyToShow> properties { get; set; }
        public int card { get; set; }

        public CardToShow(int human, int food, int supp, int equip, int reputation, int distance, int radiation, int temp)
        {
            properties = new List<PropertyToShow>() { Human, Food, OtherSupplies, Equipment, Reputation, Distance, Radiation, Temperature };
            Human.Value = human; 
            Food.Value = food; 
            OtherSupplies.Value = supp; 
            Equipment.Value = equip; 
            Reputation.Value = reputation; 
            Distance.Value = distance; 
            Radiation.Value = radiation; 
            Temperature.Value = temp;
        }
        public CardToShow()
        {

        }

    }

    public class PropertyToShow
    {
        public int? Value { get; set; }
        public string Text { get; set; }
    }
}
