using System.Runtime.Serialization;

namespace CardGame
{
    [DataContract]
    /// <summary> Заклинание лечения </summary>
    public class CardSpellHealing: Card
    {
        [DataMember]
        public int treatment { get; set; }

        public CardSpellHealing(int price, string name,int treatment_value, string file_image)
        {
            Price = price;
            Name = name;
            treatment = treatment_value;

            sprite_file = file_image;
            DebugOff = false;
        }

        public override CardType GetCardType
        {
            get
            {
                return CardType.Spell_Healing;
            }
        }

        public void Treatment(CardWarrior cardWarrior)
        {
            if (!DebugOff)
                Debug.Log($"Карта '{Name}' лечение {cardWarrior.CardStatus()} на величину {treatment}");
            cardWarrior.Treatment(treatment);
        }

        public override string CardStatus()
        {
            return base.CardStatus() + $"Карта лечения '{Name}' Лечение: {treatment}";
        }
    }
}
