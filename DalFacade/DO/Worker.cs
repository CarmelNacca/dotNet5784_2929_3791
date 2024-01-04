

namespace DO;
/// <summary>
/// 
/// </summary>
/// <param name="Id">Unique ID number</param>
/// <param name="Name">Worker's name (full name)</param>
/// <param name="Email"></param>
/// <param name="Cost">cost per hour</param>
/// <param name="Level">Worker level</param>
public record Worker
(
    int Id,
    
    double Cost,
    Expirience Level,
    string? Name=null,
    string? Email=null


    )
{
public Worker(): this(0, 0,0) { }////empty ctor for stage 3


}
