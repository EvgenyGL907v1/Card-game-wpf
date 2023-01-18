﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CardGame
{
    class CardDraw
    {
        public Canvas canvas;
        public Card card;

        private const string card_basis = "CardBasis.png";
        private const string card_basis0 = "CardNull.png";

        private TextBlock price_text;
        

        public CardDraw() {

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "1";

            textBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            price_text = textBlock;
        }

        public void DrawSprite(Canvas canvas, Card card) {

            canvas.Children.Clear();

            if (!WarriorStatusCheck(card))
            {
                DrawCardHead(canvas, card);
                return;
            }    

            if (card.GetCardType != CardType.CardNull)
            {
                Image card_sprite = new Image()
                {
                    Width = 150,
                    Height = 130,
                    Name = "card_sprite",
                    Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\" + card.sprite_file)),
                };

                Canvas.SetLeft(card_sprite, 40);
                Canvas.SetTop(card_sprite, 40);

                canvas.Children.Add(card_sprite);
            }

            DrawCardHead(canvas, card);
            DrawCardPrice(canvas, card);
            DrawCardName(canvas, card.Name);

            switch (card.GetCardType) {
                case CardType.Warrior: CardWarrior cardWarrior = (CardWarrior)card; 
                    DrawCardAttack(canvas, cardWarrior.AttackPoints);
                    DrawCardHealth(canvas, cardWarrior.Health);
                    DrawEffect(canvas, cardWarrior.CardStatus());
                    break;
                case CardType.Spell_Improve: CardSpellImprove cardSpellImprove = (CardSpellImprove)card;
                    DrawCardAttack(canvas, cardSpellImprove.attack_mod);
                    DrawCardHealth(canvas, cardSpellImprove.health_mod);
                    DrawEffect(canvas, cardSpellImprove.CardStatus());
                    break;
                case CardType.Spell_Attack: CardSpellAttack cardSpellAttack = (CardSpellAttack)card;
                    DrawCardAttack(canvas, cardSpellAttack.damage);
                    break;
                case CardType.Spell_Healing: CardSpellHealing cardSpellHealing = (CardSpellHealing)card;
                    DrawCardHealth(canvas, cardSpellHealing.treatment);
                    break;
            }
        }

        private void DrawCardHead(Canvas canvas, Card card) {
            Image sprite = new Image()
            {
                Width = 231,
                Height = 253,
                Name = "card",
                Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\Resources\\" + ((card.GetCardType != CardType.CardNull && WarriorStatusCheck(card)) ? card_basis : card_basis0))),
            };

            canvas.Children.Add(sprite);
        }

        private bool WarriorStatusCheck(Card card) {

            if (card.GetCardType == CardType.Warrior)
            {
                CardWarrior cardWarrior = (CardWarrior)card;
                return cardWarrior.GameStatus;
            }
            else
                return true;
        }

        private void DrawCardPrice(Canvas canvas, Card card) {
            TextBlock price_text = new TextBlock();
            price_text.Text = card.Price.ToString();

            price_text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Canvas.SetLeft(price_text, 40);
            Canvas.SetTop(price_text, 20);

            canvas.Children.Add(price_text);

        }

        private void DrawCardAttack(Canvas canvas, int value) {
            TextBlock text = new TextBlock();
            text.Text = value.ToString();

            text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Canvas.SetLeft(text, 80);
            Canvas.SetTop(text, 218);

            canvas.Children.Add(text);
        }

        private void DrawCardHealth(Canvas canvas, int value)
        {
            TextBlock text = new TextBlock();
            text.Text = value.ToString();

            text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Canvas.SetLeft(text, 160);
            Canvas.SetTop(text, 218);

            canvas.Children.Add(text);
        }

        private void DrawCardName(Canvas canvas, string name) {
            TextBlock text = new TextBlock();
            text.Text = name;

            text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Canvas.SetLeft(text, 80);
            Canvas.SetTop(text, 18);

            canvas.Children.Add(text);
        }

        private void DrawEffect(Canvas canvas, string effect) {
            TextBlock text = new TextBlock();
            text.Text = effect;

            text.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));

            Canvas.SetLeft(text, 60);
            Canvas.SetTop(text, 170);

            canvas.Children.Add(text);
        }
    }
}
