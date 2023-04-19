using FactoryMethodExample.DrinkShop;

DrinkMaker teaMaker = new TeaFactory();
DrinkMaker coffeeMaker = new CoffeeFactory();

var fruitTea = GetDrink("Fruit", teaMaker);
var espresso = GetDrink("Espresso", coffeeMaker);

static Beverage? GetDrink(string typeOfDrink, DrinkMaker drinkFactory)
{
    var drink = drinkFactory.OrderDrink(typeOfDrink);
    if (drink != null)
    {
        Console.WriteLine($"Here's your {drink.Name}, have a great day!");
    }
    Console.WriteLine();
    return drink;
}
