using System;
namespace FeeelCity;

public class LogCafe<T>
{
    public void Error(Exception er)
    {
        System.Diagnostics.Debugger.Break();
        System.Diagnostics.Debug.WriteLine($"CAFERU ERROR MESSAGE: {er.Message} \nSTACK TRACE: {er.StackTrace} ", typeof(T));
    }

    public void Debug(string msg)
    {
        System.Diagnostics.Debug.WriteLine($"CAFERU DEBUG MESSAGE: {msg}", typeof(T));
    }

    public void Info(string msg)
    {
        System.Diagnostics.Debug.WriteLine($"CAFERU INFO MESSAGE: {msg}", typeof(T));
    }
}
