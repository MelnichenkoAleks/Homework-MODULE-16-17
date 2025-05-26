using UnityEngine;

public interface IExample
{
    int Property { get; }
    void Method();
}

public class Test : IExample
{
    public int Property { get; }

    public void Method()
    {
        Debug.Log("Method");
    }
}