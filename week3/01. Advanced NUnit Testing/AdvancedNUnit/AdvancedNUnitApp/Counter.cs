namespace AdvancedNUnitApp;

public class Counter
{
    public int Count { get; private set; }
    public Counter(int start) { Count = start; }
    public void Increment() { Count++; }
    public void Decrement() { Count--; }
}