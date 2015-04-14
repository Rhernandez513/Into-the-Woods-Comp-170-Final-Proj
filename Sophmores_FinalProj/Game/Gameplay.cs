﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntroCS;

namespace Sophmores_FinalProj
{
	class Program
	{
		static void Main(string[] args)
		{
			// Test create player with custom constructor values
			Player p1 = new Player("George", 10, 10);
			Console.WriteLine(p1.name);
			string nameAndy = UI.PromptLine ("Enter Name");
			Player Andy = new Player (nameAndy, 50, 50);
			Weapon Sword = new Weapon ("steel", "sword", "lhasldh", 20, 0);
			Andy.AddToInventory (Sword, 1);
			Andy.DisplayInventoryContents(Sword.type);
			Console.Write (Andy.name);
			Enemy Spider = new Enemy ();
			Combat.StartCombat (Andy, Spider);



			// Test player "conversation" command
			p1.Emote("Hello");

			// Test create generic non-combat character
			Character NPC1 = new Character();
			if (NPC1.isAlive())
			{
				Console.WriteLine(NPC1.name + " is alive");
			}

			// Test create generic player
			Player p2 = new Player();
			if (p2.isAlive())
			{
				Console.WriteLine("player 2 " + p2.name + " is alive");
				Console.WriteLine("player 2 {0} has {1} health", p2.name, p2.totalHP);
				Console.WriteLine("player 2 level is {0}", p2.level);
			}

			// Test create Axe with placeholders for constructors
			Weapon Axe = new Weapon("axe of smashing", "two-handed axe", "this axe smashes things", 10, 0);
			Console.WriteLine(Axe.name);
			if (Axe.playerCanEquip)
			{
				Console.WriteLine("{0} can be equiped.",Axe.name);
			}
			// Test create inventory with placeholder items added
			Weapon magicbow = new Weapon("MagicBow", "Bow", "A magical bow", 5, 1);

			//string magicArrow = "magical arrows";
			p1.AddToInventory(magicbow, 1);
			p1.DisplayInventoryContents();



			// Test Remove items until no more of said item remain
			for (int i = 0; i < p1.inventory.contents.Count; i++)
			{
				p1.RemoveFromInventory(magicbow, 1);
			}

			//Test Remove item not in inventory
			Item MagicShield = new Item("MagicShield", "Shield", "A Magical Shield");
			p1.RemoveFromInventory(MagicShield, 1);

			//p1.AddToInventory(magicArrow, 5);

			// Create new bag, add items to it, test that cannot add more items 
			// Than capacity of bag
			Quiver testbag = new Quiver();
			Weapon SteelArrow = new Weapon("Steel Arrow", "Arrow", "A Good Arrow", 5, 0);
			testbag.Add(SteelArrow, 7);
			testbag.ArrowsInQuiver();
			testbag.Remove(SteelArrow, 12);
			testbag.ArrowsInQuiver();

			// Test Equip and Unequip player functions
			p1.Equip(SteelArrow);
			Console.WriteLine("player one is wielding " + p1.EquippedWeapon.name);
			p1.UnEquip();
			Console.WriteLine("player one is wielding " + p1.EquippedWeapon.name);

			// Test Inspect Functions
			p1.Inspect(Axe);
			p1.Inspect(p1.EquippedWeapon);

			//Test Health Potions!
			Console.WriteLine("{0}'s current health: {1}", p1.name, p1.currentHP);
			p1.currentHP = p1.currentHP / 2;
			Console.WriteLine("{0}'s current health: {1}", p1.name, p1.currentHP);
			// Create and Inspect Potion to display properties to player
			HealthPotion potion = new HealthPotion();
			p1.Inspect(potion);
			// Add a basic health potion to player 1's inventory here
			// Stronger ones can be made by manually declaring one
			p1.AddToInventory(new HealthPotion(), 1);
			// Test use Healthpotion with 1 HealthPotion in Inventory
			p1.UseHealthPotion();
			Console.WriteLine("{0}'s current health: {1}", p1.name, p1.currentHP);
			// Test UseHealthPotion with NO potions in Inventory
			p1.UseHealthPotion();


			// So console doesn't auto close
			string abc = Console.ReadLine();
		}
	}
}