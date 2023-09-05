using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CardBlazor.Models
{
    public class Card
    {
        [Required]
        public string Text { get; set; }
        public int Index { get; set; }

        public Property Human { get; set; } = new Property() { Name = "Human", Text = "Человеческие ресурсы"};
        public Property Food { get; set; } = new Property() { Name = "Food", Text = "Еда" };
        public Property OtherSupplies { get; set; } = new Property() { Name = "OtherSupplies", Text = "Прочие припасы" };
        public Property Equipment { get; set; } = new Property() { Name = "Equipment", Text = "Аммуниция"};
        public Property Reputation { get; set; } = new Property() { Name = "Reputation", Text = "Репутация" };
        public Property Distance { get; set; } = new Property() { Name = "Distance", Text = "Цель до которой нужно дойти" };
        public Property Radiation { get; set; } = new Property() { Name = "Radiation", Text = "Радиация" };
        public Property Temperature { get; set; } = new Property() { Name = "Temperature", Text = "Температура" };


        public List<Property> properties => this.GetType().GetProperties()
            .Where(x => x.PropertyType.Name == nameof(Property))
            .Select(x => (Property)x.GetValue(this)!)
            .ToList();

        List<Answer> answers = new List<Answer>();
        public Card()
        {         
        }

        public ReadyCard ConvertToReady()
        { 
            var card = new ReadyCard();
            var targetProps = typeof(ReadyCard).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in typeof(Card).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = (prop.GetValue(this) as Property)?.Value;
                var targetProp = targetProps.FirstOrDefault(x => x.Name == prop.Name);
                if (targetProp != null)
                    targetProp.SetValue(card, value);
            }
            return card;
        }

        public CardToShow ConvertForShow()
        {
            var card = new CardToShow();
            var targetProps = typeof(CardToShow).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach(var prop in typeof(Card).GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = (prop.GetValue(this) as Property)?.Value;
                var targetProp = targetProps.FirstOrDefault(x => x.Name == prop.Name);
                if (targetProp != null)
                    targetProp.SetValue(card, value);
            }
            return card;
        }

        public void Clear()
        {
            foreach(var prop in properties)
            {
                prop.Value = 0;
            }
        }
    }

    public class Answer
    {
        [Required]
        public string Text { get; set; }

    }

    public class Property
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public int Value { get; set; }
        public bool checkedValue { get; set;} = false;

    }
}
