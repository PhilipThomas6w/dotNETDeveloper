using DecoratorExample;
using DecoratorExample.Beverages;
using DecoratorExample.Decorators;

Beverage espresso = new Espresso();
Console.WriteLine(
    $"{espresso.Description()} " +
    $"{espresso.Cost():C}");

Beverage espressoPlus = new Soy(
    new Mocha(
        new Mocha(
            new Espresso()
            )
        )
    );
Console.WriteLine(
    $"{espressoPlus.Description()} " +
    $"{espressoPlus.Cost():C}");

Beverage superEspresso = new Whip(
    new Soy(
        new Mocha(
            new Mocha(
                new Espresso()
                )
            )
        )
    );
Console.WriteLine(
    $"{superEspresso.Description()} " +
    $"{superEspresso.Cost():C}");