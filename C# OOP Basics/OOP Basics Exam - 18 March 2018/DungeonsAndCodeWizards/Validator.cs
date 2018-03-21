using System;
using System.Collections.Generic;

using DungeonsAndCodeWizards.Charaters;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards
{
    public static class Validator
    {
        public static void EnsureCharacterIsNotNull(Character character, string characterName)
        {
            if (character == null)
            {
                throw new ArgumentException($"Character {characterName} not found!");
            }
        }

        public static void EnsuceItemsIsNotEmpty(Stack<Item> items)
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("No items left in pool!");
            }
        }
    }
}
