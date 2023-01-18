using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CardGame
{
    /// <summary> Заклинание атаки </summary>
    [DataContract]
    public class CardSpellAttack: Card
    {
        [DataMember]
        public int damage { get; set; }

        public CardSpellAttack(int price, string name,int damage_value, string file_image) {
            Price = price;
            Name = name;
            damage = damage_value;

            sprite_file = file_image;

            DebugOff = false;
        } 

        public void Damage(CardWarrior cardWarrior) {
            if (!DebugOff)
                Debug.Log($"Карта атаки '{Name}' нанесен урон {cardWarrior.CardStatus()} в размере {damage}");
            cardWarrior.Damage(damage);
        }

        public override CardType GetCardType
        {
            get {
                return CardType.Spell_Attack;
            }
        }

        public override string CardStatus()
        {
            return base.CardStatus() + $"Карта атаки '{Name}' Урон: {damage}";
        }

    }
}
