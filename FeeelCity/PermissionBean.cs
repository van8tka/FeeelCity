using System;
namespace FeeelCity;
public class PermissionBean
{
    public PermissionBean(string name) => Name = name;
    public PermissionBean(bool granted, string name) : this(name) => Granted = granted;
    public bool Granted { get; set; }
    public string Name { get; set; }
}
