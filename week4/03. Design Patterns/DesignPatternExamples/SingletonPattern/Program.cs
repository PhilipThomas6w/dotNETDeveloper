using SingletonPattern;

//create new instance and assign to singleton1
Singleton singleton1 = Singleton.Instance;

Console.WriteLine(singleton1.GetCount());
//Output 0

singleton1.Increment();
// Increment counter by 1

Console.WriteLine(singleton1.GetCount());
//Output 1

var singleton2 = Singleton.Instance;
// Get instance and assign to variable singleton

Console.WriteLine(singleton2.GetCount());
//Output 1

singleton1.Increment();
// Increment counter by 1

Console.WriteLine(singleton1.GetCount());
Console.WriteLine(singleton2.GetCount());
// Output 2 for both
