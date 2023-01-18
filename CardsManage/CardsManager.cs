using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public static class CardsManager
    {
        private static Random random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary> Колода карт игрока </summary>
        private static List<Card> Player_Deck = new List<Card>() {
            new CardWarrior(1, "Воин", 1, 1, Effects.Null, "warrior.png"),
            new CardWarrior(1, "Воин с щитом", 1, 1, Effects.Hardness,"warrior_shield.png"),
            new CardWarrior(2, "Сильный воин", 2, 2, Effects.Null, "warrior.png"),
            new CardWarrior(4, "Паладин", 2, 2, Effects.Hardness, "paladin.png"),
            new CardWarrior(1, "Живое пламя", 4, 4, Effects.Finite, "Fire.png"),

            new CardSpellAttack(2, "Огненный шар", 2, "fire_ball.png"),
            new CardSpellImprove(1, "Волшебный щит", Effects.Hardness, "shield_magic.png"),
            new CardSpellImprove(1, "Каменная кожа", 0, 2, "baff.png"),
            new CardSpellHealing(0, "Слабое зелье исцеления", 1, "heal_potion.jpg"),
        };

        /// <summary> Колода карт врага </summary>
        private static List<Card> Enemy_Deck = new List<Card>() {
            new CardWarrior(1, "Скелет", 1, 1, Effects.Null,"skeleton.png"),
            new CardWarrior(1, "Сильный Скелет", 3, 3, Effects.Null, "super_skeleton.png"),
            new CardWarrior(1, "Скелет", 1, 1, Effects.Null,"skeleton.png"),
            new CardWarrior(1, "Скелет с щитом", 1, 1, Effects.Hardness, "skeleton_with_shield.png"),
            new CardWarrior(1, "Скелет", 1, 1, Effects.Null,"skeleton.png"),

            new CardSpellAttack(2, "Огненный шар", 2, "fire_ball.png"),
        };

        /// <summary> Получение перемешанной колоды Игроком </summary>
        public static List<Card> GetPlayerDeck() {
            return GetDeck(Player_Deck);
        }

        /// <summary> Получение перемешанной колоды Врагом </summary>
        public static List<Card> GetEnemyDeck() {
            return GetDeck(Enemy_Deck);
        }

        /// <summary> Перемешивание колоды </summary>
        private static List<Card> GetDeck(List<Card> deck) {

            for (int i = deck.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);

                var temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;
            }
            return deck;
        }

    }
}
